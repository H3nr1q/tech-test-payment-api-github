using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payment_api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? SaleId {get;}

        public Product(int id, string description, decimal price)
        {
            Id = id;
            Description = description;
            Price = price;
        }
    }
}