using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> carDetailDtos()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join c in context.Colors
                             on car.ColorId equals c.Id
                             join b in context.Brands
                             on car.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 CarName = car.Name,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 DailyPrice = car.DailyPrice
                             };
                return result.ToList();

            }
        }
    }
}
