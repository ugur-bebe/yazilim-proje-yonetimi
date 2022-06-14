using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.Concrete
{
    public class Product
    {
        public int id { get; set; }

        public string name { get; set; }

        public double price { get; set; }

        public string imageId { get; set; }

        public int restourantId { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public int typeId { get; set; }
    }
}
