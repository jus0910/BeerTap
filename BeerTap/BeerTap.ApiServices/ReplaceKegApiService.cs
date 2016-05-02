using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using BeerTap.ApiServices.Helpers;
using BeerTap.ApiServices.Security;
using BeerTap.Model;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace BeerTap.ApiServices
{
    public class ReplaceKegApiService :
        ICreateAResourceAsync<ReplaceKeg, int>
    {
        readonly IApiUserProvider<BeerTapApiUser> _userProvider;

        public ReplaceKegApiService(IApiUserProvider<BeerTapApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
        }

        public Task<ResourceCreationResult<ReplaceKeg, int>> CreateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            try
            {
                var officeId = context.UriParameters.GetByName<int>("OfficeId")
                            .EnsureValue(() => context.CreateHttpResponseException<Office>("Office Id must be supplied in the URL", HttpStatusCode.BadRequest));
                var tapId = context.UriParameters.GetByName<int>("TapId")
                    .EnsureValue(() => context.CreateHttpResponseException<Tap>("Tap Id must be supplied in the URL", HttpStatusCode.BadRequest));
                context.LinkParameters.Set(new LinksParametersSource(officeId, tapId));

                TapHelper.ReplaceKeg(tapId, officeId, resource.KegId);
                return Task.FromResult(new ResourceCreationResult<ReplaceKeg, int>(resource));
            }
            catch (Exception ex)
            {
                throw context.CreateHttpResponseException<NewGlass>(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
