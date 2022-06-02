using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public int BaseProductId { get; set; }
        public string? FitName { get; set; }
        public string? GenderName { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? ColorName { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
    }
}
