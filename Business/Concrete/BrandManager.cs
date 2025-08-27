using System;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }

    public IResult Add(Brand brand)
    {
        _brandDal.Add(brand);
        return new SuccessResult(Messages.SuccessAdded);
    }

    public IResult Delete(Brand brand)
    {
        _brandDal.Delete(brand);
        return new SuccessResult(Messages.SuccessDeleted);
    }

    public IDataResult<Brand> Get(int id)
    {
        return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id));
    }

    public IDataResult<List<Brand>> GetAll()
    {
        return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
    }

    public IResult Update(Brand brand)
    {
        _brandDal.Update(brand);
        return new SuccessResult(Messages.SuccessUpdated);
    }
}
