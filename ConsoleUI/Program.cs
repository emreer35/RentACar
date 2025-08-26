
using Business.Concrete;
using Core.Entities;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

// AddBrand();
// CarTest();
// InMemory();
// AddColor();

Car car1 = new Car
{
    Id=1,
    BrandId = 1,
    ColorId = 1,
    CarName = "BMW",
    ModelYear = "2001",
    DailyPrice = 11,
    Description = "Model Olarak Guzel Araba"
};
    CarManager carManager = new CarManager(new EfCarDal());
// carManager.Add(car1);
// carManager.Update(car1);
carManager.Delete(car1);

static void InMemory()
{
    CarManager carManager = new CarManager(new EfCarDal());

    foreach (var car in carManager.GetAll())
    {
        System.Console.WriteLine(car.Description);
    }
}

static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    foreach (var item in carManager.GetCarsByBrandId(1))
    {
        System.Console.WriteLine(item);
    }
}

static void AddBrand()
{
    Brand brand1 = new Brand { Name = "Sedan" };
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    brandManager.Add(brand1);
}

static void AddColor()
{
    Color color1 = new Color { Name = "Kirmizi" };
    ColorManager colorManager = new ColorManager(new EfColorDal());
    colorManager.Add(color1);
}