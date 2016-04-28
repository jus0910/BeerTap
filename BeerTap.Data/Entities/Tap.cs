using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTap.Data.Entities
{
    public class Tap 
    {
        public Tap()
        {
        }

        public Tap(int id, int officeId, int kegId, int volumeLeft)
        {
            Id = id;
            OfficeId = officeId;
            KegId = kegId;
            VolumeLeft = volumeLeft;
        }
        [Key]
        public int Id { get; set; }
        public int OfficeId { get; set; }
        public int KegId { get; set; }
        public int VolumeLeft { get; set; }
    }
}
