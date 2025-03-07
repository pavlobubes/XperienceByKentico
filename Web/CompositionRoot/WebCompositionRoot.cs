using Application.Home.Queries.GetHomeQuery;
using Autofac;
using Core.Dependencies;
using Infrastructure.HomePage.Repository;
using MediatR;
using System;

namespace DancingGoat.Web.CompositionRoot;

public class WebCompositionRoot : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // Register all concrete classes that implement IScoped in one go.
        builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
            .Where(t => t.IsClass && !t.IsAbstract && typeof(IScoped).IsAssignableFrom(t))
            .AsImplementedInterfaces()
            .PropertiesAutowired()
            .InstancePerLifetimeScope();

        // Register all concrete classes that implement IScoped in one go.
        builder.RegisterAssemblyTypes(typeof(IHomePageRepository).Assembly)
            .Where(type => type is { IsClass: true, IsAbstract: false } && type.IsAssignableTo<IScoped>())
            .AsImplementedInterfaces()
            .PropertiesAutowired()
            .InstancePerLifetimeScope();

        // Register MediatR Handlers
        builder.RegisterAssemblyTypes(typeof(GetHomeQueryHandler).Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}