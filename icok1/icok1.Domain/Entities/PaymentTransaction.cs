using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace icok1.Domain.Entities
{
    public class PaymentTransaction //: BaseEntity
    {
        //[JsonProperty(PropertyName = "OrderId")]
        //public int OrderId { get; set; }
        //[JsonProperty(PropertyName = "Order")]
        //public Order Order { get; set; }
        [JsonProperty(PropertyName = "Total")]
        [Column(TypeName = "money")]
        public decimal Total { get; set; }
        [JsonProperty(PropertyName = "Completed")]
        public bool IsComplete { get; set; }
    }
}
