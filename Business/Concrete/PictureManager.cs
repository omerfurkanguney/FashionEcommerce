using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PictureManager : IPictureService
    {
        IPictureDal _pictureDal;
        public PictureManager(IPictureDal pictureDal)
        {
            _pictureDal = pictureDal;
        }
        public IResult Add(Picture picture)
        {
            var results = BusinessRules.Run(CheckIfImageCount(picture.ProductId));
            if (results != null)
            {
                return results;
            }
            var addedImage = CreatedFile(picture).Data;
            _pictureDal.Add(picture);
            return new SuccessResult();
        }


        //public IResult Delete(CarImage carImage)
        //{
        //    IResult result = BusinessRules.Run(CheckIfDeleteImage(carImage));
        //    if (result != null)
        //    {
        //        return result;
        //    }
        //    _carImageDal.Delete(carImage);
        //    return new SuccessResult();
        //}

        public IDataResult<List<Picture>> GetAll()
        {
            return new SuccessDataResult<List<Picture>>(_pictureDal.GetAll());

        }

        public IDataResult<List<Picture>> GetAllImagesByProductId(int ProductId)
        {
            return new SuccessDataResult<List<Picture>>(CheckIfDefaultImages(ProductId));

        }

        public IDataResult<Picture> GetById(int Id)
        {
            return new SuccessDataResult<Picture>(_pictureDal.Get(p => p.PictureId == Id));//ProductId ye göre getirme lazım olabilir.

        }

        public IResult Update(Picture picture)
        {
            var updatedCarImage = UpdatedFile(picture).Data;
            _pictureDal.Update(picture);
            return new SuccessResult("Image updated");
        }

        private IResult CheckIfDeleteImage(Picture picture)
        {
            try
            {
                File.Delete(picture.PicturePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        private List<Picture> CheckIfDefaultImages(int pictureId)
        {
            var DefaultPath = AppDomain.CurrentDomain.BaseDirectory + "C:\\Users\\omerg\\OneDrive\\Resimler\\walpapers";
            //değiştir

            var result = _pictureDal.GetAll(p => p.ProductId == pictureId).Any();
            if (!result)
            {
                return new List<Picture> { new Picture { ProductId = pictureId, PicturePath = DefaultPath} };
            }
            return _pictureDal.GetAll(p => p.ProductId == pictureId);
        }

        private IResult CheckIfImageCount(int ProductId)
        {
            var result = _pictureDal.GetAll(p => p.ProductId == ProductId);
            if (result.Count >= 5)
            {
                return new ErrorResult("bu araca ait 5 ten fazla resim olamaz.");

            }
            return new SuccessResult();
        }

        private IDataResult<Picture> CreatedFile(Picture picture)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Image");
            var uniqueFilename = Guid.NewGuid().ToString("N")
                + "CAR-" + picture.ProductId ;

            string source = Path.Combine(picture.PicturePath);

            string result = $@"{path}\{uniqueFilename}";

            try
            {

                File.Move(source, path + @"\" + uniqueFilename);
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<Picture>(exception.Message);
            }

            return new SuccessDataResult<Picture>(new Picture { PictureId = picture.PictureId, ProductId = picture.ProductId, PicturePath = result}, "resim eklendi");
        }
        public IDataResult<Picture> UpdatedFile(Picture picture)
        {
            var uniqueFilename = Guid.NewGuid().ToString("N")
               + "CAR-" + picture.ProductId ;

            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            string result = $"{path}\\{uniqueFilename}";

            File.Copy(picture.PicturePath, path + "\\" + uniqueFilename);
            File.Delete(picture.PicturePath);

            return new SuccessDataResult<Picture>(new Picture { PictureId = picture.PictureId, ProductId = picture.ProductId, PicturePath = result});

        }

        public IResult Delete(int id)
        {
            var result = _pictureDal.Get(f => f.PictureId == id);
            _pictureDal.Delete(result);
            return new SuccessResult(ProductMessages.ProductDeleted);
        }

        public IResult Delete(Picture picture)
        {
            throw new NotImplementedException();
        }
    }
}
