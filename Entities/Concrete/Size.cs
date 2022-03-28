using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Size:IEntity
    {
        public int SizeId { get; set; }
        public string? SizeName { get; set; }
    }
}
