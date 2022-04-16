using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManager.Core.Contracts;
using SchoolManager.Core.Services;
using SchoolManager.Infrastructure.Data;
using SchoolManager.Infrastructure.Data.Repositories;

namespace SchoolManager.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IGradeService, GradeService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContexts(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("Server=schoolmanagerdbserver.database.windows.net;Database=SchoolManager_db;User Id=slabaka109; Password=Jorkata03;");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=schoolmanagerdbserver.database.windows.net;Database=SchoolManager_db;User Id=slabaka109; Password=Jorkata03"));
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}