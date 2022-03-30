using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User:IEntity
    {
        public int UserId { get; set; }
        public int UserNo { get; set; }
        public DateTime RegisterDate { get; set; }
        public Customer customer { get; set; }

    }
}
