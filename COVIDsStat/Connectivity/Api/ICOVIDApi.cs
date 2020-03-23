using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using COVIDsStat.Helpers;
using COVIDsStat.Models;
using Refit;

namespace COVIDsStat.Connectivity.Api
{
    [Url(Constants.BaseApiUrl)]
    public interface ICOVIDApi
    {
        //The GET param is empty because we are using a temporary API Url dirict to the json file.
        [Get("covid?fbclid=IwAR10zGzI9LthniBRe9ooCNLjDRgbnZaVsERSn93cJTBcCZRKgYPqqh8shLU")]
        Task<IEnumerable<COVID>> GetCountriesStatisticsAsync();
    }
}
