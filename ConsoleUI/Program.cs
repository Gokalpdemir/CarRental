using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId=1,ModelYear=2016,ColorId=1,Description="5 kapı",DailyPrice=1000});
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.CarName);
            }
        }
    }
}
