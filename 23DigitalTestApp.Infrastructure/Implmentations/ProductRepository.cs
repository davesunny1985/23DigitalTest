using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalTestApp.Core.Entities;
using DigitalTestApp.Infrastructure.Interfaces;

namespace DigitalTestApp.Infrastructure.Implmentations
{
    public class ProductRepository : EntityBaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DigitalTestAppContext context)
            : base(context)
        { }
    }
}
