using System;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IBrandService
{
    IResult Add(Brand brand);
    IDataResult<List<Brand>> GetAll();
    IDataResult<Brand> Get(int id);
    IResult Update(Brand brand);
    IResult Delete(Brand brand);
}
