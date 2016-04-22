using BeerTap.Model.Interface;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.Model
{
    public class OfficeKeg : IIdentifiable<int>, IStatefulResource<KegState>, IStatefulKeg
    {
        public int Id { get; set; }

        public int OfficeId { get; set; }

        public int KegId { get; set; }

        public int KegContent { get; set; }

        public KegState KegState { get; set; }
    }
}
