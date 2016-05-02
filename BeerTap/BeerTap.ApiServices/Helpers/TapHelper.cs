using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BeerTap.Data;
using BeerTap.Model;

namespace BeerTap.ApiServices.Helpers
{
    public static class TapHelper
    {
        public static Tap GetById(int id, int officeId)
        {
            using (var db = new DataContext())
            {
                var tap = db.Taps.FirstOrDefault(x => x.Id == id && x.OfficeId == officeId);
                if (tap == null) return null;
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

        public static bool UpdateTapById(int id, int officeId, int volume)
        {
            using (var db = new DataContext())
            {
                var tap = db.Taps.FirstOrDefault(x => x.Id == id && x.OfficeId == officeId);
                if (tap == null) return false;
                tap.VolumeLeft -= volume;
                db.Entry(tap).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }

        public static bool ReplaceKeg(int tapId, int officeId, int kegId)
        {
            using (var db = new DataContext())
            {
                var tap = db.Taps.FirstOrDefault(x => x.Id == tapId && x.OfficeId == officeId);
                var keg = KegHelper.GetById(kegId);
                if (tap == null || keg == null) return false;
                tap.KegId = kegId;
                tap.VolumeLeft = keg.MaxCapacity;
                db.Entry(tap).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }

        private static KegState ChangeKegState(int volumeLeft, int kegMinimum, int kegMaximum)
        {
            var kegState = KegState.Dry;
            if (volumeLeft >= kegMaximum)
                kegState = KegState.New;
            else if (volumeLeft < kegMaximum && volumeLeft > kegMinimum)
                kegState = KegState.GoinDown;
            else if (volumeLeft <= kegMinimum && volumeLeft > 0)
                kegState = KegState.AlmostEmpty;
            return kegState;
        }
    }
}
