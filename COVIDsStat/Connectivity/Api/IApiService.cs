using System;
namespace COVIDsStat.Connectivity.Api
{
    public interface IApiService
    {
        ICOVIDApi COVIDApi { get; set; }
    }
}
