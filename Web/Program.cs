using Autofac.Extensions.DependencyInjection;
using Autofac;
using DancingGoat.Web.CompositionRoot;
using Kentico.Web.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.PageBuilder.Web.Mvc;
using XperienceAdapter.Models.PageContentTypes.DancingGoat.Home;
using XperienceAdapter.Models.PageContentTypes.DancingGoat.Content;
using CMS.Websites;
using System;
using CMS.Base;

// Application service registrations
var builder = WebApplication.CreateBuilder(args);

//Use Autofac
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>((ctx, container) =>
    {
        container.RegisterModule<WebCompositionRoot>();
    });
//Add Kentico with it's features
builder.Services.AddKentico(features =>
{
    features.UseWebPageRouting();
    features.UsePageBuilder(new PageBuilderOptions
    {
        ContentTypeNames =
        [
            Home.CONTENT_TYPE_NAME,
            Content.CONTENT_TYPE_NAME
        ]
    });
});

builder.Services.AddAuthentication();
builder.Services.AddControllersWithViews();
builder.Services.Configure<IISApplicationInitializationOptions>(options =>
{
    options.UseDefaultSystemResponseForPreload = true;
});
//builder.Services.Configure<WebPageUrlRetrieverOptions>(options =>
//{
//    options.MaximumUrlCacheDuration = TimeSpan.FromMinutes(60);
//});
//builder.Services.Configure<UrlResolveOptions>(options =>
//{
//    options.UseSSL = false;
//});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// These middleware components need to be called in this specific order
app.InitKentico();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseAuthentication();

app.UseKentico();
app.Kentico().MapRoutes();

// Starts the application
app.Run();