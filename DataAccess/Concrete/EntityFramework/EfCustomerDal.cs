using System;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRenting>, ICustomerDal
{
    public CustomerDetailDto GetCustomerDetailById(Expression<Func<Customer, bool>> filter)
    {
        using (CarRenting context = new CarRenting())
        {
            var result = context.Customers.Where(filter).Join(
                context.Users,
                customer => customer.UserId,
                user => user.Id,
                (customer, user) => new CustomerDetailDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CompanyName = customer.CompanyName,
                    Email = user.Email
                }
            ).FirstOrDefault();
            return result;

        }
    }

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
