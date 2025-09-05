using System;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class RentalManager : IRentalService
{
    IRentalDal _rentalDal;
    public RentalManager(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;
    }
    public IResult Add(Rental rental)
    {
        // herhangi bir kiralama var mi aracta 
        var activeCar = _rentalDal.GetAll(c => c.CarId == rental.CarId && c.ReturnDate == null).Any();
        if (activeCar)
        {
            return new ErrorResult(Messages.ActiveCar);
        }
        if (rental.RentDate == default)
        {
            rental.RentDate = DateTime.Now;
        }

        rental.ReturnDate = null;

        _rentalDal.Add(rental);
        return new SuccessResult(Messages.RentCar);
    }

    public IDataResult<List<Rental>> GetAll()
    {
        return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
    }

    public IResult Update(Rental rental)
    {
        var activeRental = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null)
                                  .FirstOrDefault();
        if (activeRental == null)
        {
            return new ErrorResult(Messages.HasNotActiveCar);

        }
        activeRental.ReturnDate = DateTime.Now;
        _rentalDal.Update(activeRental);
        return new SuccessResult(Messages.OffCar);
    }
}
