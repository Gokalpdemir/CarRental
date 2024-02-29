using Autofac;
using AutoMapper;
using Business.AutoMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacMapperRegisterModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UserMapper>().As<Profile>();
            builder.RegisterType<CarMapper>().As<Profile>();
            builder.RegisterType<BrandMapper>().As<Profile>();
            builder.RegisterType<ColorMapper>().As<Profile>();
            builder.RegisterType<CustomerMapper>().As<Profile>();
            builder.RegisterType<RentalMapper>().As<Profile>();
            builder.RegisterType<CarImageMapper>().As<Profile>();
            builder.RegisterType<OperationClaimMapper>().As<Profile>();
            builder.RegisterType<UserOperationClaimMapper>().As<Profile>();
            
            builder.Register(context =>
            {
                var profiles = context.Resolve<Profile[]>();
                var config = new MapperConfiguration(cfg =>
                {
                    foreach (var profile in profiles)
                    {
                        cfg.AddProfile(profile);

                    }
                });
                return config.CreateMapper();
            }).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
