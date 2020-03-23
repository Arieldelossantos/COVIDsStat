using System;
namespace COVIDsStat.Models
{
    public class COVID
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
    }
}
