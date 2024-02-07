using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

namespace ConsoleUI
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            IAuthenticationService authenticationService = new AuthentcionService(new EfUserDal(), new EfCustomerDal());
            RegisterAsCustomerDto registerAsCustomerDto = new RegisterAsCustomerDto()
            {
                FirstName = "test",
                LastName = "test",
                Email = "test@gmail.com",
                Password = "test",
                CompanyName = "test"
            };

            authenticationService.RegisterAsCustomer(registerAsCustomerDto);


            //CarTest();
            //BrandTest();
            //ColorTest();

            //UserTest();
            //CustomerTest();

            //RentalTest();

        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new RentalDto { CarId = 3, CustomerID = 1, RentDate = DateTime.Now });
            if (result.Success)
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
            var result = customerManager.Add(new CustomerDto { UserId = 1, CompanyName = "Demir Holding", });
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new UserDto { FirstName = "Gökalp", LastName = "Demir", Email = "gokalpdmmr@gmail.com", Password = "6356210t" });
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
           var result= colorManager.Add(new ColorDto { Name="Beyaz"});
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

          var result=  brandManager.GetAll();
            if (result.Success)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(result);
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
