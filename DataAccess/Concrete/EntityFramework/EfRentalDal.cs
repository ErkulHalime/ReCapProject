using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
         

                using (ReCapContext context = new ReCapContext())
                {
                /* var result = from re in filter is null ? context.Rentals : context.Rentals.Where(filter)
                              join ca in context.Cars
                              on re.CarId equals ca.Id
                              join cus in context.Customers
                              on re.CustomerId equals cus.Id
                              join us in context.Users
                              on cus.UserId equals us.Id
                              select new RentalDetailDto
                              {
                                  Id = re.Id,
                                  CarName = ca.Name,
                                  CustomerName = cus.CompanyName,
                                  CarId = ca.Id,
                                  RentDate = re.RentDate,
                                  ReturnDate = re.ReturnDate,
                              };

                 return result.ToList();*/

                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new RentalDetailDto
                             {
                                Id=r.Id,
                                 CarName = b.Name,
                                 CustomerName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();


            }
        }
    }
}
