using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.Model
{
    public class NewGlass : IIdentifiable<int>, IStatelessResource
    {
        public int Id { get; }

        public int Capacity { get; set; }
    }
}
