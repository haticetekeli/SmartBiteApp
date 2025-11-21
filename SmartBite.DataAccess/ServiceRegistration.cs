using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SmartBite.DataAccess.DbContexts;
using SmartBite.DataAccess.UnitOfWork.Abstract;
using SmartBite.DataAccess.UnitOfWork.Concrete;


namespace SmartBite.DataAccess
{
    public static class ServiceRegistration
    {
        public static void DataAccessRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("PostgreSql").Value;

            services.AddDbContext<SmartBiteDbContext>(x =>
            {
                x.UseNpgsql(connectionString, opt =>
                {
                    opt.CommandTimeout(120);
                });
                x.EnableSensitiveDataLogging();
            });


            services.TryAddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<SmartBiteDbContext>));
            services.TryAddScoped<DbContext, SmartBiteDbContext>();


        }
    }
}
