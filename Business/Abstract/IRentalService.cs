using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IRentalService
    {
        IResult Add(Rental rental);
        bool CheckCarIsAvailable(int carId);
        IResult Return(int carId);
        IDataResult<List<Rental>> GetAll();
    }
}
