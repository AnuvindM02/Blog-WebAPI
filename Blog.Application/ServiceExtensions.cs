using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.ServiceContracts.CategoryServiceContracts;
using Blog.Application.Services.CategoryServices;
using Microsoft.Extensions.DependencyInjection;


namespace Blog.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped<ICategoryAdderService,CategoryAdderService>();
        }
    }
}
