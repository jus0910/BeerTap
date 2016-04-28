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
    public class NewGlassSpec : SingleStateResourceSpec<NewGlass, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/Taps({TapId})/NewGlass");

        public override string EntrypointRelation
        {
            get { return LinkRelations.Pour; }
        }

        protected override IEnumerable<ResourceLinkTemplate<NewGlass>> Links()
        {
            yield return CreateLinkTemplate<LinksParametersSource>(CommonLinkRelations.Self, Uri, x => x.Parameters.OfficeId, x => x.Parameters.BeerTapId);
        }

        public override IResourceStateSpec<NewGlass, NullState, int> StateSpec
        {
            get
            {
                return new SingleStateSpec<NewGlass, int>()
                {
                    Links =
                    {
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.BeerTap, TapSpec.Uri, o=>o.Parameters.OfficeId, o=>o.Parameters.BeerTapId),
                    },
                    Operations = new StateSpecOperationsSource<NewGlass, int>()
                    {
                        InitialPost = ServiceOperations.Create
                    }
                };
            }
        }
    }
}