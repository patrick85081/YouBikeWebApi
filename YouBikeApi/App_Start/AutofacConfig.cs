using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using YouBikeApi.Controllers;
using YouBikeApi.Models.Reposiotry;
using YouBikeApi.Models.Service;

namespace YouBikeApi
{
    public class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder
                //.RegisterType<TaipeiYouBikeRepository>()
                //.RegisterType<NewTaipeiYouBikeRepository>()
                .RegisterType<AllYouBikeRepository>()
                .WithParameter("repositorys",
                    new IYouBikeRepository[] {new TaipeiYouBikeRepository(), new NewTaipeiYouBikeRepository()})
                .As<IYouBikeRepository>();

            builder.RegisterType<YouBikeService>()
                .As<IYouBikeService>();

            builder.RegisterInstance<IMapper>(Mapper.Instance);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}