using System;
using Entities.Concrete;

namespace Business.Abstract;

public interface IBrandService
{
    void Add(Brand brand);
    List<Brand> GetAll();
    Brand Get(int id);
    void Update(Brand brand);
    void Delete(Brand brand);
}
