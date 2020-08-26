using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_shoporderservices.Models
{
    public class Order
    {
        public ObjectId Id { get; set; }
        [BsonElement("OrderId")]
        public long OrderId { get; set; }
        [BsonElement("ShippingAddress")]

        public string ShippingAddress { get; set; }
        [BsonElement("DeliveryDate")]

        public DateTime DeliveryDate { get; set; }
        [BsonElement("Amount")]

        public long Amount { get; set; }
    }
}
