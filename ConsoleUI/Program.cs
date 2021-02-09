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
        //static void Main(string[] args)
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());

        //    foreach (var car in carManager.GetCarsByBrandId(1))
        //    {

        //        Console.WriteLine(car.BrandId);
        //    }
        //}

        static ICarService _carService = new CarManager(new EfCarDal());
        static void Main(string[] args)
        {
            GetAll();
            Console.WriteLine(Environment.NewLine);
            GetCarsByBrandId();
            Console.WriteLine(Environment.NewLine);
            GetCarsByColorId();
            Console.WriteLine(Environment.NewLine);
            Add();
            Console.ReadKey();
        }
        static void Add()
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
        static void GetCarsByBrandId()
        {
            List<CarDetailDto> cars = _carService.GetCarsByBrandId(_carService);
            foreach (var car in cars)
            {
                Console.WriteLine(car.BrandName+"/"+car.BrandId);
            }
        }
        static void GetCarsByColorId()
        {
            List<CarDetailDto> cars = _carService.GetCarsByColorId(_carService);
            foreach (var car in cars)
            {
                Console.WriteLine(car.ColorId + "/" + car.ColorName);


            }
        }
        static void GetAll()
        {
            foreach (Car car in _carService.GetAll())
            {
                Console.WriteLine(car.BrandId + "/" + car.Description);
            }

        }
    }
}
