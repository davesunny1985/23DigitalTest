using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalTestApp.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime ExpiryDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
