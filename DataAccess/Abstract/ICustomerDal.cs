using System;
using System.Linq.Expressions;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract;

public interface ICustomerDal : IEntityRepository<Customer>
{
    List<CustomerDetailDto> GetCustomerDetails();
    CustomerDetailDto GetCustomerDetailById(Expression<Func<Customer, bool>> filter);

}
