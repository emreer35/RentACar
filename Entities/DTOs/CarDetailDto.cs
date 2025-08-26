using System;
using Core.Entities;

namespace Entities.DTOs;

public class CarDetailDto : IDto
{
    //CarName, BrandName, ColorName, DailyPrice.
    public string CarName { get; set; } = string.Empty;
    public string BrandName { get; set; } = string.Empty;
    public string ColorName { get; set; } = string.Empty;
    public decimal DailyPrice { get; set; }
}
