using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Common.Models.Response.TaxJar
{
    public class TaxJarError
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("status")]
        public string StatusCode { get; set; }
    }
}
