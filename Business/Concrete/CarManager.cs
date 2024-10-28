using Business.Abstract;
using Business.BusınessAspect.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.ValidationAspect;
using Core.Utilities;
using Core.Utilities.Aspects.Autofac.Performance;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace Business.Concrete
{

    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator), Priority = 1)]

        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult("success");
               
        }
        public IDataResult<List<CarDetailsDto>> CarDetail()
        {
            if(DateTime.Now.Hour > 14)
            {
                return new ErrorDataResult<List<CarDetailsDto>>(null,"maintenance time");
            }
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(),"success");
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("succes");
        }
        //[PerformanceAspect(5)]
       // [SecuredOperation("car.list")]

        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter)
        {


            return new SuccessDataResult<List<Car>>(_carDal.GetList(),"success");
        }

        public IDataResult<Car> GetById(int id)
        {
            
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id==id),"success");

        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("success");
        }
    }
}
