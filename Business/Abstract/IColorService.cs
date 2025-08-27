using System;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IColorService
{
    IResult Add(Color color);
    IDataResult<List<Color>> GetAll();
    IDataResult<Color> Get(int id);
    IResult Update(Color color);
    IResult Delete(Color color);

}
