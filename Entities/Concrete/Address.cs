using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Address:IEntity
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public int CountyId { get; set; }
        public string? AddressName { get; set; }
        public string? Phone { get; set; }
    }
}
