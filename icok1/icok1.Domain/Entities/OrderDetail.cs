using Newtonsoft.Json;

namespace icok1.Domain.Entities
{
    public class OrderDetail
    {
        //[JsonProperty(PropertyName = "OrderId")]
        //public int OrderId { get; set; }
        //[JsonProperty(PropertyName = "ProductId")] 
        //public int ProductId { get; set; }
        //[JsonProperty(PropertyName = "Order")]
        //public Order Order { get; set; }
        [JsonProperty(PropertyName = "Product")]
        public Product Product { get; set; }
        [JsonProperty(PropertyName = "Qty")]
        public int Qty { get; set; }
    }
}
