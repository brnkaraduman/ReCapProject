using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemeoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemeoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ Id=1, BrandId=1, ColorId="Blue", ModelYear= new DateTime(2020), DailyPrice=150, Description="New"},
                new Car{ Id=2, BrandId=2, ColorId="Black", ModelYear= new DateTime(2021), DailyPrice=180, Description="Old"},
                new Car{ Id=3, BrandId=2, ColorId="White", ModelYear= new DateTime(2020), DailyPrice=250, Description="New"},
                new Car{ Id=4, BrandId=3, ColorId="Black", ModelYear= new DateTime(2019), DailyPrice=200, Description="New"},
                new Car{ Id=5, BrandId=1, ColorId="Red", ModelYear= new DateTime(2019), DailyPrice=150, Description="Old"},

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car cartoDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(cartoDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }
        public List<Car> GetAllId(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetById(int brandId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car CartoUpdate = _cars.SingleOrDefault(c => car.Id == car.Id);
            CartoUpdate.ColorId = car.ColorId;
            CartoUpdate.BrandId = car.BrandId;
            CartoUpdate.DailyPrice = car.DailyPrice;
            CartoUpdate.Description = car.Description;

        }
    }
}
