using System;
using Business.Abstract;
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

    public void Add(Car car)
    {
        var name = car.CarName.Trim();
        if (string.IsNullOrWhiteSpace(car.CarName) || name.Length < 3)
        {
            System.Console.WriteLine("Arac ismi minimum 2 karakter olmasi gerekiyor");
            return;
        }
        if (car.DailyPrice < 0)
        {
            System.Console.WriteLine("Arac fiyati 0 in altinda olmamalidir");
            return;
        }
        _carDal.Add(car);
    }

    public Car Get(int id)
    {
        return _carDal.Get(c => c.Id == id);
    }

    public List<Car> GetAll()
    {
        return _carDal.GetAll();
    }

    public List<Car> GetCarsByBrandId(int brandId)
    {
        return _carDal.GetAll(b => b.BrandId == brandId).ToList();
    }

    public List<Car> GetCarsByColorId(int colorId)
    {
        return _carDal.GetAll(c => c.ColorId == colorId).ToList();
    }
    public void Update(Car car)
    {
        _carDal.Update(car);
    }
    public void Delete(Car car)
    {
        _carDal.Delete(car);
    }

    public List<CarDetailDto> GetCarDetails()
    {
        return _carDal.GetCarDetails();
    }
}
