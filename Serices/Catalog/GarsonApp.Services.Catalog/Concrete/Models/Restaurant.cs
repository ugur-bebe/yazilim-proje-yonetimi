using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.Concrete.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string RestourantName { get; set; }
        public string RestourantDescription { get; set; }
        public bool OrderTable { get; set; }
        public bool OrderHome { get; set; }
        public int minOrderPrice { get; set; }
    }
}
