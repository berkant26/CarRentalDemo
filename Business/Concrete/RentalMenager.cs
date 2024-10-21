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
        public RentalMenager()
        {

        }
        

        public IResult Add(Rental renral)
        {
            throw new NotImplementedException();
        }
    }
}
