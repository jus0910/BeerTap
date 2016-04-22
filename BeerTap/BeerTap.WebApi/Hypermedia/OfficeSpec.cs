using System.Collections.Generic;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;

namespace BeerTap.WebApi.Hypermedia
{
    public class OfficeSpec : ResourceSpec<Office, OfficeState, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({id})");

        protected override IEnumerable<IResourceStateSpec<Office, OfficeState, int>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<Office, OfficeState, int>(OfficeState.GetAvailableTap)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Offices.GetTap, Uri.Many, o => o.Id)
                },
                Operations = new StateSpecOperationsSource<Office, int>()
                {
                    Get = ServiceOperations.Get
                }
            };
            yield return new ResourceStateSpec<Office, OfficeState, int>(OfficeState.ChangeKeg)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Offices.ChangeTap, Uri.Many, o => o.Id)
                },
                Operations = new StateSpecOperationsSource<Office, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete
                }
            };
        }

        public override string EntrypointRelation
        {
            get { return LinkRelations.Office; }
        }


        // IResourceStateSpec is not required but can be overridden to define custom operations and links.
        // See example below...
        //
        //public override IResourceStateSpec<Office, NullState, string> StateSpec
        //{
        //    get
        //    {
        //        return
        //            new SingleStateSpec<Office, string>
        //            {
        //                Links =
        //                {
        //                    CreateLinkTemplate(LinkRelations.SampleResource2, OrganizationSpec2.Uri, r => r.Id),
        //                },

        //                Operations =
        //                {
        //                    Get = ServiceOperations.Get,
        //                    InitialPost = ServiceOperations.Create,
        //                    Post = ServiceOperations.Update,
        //                    Delete = ServiceOperations.Delete,
        //                },
        //            };
        //    }
        //}

    }
}