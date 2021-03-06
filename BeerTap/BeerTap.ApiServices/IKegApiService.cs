﻿using BeerTap.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public interface IKegApiService :
        IGetAResourceAsync<Keg, int>,
        IGetManyOfAResourceAsync<Keg, int>
    {
        
    }
}