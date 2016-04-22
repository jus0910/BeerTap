using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi.Services.Security;
using BeerTap.ApiServices.Security;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public class OfficeApiService : IOfficeApiService
    {

        readonly IApiUserProvider<BeerTapApiUser> _userProvider;

        public OfficeApiService(IApiUserProvider<BeerTapApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
        }


        public Task<Office> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var result = _mockOffices.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(result);
        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResourceCreationResult<Office, int>> CreateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Office> UpdateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<Office, int> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        #region Mock Data
        private List<Office> _mockOffices = new List<Office>()
        {
            new Office()
            {
                Id = 1,
                Name = "Vancouver",
                OfficeState = OfficeState.GetAvailableTap
            },
            new Office()
            {
                Id = 2,
                Name = "Regina",
                OfficeState = OfficeState.GetAvailableTap
            },
            new Office()
            {
                Id = 3,
                Name = "Winnipeg",
                OfficeState = OfficeState.GetAvailableTap
            },
            new Office()
            {
                Id = 4,
                Name = "Davidson",
                OfficeState = OfficeState.GetAvailableTap
            },
        };
        #endregion
    }
}
