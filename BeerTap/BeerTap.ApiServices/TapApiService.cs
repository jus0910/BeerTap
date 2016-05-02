using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeerTap.ApiServices.Helpers;
using BeerTap.ApiServices.Security;
using BeerTap.Model;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace BeerTap.ApiServices
{
    public class TapApiService : IBeerTapApiService
    {
        readonly IApiUserProvider<BeerTapApiUser> _userProvider;

        public TapApiService(IApiUserProvider<BeerTapApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
        }

        public Task<IEnumerable<Tap>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeId")
                .EnsureValue(() => context.CreateHttpResponseException<Office>("Office Id must be supplied in the URL", HttpStatusCode.BadRequest));
            var taps = TapHelper.GetAllTapByOfficeId(officeId);
            return Task.FromResult(taps);
        }

        public Task<Tap> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeId")
                .EnsureValue(() => context.CreateHttpResponseException<Office>("Office Id must be supplied in the URL", HttpStatusCode.BadRequest));
            var tap = TapHelper.GetById(id, officeId);
            return Task.FromResult(tap);
        }
    }
}
