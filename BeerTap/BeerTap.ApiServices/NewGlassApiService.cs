using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using BeerTap.ApiServices.Helpers;
using BeerTap.Model;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public class NewGlassApiService : 
        ICreateAResourceAsync<NewGlass, int>
    {
        public Task<ResourceCreationResult<NewGlass, int>> CreateAsync(NewGlass resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeId")
                .EnsureValue(() => context.CreateHttpResponseException<Office>("Office Id must be supplied in the URL", HttpStatusCode.BadRequest));
            var tapId = context.UriParameters.GetByName<int>("TapId")
                .EnsureValue(() => context.CreateHttpResponseException<Tap>("Tap Id must be supplied in the URL", HttpStatusCode.BadRequest));
            context.LinkParameters.Set(new LinksParametersSource(officeId, tapId));

            if(TapHelper.UpdateTapById(tapId, officeId, resource.Capacity))
                return Task.FromResult(new ResourceCreationResult<NewGlass, int>(resource));
            throw new HttpException("Must supply valid Office and Tap IDs");
        }
    }
}
