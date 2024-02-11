
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.Abstract;
using Business.AutoMappers;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddSingleton<ICarService, CarManager>();
            //builder.Services.AddSingleton<IBrandService, BrandManager>();
            //builder.Services.AddSingleton<IColorService, ColorManager>();
            //builder.Services.AddSingleton<ICustomerService, CustomerManager>();
            //builder.Services.AddSingleton<IRentalService, RentalManager>();
            //builder.Services.AddSingleton<IUserService, UserManager>();

            //builder.Services.AddSingleton<IBrandDal, EfBrandDal>();
            //builder.Services.AddSingleton<ICarDal, EfCarDal>();
            //builder.Services.AddSingleton<IColorDal, EfColorDal>();
            //builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();
            //builder.Services.AddSingleton<IRentalDal, EfRentalDal>();
            //builder.Services.AddSingleton<IUserDal, EfUserDal>();

            //AutoMapper
            builder.Services.AddAutoMapper(typeof(CarMapper));
            builder.Services.AddAutoMapper(typeof(BrandMapper));
            builder.Services.AddAutoMapper(typeof(ColorMapper));
            builder.Services.AddAutoMapper(typeof(CustomerMapper));
            builder.Services.AddAutoMapper(typeof(RentalMapper));
            builder.Services.AddAutoMapper(typeof(UserMapper));
            builder.Services.AddAutoMapper(typeof(CarImageManager));



            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
               .ConfigureContainer<ContainerBuilder>(
               builder =>
               {
                   builder.RegisterModule(new AutofacBusinessModule());
               });




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
