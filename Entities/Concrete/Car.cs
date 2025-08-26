using System;
using Core.Entities;

namespace Entities.Concrete;

public class Car : IEntity
{
    //: Id, BrandId, CarName, ColorId, ModelYear, DailyPrice, Description 
    public int Id { get; set; }
    public int BrandId { get; set; }
    public int ColorId { get; set; }
    public string CarName { get; set; } = string.Empty;
    public string ModelYear { get; set; } = string.Empty;
    public decimal DailyPrice { get; set; }
    public string Description { get; set; } = string.Empty;

}
