using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarsonApp.Basket.Concrete.Models
{
    public class BasketModel
    {
        public int id { get; set; }
        public int ownerId { get; set; }
        public int productId { get; set; }
        public int piece { get; set; }
    }
}
