using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.Concrete.Models
{
    public class SubCategory
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }
    }
}
