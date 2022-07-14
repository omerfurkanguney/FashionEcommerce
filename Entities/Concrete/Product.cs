﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public int BaseProductId { get; set; }
        public int ColorId { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
    }
}
