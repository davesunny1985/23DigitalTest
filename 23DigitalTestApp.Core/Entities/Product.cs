using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalTestApp.Core.Entities
{
    public class Product:IEntityBase
    {

        public Product()
        {
            
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime ExpiryDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
