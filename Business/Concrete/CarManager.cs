using System;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class CarManager : ICarService
{
    ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }

    public IResult Add(Car car)
    {
        var name = car.CarName.Trim();
        if (string.IsNullOrWhiteSpace(car.CarName) || name.Length < 3)
        {
            return new ErrorResult(Messages.CarNameValidation);
        }
        if (car.DailyPrice < 0)
        {
            return new ErrorResult(Messages.PriceNotUnderZero);
        }
        _carDal.Add(car);
        return new SuccessResult(Messages.SuccessAdded);
    }

    public IDataResult<Car> Get(int id)
    {
        return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
    }

    public IDataResult<List<Car>> GetAll()
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll());
    }

    public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == brandId).ToList());
    }

    public IDataResult<List<Car>> GetCarsByColorId(int colorId)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId).ToList());
    }
    public IResult Update(Car car)
    {
        _carDal.Update(car);
        return new SuccessResult(Messages.SuccessUpdated);
    }
    public IResult Delete(Car car)
    {
        _carDal.Delete(car);
        return new SuccessResult(Messages.SuccessDeleted);
    }

    public IDataResult<List<CarDetailDto>> GetCarDetails()
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
    }
}
