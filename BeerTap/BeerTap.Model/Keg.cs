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
    public class Keg : IIdentifiable<int>, IStatelessResource
    {
        /// <summary>
        /// Unique identifier of the Keg
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Keg Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Metric Unit capacity of the keg in ml.
        /// </summary>
        public int MaxCapacity { get; set; }

        /// <summary>
        /// Almost Empty Trigger
        /// </summary>
        public int MinCapacity { get; set; }
    }
}
