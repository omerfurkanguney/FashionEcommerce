using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStatusService
    {
        IDataResult<List<Status>> GetAll();
        IDataResult<Status> GetById(int statusId);
        IResult Add(Status status); 
        IResult Update(Status status);  
        IResult Delete(Status status);
    }
}
