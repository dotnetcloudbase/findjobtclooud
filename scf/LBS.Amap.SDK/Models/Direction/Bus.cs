using Newtonsoft.Json;
using System.Collections.Generic;

namespace LBS.Amap.SDK.Models.Direction
{
    public class Bus
    {
        [JsonProperty("buslines")]
        public ICollection<BusLine> BusLines { get; set; }
    }
}
