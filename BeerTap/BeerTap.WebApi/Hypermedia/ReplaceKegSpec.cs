using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTap.ApiServices;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.WebApi.Hypermedia
{
    public class ReplaceKegSpec : SingleStateResourceSpec<ReplaceKeg, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/Taps({TapId})/ReplaceKeg");

        public override string EntrypointRelation
        {
            get { return LinkRelations.ChangeKeg; }
        }

        protected override IEnumerable<ResourceLinkTemplate<ReplaceKeg>> Links()
        {
            yield return CreateLinkTemplate<LinksParametersSource>(CommonLinkRelations.Self, Uri, o=>o.Parameters.OfficeId, o=>o.Parameters.BeerTapId);
        }

        public override IResourceStateSpec<ReplaceKeg, NullState, int> StateSpec
        {
            get
            {
                return new SingleStateSpec<ReplaceKeg, int>()
                {
                    Links =
                    {
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.BeerTap, TapSpec.Uri, o=>o.Parameters.OfficeId, o=>o.Parameters.BeerTapId)
                    },
                    Operations = new StateSpecOperationsSource<ReplaceKeg, int>()
                    {
                        InitialPost = ServiceOperations.Create
                    }
                };
            }
        }
    }
}