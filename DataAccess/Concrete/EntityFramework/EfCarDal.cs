using System;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal : EfEntityRepositoryBase<Car, CarRenting>, ICarDal
{
    public List<CarDetailDto> GetCarDetails()
    {
        using (CarRenting context = new CarRenting())
        {
            var result = context.Cars.Join(
                context.Brands,
                car => car.BrandId,
                brand => brand.Id,
                (car, brand) => new { car, brand }
            ).Join(
                context.Colors,
                cb => cb.car.ColorId,
                color => color.Id,
                (cb, color) => new CarDetailDto
                {
                    CarName = cb.car.CarName,
                    BrandName = cb.brand.Name,
                    ColorName = color.Name,
                    DailyPrice = cb.car.DailyPrice
                }).ToList();
            return result;
        }
    }
}
