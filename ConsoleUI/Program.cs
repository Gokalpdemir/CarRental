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
            //CarTest();
            //BrandTest();
            //ColorTest();

            //UserTest();
            //CustomerTest();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result=rentalManager.Add(new Rental { CarId=3,CustomerID=1,RentDate=DateTime.Now});
            if(result.Success )
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer { UserId = 1, CompanyName = "Demir Holding", });
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "Gökalp", LastName = "Demir", Email = "gokalpdmmr@gmail.com", Password = "6356210t" });
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
           var result= colorManager.Add(new Color { Name="Beyaz"});
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.BrandName + " "+ car.CarName + " "+car.ColorName+" "+car.DailyPrice);
            }
        }
       
    }
}
