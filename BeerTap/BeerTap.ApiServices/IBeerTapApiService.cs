using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public interface IBeerTapApiService : 
        IGetManyOfAResourceAsync<Model.Tap, int>,
        IGetAResourceAsync<Model.Tap, int>
    {
        
    }
}