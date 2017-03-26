using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalTestApp.Core
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
    }
}
