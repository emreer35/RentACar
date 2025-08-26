using System;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface ICarService
{
    Car Get(int id);
    List<Car> GetAll();
    List<Car> GetCarsByBrandId(int brandId);
    List<Car> GetCarsByColorId(int colorId);
    void Add(Car car);
    void Update(Car car);
    void Delete(Car car);

    List<CarDetailDto> GetCarDetails();
}
