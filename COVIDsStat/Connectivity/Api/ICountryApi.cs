using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using COVIDsStat.Helpers;
using COVIDsStat.Models;
using Refit;

namespace COVIDsStat.Connectivity.Api
{
    public interface ICountryApi
    {
        [Get("/name/{country}")]
        Task<IEnumerable<CountryInfo>> GetCountryInfoAsync(string country);
    }
}
