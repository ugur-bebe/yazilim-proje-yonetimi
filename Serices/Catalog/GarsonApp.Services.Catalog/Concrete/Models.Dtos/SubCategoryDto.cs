using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarsonApp.Services.Catalog.Concrete
{
    public class SubCategoryDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Category category { get; set; }
    }
}
