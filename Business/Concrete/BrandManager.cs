using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandService _brands;

        public BrandManager(IBrandService brands)
        {
            _brands = brands;
        }

        public List<Brand> GetAll()
        {
            return _brands.GetAll();
        }
    }
}
