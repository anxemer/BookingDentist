using AutoMapper;
using BookingDentist.API.AutoMapper;
using BookingDentist.Business;
using BookingDentist.Business.BusinessLogic;
using BookingDentist.DataAccess;
using BookingDentist.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookingDentist.API.DependencyInJection
{
    public static class DependencyInjection
    {
        public static void InitializerDependencyInjection(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddControllers();
       
            services.AddDbContext<BookingDentistDataContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //Add Mapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationMapper());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<DbContext,BookingDentistDataContext>();
            services.AddScoped<BookingDentistDataContext>();
            services.AddScoped<AccountBussiness>();
            services.AddScoped<LoginBusiness>();
            services.AddScoped<ClinicBusiness>();
            services.AddScoped<ClinicAccountBusiness>();
            services.AddScoped<ClinicServiceBusiness>();
            services.AddScoped<DentistBusiness>();
            services.AddScoped<DentistServiceBusiness>();
            services.AddScoped<ServiceBusiness>();
            services.AddScoped<AppointmentBusiness>();
            services.AddScoped<IAccountRepository, AccountRepository>();

        }
    }
}
