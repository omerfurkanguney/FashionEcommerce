using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BaseProduct:IEntity
    {
        public int BaseProductId { get; set; }
        public int SubCategoryId { get; set; }
        public int FitId { get; set; }
        public int GenderId { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? BasePic { get; set; }


    }
}
