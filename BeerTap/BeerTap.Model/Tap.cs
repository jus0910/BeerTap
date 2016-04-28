using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTap.Model.Interface;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.Model
{
    public class Tap : IIdentifiable<int>, IStatefulResource<KegState>, IStatefulKeg
    {
        public int Id { get; set; }

        public int OfficeId { get; set; }

        public Keg Keg { get; set; }

        public KegState KegState { get; set; }

        public int VolumeLeft { get; set; }
    }
}
