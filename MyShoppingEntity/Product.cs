using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppingEntity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public static implicit operator Task<object>(Product v)
        {
            throw new NotImplementedException();
        }
    }
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        public string SalesDate { get; set; }
        [ForeignKey("product")]
        public int ProductID { get; set; }
        public Product? product { get; set; }

    }
        public class MongoDbConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
