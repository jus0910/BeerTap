using System.Collections.Generic;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.WebApi.Hypermedia
{
    public class KegSpec : SingleStateResourceSpec<Keg, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Kegs({id})");

        public override string EntrypointRelation
        {
            get { return LinkRelations.Keg; }
        }

        protected override IEnumerable<ResourceLinkTemplate<Keg>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.Id);
        }

        public override IResourceStateSpec<Keg, NullState, int> StateSpec
        {
            get
            {
                return new SingleStateSpec<Keg, int>()
                {
                    Links =
                    {
                        CreateLinkTemplate(EntrypointRelation, Uri, k => k.Id)
                    },
                    Operations = new StateSpecOperationsSource<Keg, int>()
                    {
                        Get = ServiceOperations.Get,
                    }
                };
            }
        }
    }
}