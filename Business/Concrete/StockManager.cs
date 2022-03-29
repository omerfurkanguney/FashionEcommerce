using Business.Abstract;
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
    public class StockManager : IStockService
    {
        IStockDal _stockDal;
        public StockManager(IStockDal stockDal)
        {
            _stockDal = stockDal;
        }
        public IResult Add(Stock stock)
        {
            _stockDal.Add(stock);
            return new SuccessResult(StockMessages.StockAdded);
        }

        public IResult Delete(Stock stock)
        {
            _stockDal.Delete(stock);
            return new SuccessResult(StockMessages.StockDeleted);
        }

        public IDataResult<List<Stock>> GetAll()
        {
            return new SuccessDataResult<List<Stock>>(_stockDal.GetAll(), StockMessages.StockListed);
        }

        public IDataResult<Stock> GetById(int stockId)
        {
            return new SuccessDataResult<Stock>(_stockDal.Get(s => s.StockId == stockId), StockMessages.StockListed);
        }

        public IResult Update(Stock stock)
        {
            _stockDal.Update(stock);
            return new SuccessResult(StockMessages.StockUpdated);
        }
    }
}
