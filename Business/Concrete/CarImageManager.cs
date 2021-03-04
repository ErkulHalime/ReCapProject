using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utulities.Business;
using Core.Utulities.FileOperations;
using Core.Utulities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        ICarImageDal _carImageDal;
        ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(FileOperation file, string filePath, CarImage carImage)
        {
            var result = BusinessRules.Run(IsExist(carImage.Id));
            if (result == null)
            {
                return result;
            }
            result = BusinessRules.Run(CheckCarImageCountLimitReached(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string newImageFileName = RenameFileToGuid(file);

            carImage.ImagePath = newImageFileName;
            carImage.Date = DateTime.Now;

            UploadImage(file, filePath, newImageFileName);

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.AddedCarImage);
        }

        private static void UploadImage(FileOperation file, string filePath, string newImageFileName)
        {
          
                using (FileStream fileStream = File.Create(filePath + newImageFileName))
                {
                    file.files.CopyTo(fileStream);
                    fileStream.Flush();
                }
            
        }

        private static string RenameFileToGuid(FileOperation file)
        {
            string[] fileNameSplit = file.files.FileName.Split('.');
            var extensionOfFile = "." + fileNameSplit[fileNameSplit.Length - 1];
            var result =
                DateTime.Now.Day.ToString() + "_" +
                DateTime.Now.Month.ToString() + "_" +
                DateTime.Now.Year.ToString() + "_" +
                Guid.NewGuid().ToString() + extensionOfFile;
            return result;
        }

        private IResult IsExist(int carImageId)
        {
            var carImageExist = GetById(carImageId);
            if (carImageExist.Data != null)
            {
                return new SuccessResult(Messages.CarImageExists);
            }
            return new ErrorResult(Messages.CarImageNotFound);
        }

        public IResult Delete(string filePath, CarImage carImage)
        {
            var result = BusinessRules.Run(IsExist(carImage.Id));
            if (result != null)
            {
                return result;
            }
            var carImageToDelete = _carImageDal.Get(p => p.Id == carImage.Id);
            DeleteImage(filePath + carImageToDelete.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.DeletedCarImage);
        }

        private static void DeleteImage(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll().ToList();
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == Id), Messages.CarImageListed);
        }
        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {

            if (!_carImageDal.GetAll(p => p.CarId == carId).Any())
            {
                if (_carService.IsExist(carId).Success)
                {
                    return new SuccessDataResult<List<CarImage>>(new List<CarImage> {new CarImage {
                    CarId = carId,
                    ImagePath = "NoPicCar.png",
                    Date = DateTime.MinValue
                    }
                    }
                    , Messages.CarImageListed);
                }
                return new ErrorDataResult<List<CarImage>>(Messages.CarNotFound);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId), Messages.CarImageListed);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(FileOperation file, string filePath, CarImage carImage)
        {
            var result = BusinessRules.Run(IsExist(carImage.Id));
            if (result != null)
            {
                return result;
            }
            var carImageToUpdate = _carImageDal.Get(p => p.Id == carImage.Id);
            DeleteImage(filePath + carImageToUpdate.ImagePath);
            string newImageFileName = RenameFileToGuid(file);
            carImage.ImagePath = newImageFileName;
            carImage.Date = DateTime.Now;
            UploadImage(file, filePath, newImageFileName);

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.UpdatedCarImage);
        }

        private IResult CheckCarImageCountLimitReached(int carId)
        {
            

            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.FailedCarImageAdd);
            }
            return new SuccessResult();
        }

       
    }
}
