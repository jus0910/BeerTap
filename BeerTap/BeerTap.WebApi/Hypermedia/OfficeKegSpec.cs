using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;

namespace BeerTap.WebApi.Hypermedia
{
    public class OfficeKegSpec : ResourceSpec<OfficeKeg, KegState, int>
    {
        public static ResourceUriTemplate OfficeKegUri = ResourceUriTemplate.Create("OfficeKegs({id})");

        public override string EntrypointRelation
        {
            //TODO: Update with proper link relation
            get { return LinkRelations.Offices.GetTap; }
        }

        protected override IEnumerable<IResourceStateSpec<OfficeKeg, KegState, int>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<OfficeKeg, KegState, int>(KegState.New)
            {
                Links =
                {
                    CreateLinkTemplate(EntrypointRelation, OfficeKegUri, o => o.Id)
                },
                Operations = new StateSpecOperationsSource<OfficeKeg, int>()
                {
                    Get = ServiceOperations.Get,
                    Post = ServiceOperations.Update,
                    InitialPost = ServiceOperations.Create,
                    Delete = ServiceOperations.Delete
                }
            };
        }
    }
}