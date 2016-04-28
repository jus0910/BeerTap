﻿using BeerTap.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public interface IOfficeApiService :
        IGetAResourceAsync<Office, int>,
        IGetManyOfAResourceAsync<Office, int>
    {
    }
}
