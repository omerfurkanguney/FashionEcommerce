using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class AdminOperationClaim:IEntity
    {
        [Key]
        public int ClaimId { get; set; }
        public string? ClaimName { get; set; }
    }
}
