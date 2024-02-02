using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.ServiceContracts.BlogPostServiceContracts;
using Blog.Application.ServiceContracts.CategoryServiceContracts;
using Blog.Application.Services.BlogPostServices;
using Blog.Application.Services.CategoryServices;
using Microsoft.Extensions.DependencyInjection;


namespace Blog.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            //Injecting Category Services
            services.AddScoped<ICategoryAdderService,CategoryAdderService>();
            services.AddScoped<ICategoryGetterService, CategoryGetterService>();
            services.AddScoped<ICategoryDeleterService, CategoryDeleterService>();
            services.AddScoped<ICategoryUpdaterService, CategoryUpdaterService>();

            //Injecting Blog Post Services
            services.AddScoped<IBlogPostAdderService, BlogPostAdderService>();
            services.AddScoped<IBlogPostGetterService, BlogPostGetterService>();
            services.AddScoped<IBlogPostDeleterService, BlogPostDeleterService>();
            services.AddScoped<IBlogPostUpdaterService, BlogPostUpdaterService>();
        }
    }
}
