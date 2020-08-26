using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_shoporderservices.Models
{
    public class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        [Obsolete]
        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("OrderDB");

            
        }

        public IEnumerable<Order> GetOrders()
        {
            return _db.GetCollection<Order>("Orders").FindAll();
        }


        public Order GetOrder(ObjectId id)
        {
            var res = Query<Order>.EQ(p => p.Id, id);
            return _db.GetCollection<Order>("Orders").FindOne(res);
        }

        public Order Create(Order order)
        {
            _db.GetCollection<Order>("Orders").Save(order);
            return order;
        }

    }
}
