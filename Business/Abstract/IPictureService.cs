using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPictureService
    {
        IDataResult<List<Picture>> GetAllImagesByProductId(int ProductId);
        IDataResult<List<Picture>> GetAll();
        IDataResult<Picture> GetById(int pictureId);
        IResult Add(Picture picture);
        IResult Update(Picture picture);
        IResult Delete(Picture picture);
       
    }
}
