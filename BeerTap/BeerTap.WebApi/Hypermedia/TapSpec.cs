using System.Collections.Generic;
using BeerTap.ApiServices;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.WebApi.Hypermedia
{
    public class TapSpec : ResourceSpec<Model.Tap, KegState, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/Taps({Id})");

        public override string EntrypointRelation
        {
            get { return LinkRelations.BeerTap; }
        }

        protected override IEnumerable<ResourceLinkTemplate<Tap>> Links()
        {
            yield return
                CreateLinkTemplate(CommonLinkRelations.Self, Uri, o => o.OfficeId, o=>o.Id);
        }

        protected override IEnumerable<IResourceStateSpec<Tap, KegState, int>> GetStateSpecs()
        {
            
            yield return new ResourceStateSpec<Tap, KegState, int>(KegState.New)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Pour, NewGlassSpec.Uri,  o => o.OfficeId, o => o.Id),
                    CreateLinkTemplate(LinkRelations.Office, OfficeSpec.Uri, x=>x.OfficeId),
                },
                Operations = new StateSpecOperationsSource<Model.Tap, int>()
                {
                    Get = ServiceOperations.Get
                }
            };

            yield return new ResourceStateSpec<Model.Tap, KegState, int>(KegState.GoinDown)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Office, OfficeSpec.Uri, x=>x.OfficeId),
                    CreateLinkTemplate(LinkRelations.Pour, NewGlassSpec.Uri,  o => o.OfficeId, o => o.Id),
                },
                Operations = new StateSpecOperationsSource<Model.Tap, int>()
                {
                    Get = ServiceOperations.Get
                }
            };

            yield return new ResourceStateSpec<Model.Tap, KegState, int>(KegState.AlmostEmpty)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Office, OfficeSpec.Uri, x=>x.OfficeId),
                    CreateLinkTemplate(LinkRelations.Pour, NewGlassSpec.Uri,  o => o.OfficeId, o => o.Id),
                    CreateLinkTemplate(LinkRelations.ChangeKeg, ReplaceKegSpec.Uri, o=>o.OfficeId, o=>o.Id)
                },
                Operations = new StateSpecOperationsSource<Model.Tap, int>()
                {
                    Get = ServiceOperations.Get
                }
            };

            yield return new ResourceStateSpec<Tap, KegState, int>(KegState.Dry)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Office, OfficeSpec.Uri, x=>x.OfficeId),
                    CreateLinkTemplate(LinkRelations.ChangeKeg, ReplaceKegSpec.Uri, o=>o.OfficeId, o=>o.Id)
                },
                Operations = new StateSpecOperationsSource<Model.Tap, int>()
                {
                    Get = ServiceOperations.Get
                }
            };
        }
    }
}