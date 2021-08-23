using Catalog.Application.Mappings;
using Catalog.Application.Queries;
using Catalog.Infrastructure.IRepositories.Persistence;
using Catalog.Infrastructure.Persistence;
using Catalog.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catalog.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Application Service Registration
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            //services.AddValidatorsFromAssembly(typeof(GetProductQueryHandler).Assembly);
            services.AddMediatR(typeof(GetProductQueryHandler).Assembly);

            //Infrastructure Service Registration
            services.AddDbContext<CatalogContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("CatalogConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ICatalogRepository, CatalogRepository>();

            return services;
        }
    }
}
