﻿using Business.Abstract;
using Business.Constants;
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
    public class SizeManager : ISizeService
    {
        ISizeDal _sizeDal;

        public SizeManager(ISizeDal sizeDal)
        {
            _sizeDal = sizeDal;
        }
        public IResult Add(Size size)
        {
            _sizeDal.Add(size);
            return new SuccessResult(SizeMessages.SizeAdded);
        }

        public IResult Delete(int sizeId)
        {
            var result = _sizeDal.Get(s => s.SizeId == sizeId);
            _sizeDal.Delete(result);
            return new SuccessResult(SizeMessages.SizeDeleted);
        }

        public IDataResult<List<Size>> GetAll()
        {
            return new SuccessDataResult<List<Size>>(_sizeDal.GetAll(),SizeMessages.SizeListed);
        }

        public IDataResult<Size> GetById(int sizeId)
        {
            return new SuccessDataResult<Size>(_sizeDal.Get(s =>s.SizeId == sizeId));
        }

        public IResult Update(Size size)
        {
            _sizeDal.Update(size);
            return new SuccessResult(SizeMessages.SizeUpdated);
        }
    }
}