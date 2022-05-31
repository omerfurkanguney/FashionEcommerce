using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Picture:IEntity
    {
        public int PictureId { get; set; }
        public int ProductId { get; set; }
        public string? PicturePath { get; set; }
    }
}
