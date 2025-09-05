using System;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IRentalService
{
    IResult Add(Rental rental);
    IResult Update(Rental rental);
    IDataResult<List<Rental>> GetAll();
    
}
