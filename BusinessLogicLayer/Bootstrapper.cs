using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Services;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace BusinessLogicLayer
{
    public class Bootstrapper
    {
        public static void ConfigureProjectServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IUserTokenRepository, UserTokenRepository>();

            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IReservationService,ReservationService>();
            services.AddScoped<IRestaurantServices,RestaurantService>();
            services.AddScoped<IUserTokenService, UserTokenService>();
        }
    }
}
