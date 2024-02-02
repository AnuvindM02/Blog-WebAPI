using Blog.Domain.RepositoryContracts.BlogPostRepositoryContract;
using Blog.Domain.RepositoryContracts.CategoryRepositoryContract;
using Blog.Persistence.Context;
using Blog.Persistence.Repositories.BlogPostRepository;
using Blog.Persistence.Repositories.CategoryRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Blog.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));

            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Injecting repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
        }
    }
}
