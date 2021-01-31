using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Id: " + car.Id + " ModelYear: " + car.ModelYear +" DailyPrice: "+car.DailyPrice);
            }

            Console.WriteLine("-----Desc Cars By Price----");
            foreach (var car in carManager.GetByPrice())
            {
                Console.WriteLine("Id: " + car.Id + " DailyPrice: " + car.DailyPrice);
            }

        }
    }
}
