using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {

        IColorService _colors;

        public ColorManager(IColorService colors)
        {
            _colors = colors;
        }

        public List<Color> GetAll()
        {
            return _colors.GetAll();
        }
    }
}
