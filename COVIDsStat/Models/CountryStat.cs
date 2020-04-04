using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PropertyChanged;
namespace COVIDsStat.Models
{
    [AddINotifyPropertyChangedInterface]
    public class CountryStat
    {
        public string Country { get; set; }
        public string TotalCases { get; set; }
        public string NewCases { get; set; }
        public string TotalDeaths { get; set; }
        public string NewDeaths { get; set; }
        public string TotalRecovered { get; set; }
        public string ActiveCases { get; set; }
        public string SeriousCritical { get; set; }
        public string TotCasesx1Mpop { get; set; }
        public CountryInfo CountryInfo { get; set; }

        public string Flag => CountryInfo?.flag;

    }
}
