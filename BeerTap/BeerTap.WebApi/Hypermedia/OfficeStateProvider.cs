using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.OData;
using BeerTap.Model;
using BeerTap.Model.Interface;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.WebApi.Hypermedia
{
    public class OfficeStateProvider<TOfficeResource> : ResourceStateProviderBase<TOfficeResource, OfficeState>
        where TOfficeResource : IStatefulResource<OfficeState>, IStatefulOffice
    {
        public override OfficeState GetFor(TOfficeResource resource)
        {
            return resource.OfficeState;
        }

        protected override IDictionary<OfficeState, IEnumerable<OfficeState>> GetTransitions()
        {
            return new Dictionary<OfficeState, IEnumerable<OfficeState>>()
            {
                {
                    OfficeState.GetAvailableTap, new []
                    {
                        OfficeState.ChangeKeg, 
                    }
                }
            };
        }

        public override IEnumerable<OfficeState> All
        {
            get { return EnumEx.GetValuesFor<OfficeState>(); }
        }
    }
}