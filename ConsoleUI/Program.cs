using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
  public   class Program
    {
       
        static ICarService _carService = new CarManager(new EfCarDal());
      private static void Main(string[] args)
        {
            Add();
           
        }
        private static void Add()
        {
            try
            {
                Car car = new Car
                {
                    BrandId = 7,
                    ColorId = 9,
                    DailyPrice = 0,
                    Description = "Yeni Araç",
                    ModelYear = new DateTime(2015),
                };
                _carService.Add(car);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
        private static void GetCarsByBrandId()
        {
            List<CarDetailDto> cars = (List<CarDetailDto>)_carService.GetCarsByBrandId(_carService);
            foreach (var car in cars)
            {
                Console.WriteLine(car.BrandName+"/"+car.BrandId);
            }
        }
        private static void GetCarsByColorId()
        {
            List<CarDetailDto> cars = (List<CarDetailDto>)_carService.GetCarsByColorId(_carService);
            foreach (var car in cars)
            {
                Console.WriteLine(car.ColorId + "/" + car.ColorName);


            }
        }
        private static void GetAll()
        {
            foreach (Car car in _carService.GetAll().Data)
            {
                Console.WriteLine(car.BrandId + "/" + car.Description);
            }

        }
    }
}
