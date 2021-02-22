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
            // CarsDetail();
            // CustomerTest();
            //AddUser();
            AddRental();
           // GetRentalDetails();

        }

        private static void GetRentalDetails()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine($"{rental.Id}\t{rental.CarName}\t{rental.CustomerName}\t{rental.RentDate}\t{rental.ReturnDate}");
            }
        }

        private static void AddRental()
        {
            Rental rentalForAdd = new Rental
            {
                CarId = 1,
                CustomerId = 2,
                RentDate = DateTime.Now,
                ReturnDate = null
            };
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(rentalForAdd);
        }

        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User userForAdd = new User
            {

                FirstName = "Esra",
                LastName = "Yılmaz",
                Email = "esr@gmail.com",
                Password = "123456"

            };
            userManager.Add(userForAdd);
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
           
            customerManager.Add(new Customer { UserId = 1, CompanyName = "Company1" });
            var result = customerManager.GetAll();
            foreach (var customer in result.Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
            
        }

        private static void CarsDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetailDtos();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
                }

            }
        }
    }
}
