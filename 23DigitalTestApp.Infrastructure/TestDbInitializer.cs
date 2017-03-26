using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalTestApp.Core.Entities;

namespace DigitalTestApp.Infrastructure
{
    public class TestDbInitializer
    {
        private static DigitalTestAppContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (DigitalTestAppContext)serviceProvider.GetService(typeof(DigitalTestAppContext));
            SeedProduct();
        }

        public static void SeedProduct()
        {
            if (context.Products.Where(item => item.Name.ToLower() == "product 1").Count() == 0)
            {
                context.Products.Add(new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 1",
                    ExpiryDate = DateTime.Now.AddYears(1)
                });
            }

            if (context.Products.Where(item => item.Name.ToLower() == "product 2").Count() == 0)
            {
                context.Products.Add(new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 2",
                    ExpiryDate = DateTime.Now.AddYears(2)
                });
            }
            context.SaveChanges();
        }
    }
}
