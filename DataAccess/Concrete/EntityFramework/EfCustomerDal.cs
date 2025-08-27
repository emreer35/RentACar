using System;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRenting>, ICustomerDal
{
    public List<CustomerDetailDto> GetCustomerDetails()
    {
        using (CarRenting context = new CarRenting())
        {
            var result = context.Users.Join(
                context.Customers,
                user => user.Id,
                customer => customer.UserId,
                (user, customer) => new CustomerDetailDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CompanyName = customer.CompanyName,
                    Email = user.Email
                }
            ).ToList();
            return result;
        }
    }
}
