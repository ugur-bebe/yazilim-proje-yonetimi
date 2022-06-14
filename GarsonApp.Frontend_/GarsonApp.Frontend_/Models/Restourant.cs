using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarsonApp.Frontend.Models
{
    public class Restourant
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string RestourantName { get; set; }
        public string RestourantDescription { get; set; }
        public bool OrderHome { get; set; }
        public bool OrderTable { get; set; }
        public int MinOrderPrice { get; set; }
    }
}
