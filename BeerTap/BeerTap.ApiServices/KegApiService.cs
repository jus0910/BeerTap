using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BeerTap.ApiServices.Security;
using BeerTap.Model;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace BeerTap.ApiServices
{
    class KegApiService : IKegApiService
    {
        readonly IApiUserProvider<BeerTapApiUser> _userProvider;

        public KegApiService(IApiUserProvider<BeerTapApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
        }

        public Task<Keg> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var result = _mockKegs.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(result);
        }

        public Task<IEnumerable<Keg>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var id =
                context.UriParameters.GetByName<int>("Kegs")
                    .EnsureValue(() => context.CreateHttpResponseException<Keg>("", HttpStatusCode.BadRequest));
            var result = _mockKegs.Where(x => x.Id == id);
            return Task.FromResult(result);
        }

        public Task<ResourceCreationResult<Keg, int>> CreateAsync(Keg resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Keg> UpdateAsync(Keg resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<Keg, int> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        #region Mock Data
        private List<Keg> _mockKegs = new List<Keg>()
        {
            new Keg()
            {
                Id = 1,
                MaxCapacity = 1000,
                Name = "Lager"
            },
            new Keg()
            {
                Id = 1,
                MaxCapacity = 1000,
                Name = "Ale"
            },
            new Keg()
            {
                Id = 1,
                MaxCapacity = 1000,
                Name = "Wheat"
            },
            new Keg()
            {
                Id = 1,
                MaxCapacity = 1000,
                Name = "Stout"
            },
        };
        #endregion  
    }
}
