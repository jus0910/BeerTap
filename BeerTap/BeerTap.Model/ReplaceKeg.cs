using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.Model
{
    public class ReplaceKeg : IIdentifiable<int>, IStatelessResource
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Keg Id of the Keg to be used
        /// </summary>
        public int KegId { get; set; }
    }
}
