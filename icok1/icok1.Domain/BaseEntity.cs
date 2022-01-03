using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace icok1.Domain
{
    public class BaseEntity
    {
        [JsonProperty(PropertyName = "id")]
        //[Key]
        public string Id { get; set; }
    }
}
