using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PropertyChanged;
namespace COVIDsStat.Models
{
    [AddINotifyPropertyChangedInterface]
    public class CountryStat
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("cases")]
        public string TotalCases { get; set; }

        [JsonProperty("todayCases")]
        public string NewCases { get; set; }

        [JsonProperty("deaths")]
        public string TotalDeaths { get; set; }

        [JsonProperty("todayDeaths")]
        public string NewDeaths { get; set; }

        [JsonProperty("recovered")]
        public int? TotalRecovered { get; set; }

        [JsonProperty("active")]
        public int? ActiveCases { get; set; }

        [JsonProperty("critical")]
        public int SeriousCritical { get; set; }

        [JsonProperty("casesPerOneMillion")]
        public int TotCasesx1Mpop { get; set; }

        [JsonProperty("deathsPerOneMillion")]
        public int TotDeathx1Mpop { get; set; }

        [JsonProperty("totalTests")]
        public int TotalTests { get; set; }

        public CountryInfo CountryInfo { get; set; }

        public string Flag => string.IsNullOrEmpty(CountryInfo?.flag) ? "placeholder" : CountryInfo?.flag;
        public string StrCountry => Country.Replace("\n", "");
    }
}