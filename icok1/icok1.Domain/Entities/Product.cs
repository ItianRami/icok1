using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace icok1.Domain.Entities
{
    public class Product : BaseEntity
    {
        [JsonProperty(PropertyName = "ProductName")]
        public string ProductName { get; set; }
        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; } //cup|cone
        [JsonProperty(PropertyName = "Size")]
        public string Size{ get; set; } //small|medium|large
        [JsonProperty(PropertyName = "UnitPrice")]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

    }
}
