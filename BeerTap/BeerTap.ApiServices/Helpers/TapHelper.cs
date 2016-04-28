using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTap.Data;
using BeerTap.Model;

namespace BeerTap.ApiServices.Helpers
{
    public static class TapHelper
    {
        public static Tap GetById(int id)
        {
            using (var db = new DataContext())
            {
                var tap = db.Taps.FirstOrDefault(x => x.Id == id);
                var result = AutoMapper.Mapper.Map<Tap>(tap);
                result.Keg = KegHelper.GetById(tap.KegId);
                result.KegState = ChangeKegState(result.VolumeLeft, result.Keg.MinCapacity, result.Keg.MaxCapacity);
                return result;
            }
        }

        public static IEnumerable<Tap> GetAllTapByOfficeId(int id)
        {
            using (var db = new DataContext())
            {
                var taps = db.Taps.Where(x => x.OfficeId == id).ToList();
                var result = AutoMapper.Mapper.Map<IEnumerable<Tap>>(taps);
                foreach (var tap in taps)
                {
                    var keg = KegHelper.GetById(tap.KegId);
                    var item = result.FirstOrDefault(x => x.Id == tap.Id);
                    item.Keg = keg;
                    item.KegState = ChangeKegState(item.VolumeLeft, keg.MinCapacity, keg.MaxCapacity);
                }

                return result;
            }
        }

        private static KegState ChangeKegState(int volumeLeft, int kegMinimum, int kegMaximum)
        {
            var kegState = KegState.Dry;
            if(volumeLeft >= kegMaximum)
                kegState = KegState.New;
            else if (volumeLeft < kegMaximum && volumeLeft > kegMinimum)
                kegState = KegState.GoinDown;
            else if(volumeLeft <= kegMinimum && volumeLeft > 0)
                kegState = KegState.AlmostEmpty;
            return kegState;
        }

        public static void UpdateTapById(int id, int volume)
        {
            using (var db = new DataContext())
            {
                var tap = db.Taps.FirstOrDefault(x => x.Id == id);
                tap.VolumeLeft -= volume;
                db.Entry(tap).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void ReplaceKeg(int tapId, int kegId)
        {
            using (var db = new DataContext())
            {
                var tap = db.Taps.FirstOrDefault(x => x.Id == tapId);
                tap.KegId = kegId;
                tap.VolumeLeft = KegHelper.GetById(kegId).MaxCapacity;
                db.Entry(tap).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
