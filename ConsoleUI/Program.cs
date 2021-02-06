using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            // carManager.Add(new Car { BrandId = 1, ColorId = 2, Name="A1", DailyPrice = 300, ModelYear = 2021, Description = "Powerful engine" });
            // carManager.Add(new Car { BrandId = 1, ColorId = 3, Name = "A2", DailyPrice = 200, ModelYear = 2019, Description = "Powerful engine" });
            carManager.Add(new Car { BrandId = 1, ColorId = 3, Name = "A2", DailyPrice = -10, ModelYear = 2019, Description = "Powerful engine" });

            Console.WriteLine("---------AllCars-----");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Id: " + car.Id + " ModelYear: " + car.ModelYear +" DailyPrice: "+car.DailyPrice);
            }
            Console.WriteLine("---------GetCarsByBrandId-----");
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine("Id: " + car.Id + "BrandId: " + car.BrandId + " ModelYear: " + car.ModelYear + " DailyPrice: " + car.DailyPrice);
            }
            Console.WriteLine("---------GetCarsByColorId-----");
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine("Id: " + car.Id + "ColorId: " + car.ColorId + " ModelYear: " + car.ModelYear + " DailyPrice: " + car.DailyPrice);
            }



        }
    }
}
