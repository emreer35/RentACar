using System;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface ICustomerService
{
    IResult Add(Customer customer);
    IResult Delete(Customer customer);
    IResult Update(Customer customer);
    IDataResult<List<Customer>> GetAll();
    IDataResult<Customer> Get(int customerId);
    IDataResult<Customer> GetByUserId(int userId);
    IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
    IDataResult<CustomerDetailDto> GetCustomerDetailById(int id);
}
