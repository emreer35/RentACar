using System;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory;

public class InMemoryCarDal : ICarDal
{
    List<Car> _cars;

    public InMemoryCarDal()
    {
        _cars = new List<Car>
        {
            new Car {Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 300, ModelYear = "2016", Description = "Fiat Egea Arabasi Guzel araba"},
            new Car {Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 244, ModelYear = "2012", Description = "Fiat Egea Cross Arabasi Guzel araba"},
            new Car {Id = 3, BrandId = 2, ColorId = 5, DailyPrice = 643, ModelYear = "2014", Description = "Bmw 1.16i Arabasi Guzel araba"},
            new Car {Id = 4, BrandId = 3, ColorId = 2, DailyPrice = 747, ModelYear = "2018", Description = "Mercedes CLA180 Arabasi Guzel araba"},
        };
    }

    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Delete(Car car)
    {
        var deleteCar = _cars.SingleOrDefault(c => c.Id == car.Id);
        _cars.Remove(deleteCar);
    }

    public Car Get(int id)
    {
        return _cars.FirstOrDefault(c => c.Id == id);
    }

    public Car Get(Expression<Func<Car, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<Car> GetAll()
    {
        return _cars;
    }

    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public List<CarDetailDto> GetCarDetails()
    {
        throw new NotImplementedException();
    }

    public void Update(Car car)
    {
        var updatedCar = _cars.SingleOrDefault(c => c.Id == car.Id);
        updatedCar.BrandId = car.BrandId;
        updatedCar.ColorId = car.ColorId;
        updatedCar.DailyPrice = car.DailyPrice;
        updatedCar.Description = car.Description;
        updatedCar.ModelYear = car.ModelYear;
    }
}
