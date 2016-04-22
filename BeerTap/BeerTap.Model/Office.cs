using System.Collections.Generic;
using BeerTap.Model.Interface;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.Model
{
    /// <summary>
    /// A Sample Resource, used as a placeholder. To be removed after real-world API resources have been added.
    /// </summary>
    public class Office : IIdentifiable<int>, IStatefulResource<OfficeState>, IStatefulOffice
    {
        /// <summary>
        /// Unique Identifier for the Office
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name for the Office
        /// </summary>
        public string Name { get; set; }

        public OfficeState OfficeState { get; set; }
    }
}
