using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Stock:IEntity
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int StockQuantity { get; set; }
    }
}
