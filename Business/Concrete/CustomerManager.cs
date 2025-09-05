using System;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class CustomerManager : ICustomerService
{
    ICustomerDal _customerDal;

    public CustomerManager(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }

    public IResult Add(Customer customer)
    {
        _customerDal.Add(customer);
        return new SuccessResult(Messages.SuccessAdded);
    }

    public IResult Delete(Customer customer)
    {
        _customerDal.Delete(customer);
        return new SuccessResult(Messages.SuccessDeleted);
    }

    public IDataResult<Customer> Get(int customerId)
    {
        var result = _customerDal.Get(c => c.Id == customerId);
        if (result == null)
        {
            return new ErrorDataResult<Customer>(Messages.UserNotFound);
        }
        return new SuccessDataResult<Customer>(result, Messages.SuccessListed);
    }

    public IDataResult<List<Customer>> GetAll()
    {
        return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.SuccessListed);
    }

    public IDataResult<Customer> GetByUserId(int userId)
    {
        var result = _customerDal.Get(c => c.UserId == userId);
        if (result == null)
            return new ErrorDataResult<Customer>(Messages.UserNotFound);
        return new SuccessDataResult<Customer>(result, Messages.SuccessListed);
    }

    public IDataResult<CustomerDetailDto> GetCustomerDetailById(int id)
    {
        var result = _customerDal.GetCustomerDetailById(c => c.UserId == id);
        if (result == null)
        {
            return new ErrorDataResult<CustomerDetailDto>(Messages.UserNotFound);
        }
        return new SuccessDataResult<CustomerDetailDto>(result, Messages.SuccessListed);

    }

    public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
    {
        return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
    }

    public IResult Update(Customer customer)
    {
        _customerDal.Update(customer);
        return new SuccessResult(Messages.SuccessUpdated);
    }
}
