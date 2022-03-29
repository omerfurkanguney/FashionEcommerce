using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class AdminClaim:IEntity
    {
        public int AdminClaimId { get; set; }
        public int AdminId { get; set; }
        public int ClaimId { get; set; }
    }
}
