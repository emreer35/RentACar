using System;
using Entities.Concrete;

namespace Business.Abstract;

public interface IColorService
{
    void Add(Color color);
    List<Color> GetAll();
    Color Get(int id);
    void Update(Color color);
    void Delete(Color color);

}
