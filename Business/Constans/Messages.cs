using System;
using Entities.Concrete;

namespace Business.Constans;

public static class Messages
{
    public static string SuccessAdded = "Ekleme Basarili.";
    public static string SuccessUpdated = "Guncelleme Basarili.";
    public static string SuccessDeleted = "Silme basarili.";
    public static string SuccessListed = "Listeleme Basarili.";
    public static string CarNameValidation = "Arac ismini kontrol ediniz";
    public static string PriceNotUnderZero = "Arac Fiyati 0 in altinda olamaz";
    public static string UserNotFound = "User Bulunamadi";
    public static string GetAnUser = "User Getirildi";
    public static string ActiveCar = "Arac henuz teslim edilmemis";
    public static string HasNotActiveCar = "Arac henuz kiralanmamis";
    public static string RentCar = "Arac basariyla Kiralandi";
    public static string OffCar = "Arac kiralamasi bitmistir";
}
