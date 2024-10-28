using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalMenager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalMenager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        

        public bool CheckCarIsAvailable(int carId)
        {
           var currentCar =_rentalDal.Get(c => c.CarId == carId);
            if (currentCar == null)
                return true;

            return false;

        }

        public IDataResult<List<Rental>> GetAll()
        {
           return new SuccessDataResult<List<Rental>>(_rentalDal.GetList(null));
        }

        public IResult Return(int carId)
        {
            var returnCar = _rentalDal.Get(c => c.CarId == carId);
            if (returnCar != null)
            {
                _rentalDal.Delete(returnCar);
                return new SuccessResult("Car is returned");
            }
            return new ErrorResult($"not found rented car with id: {carId}");

        }
    }
}
