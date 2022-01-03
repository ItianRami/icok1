using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace icok1.Domain.Entities
{
    public class Order : BaseEntity
    {
        [JsonProperty(PropertyName = "CustomerId")]
        public string CustomerId { get; set; }
        [JsonProperty(PropertyName = "OrderDate")]
        public DateTime OrderDate { get; set; }
        [JsonProperty(PropertyName = "OrderDetails")]
        public List<OrderDetail> OrderDetails { get; set; }
        //[JsonProperty(PropertyName = "PaymentTransactionId")]
        //public int PaymentTransactionId { get; set; }
        [JsonProperty(PropertyName = "PaymentTransaction")]
        public PaymentTransaction PaymentTransaction { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
