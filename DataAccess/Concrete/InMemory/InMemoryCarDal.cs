using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        /*
       private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
           {
               new Car{Id=1,BrandId=1,ColorId=1,Name="A1", ModelYear=2020,DailyPrice= 110,Description="Powerful engine"},
               new Car{Id=2,BrandId=1,ColorId=2, Name="A2",ModelYear=2010, DailyPrice= 140,Description="Clean inside & out. E550 - has all options including winter tires!"},
               new Car{Id=3,BrandId=2,ColorId=1,Name="B1",ModelYear=2011,DailyPrice= 130,Description="Well maintained clean car no problems ready for winter."},
               new Car{Id=4,BrandId=3,ColorId=3,Name="C1", ModelYear=2017,DailyPrice= 75,Description="Acura ILX in Crystal Black Pearl on Black Leather is well equipped with more than enough for you to enjoy your trip."},
           };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id == car.Id);
            _cars.Remove(carToDelete);

        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<Car> GetByPrice()
        {
            return _cars.OrderByDescending(c => c.DailyPrice).ToList();
        }
        */
        public void Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> carDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
