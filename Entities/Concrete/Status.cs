using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Status:IEntity
    {
        public int StatusId { get; set; }
        public string? OrderStatus { get; set; }
    }
}
