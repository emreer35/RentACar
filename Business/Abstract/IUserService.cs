using System;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IUserService
{
    IResult Add(User user);
    IResult Update(User user);
    IResult Delete(User user);
    IDataResult<List<User>> GetAll();
    IDataResult<User> Get(int userId);
    
}
