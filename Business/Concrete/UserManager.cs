using System;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class UserManager : IUserService
{
    IUserDal _userDal;
    #region Constructor
    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }
    #endregion

    #region CRUD OPERATION METHOD
    public IResult Add(User user)
    {
        _userDal.Add(user);
        return new SuccessResult(Messages.SuccessAdded);
    }

    public IResult Delete(User user)
    {
        _userDal.Delete(user);
        return new SuccessResult(Messages.SuccessDeleted);
    }

    public IDataResult<User> Get(int userId)
    {
        var result = _userDal.Get(u => u.Id == userId);
        if (result == null)
        {
            return new ErrorDataResult<User>(Messages.UserNotFound);
        }
        return new SuccessDataResult<User>(result,Messages.GetAnUser);
    }

    public IDataResult<List<User>> GetAll()
    {
        var result = _userDal.GetAll();
        if (result == null)
        {
            return new ErrorDataResult<List<User>>(Messages.UserNotFound);
        }
        return new SuccessDataResult<List<User>>(result, Messages.SuccessListed);
    }

    public IResult Update(User user)
    {
        _userDal.Update(user);
        return new SuccessResult(Messages.SuccessUpdated);
    }
    #endregion
}
