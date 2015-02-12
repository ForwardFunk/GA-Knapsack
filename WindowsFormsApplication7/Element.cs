using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WindowsFormsApplication7
{
    class Element
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "weight")]
        public int Weight { get; set; }
        [JsonProperty(PropertyName = "value")]
        public int Value { get; set; }
    }
}
