using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0 && car.Name.Length >= 2)
            {

                _carDal.Update(car);

            }
            else
            {
                Console.WriteLine("The car daily price  must be greater than 0 and  name must be at least 2 characters ");
            }
        }
        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Name.Length >= 2)
            {
               
                    _carDal.Add(car);

            }
            else
            {
                Console.WriteLine("The car daily price  must be greater than 0 and  name must be at least 2 characters ");
            }

        }

        public List<Car> GetAll()
        {
            //iş

            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }
    }
}
