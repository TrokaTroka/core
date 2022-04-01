using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TrokaTroka.Api.Helppers;
using TrokaTroka.Api.Infra.Context;
using TrokaTroka.Api.Infra.Repositories;
using TrokaTroka.Api.Interfaces;
using TrokaTroka.Api.Interfaces.Repositories;
using TrokaTroka.Api.Interfaces.Services;
using TrokaTroka.Api.Notifications;
using TrokaTroka.Api.Services;

namespace TrokaTroka.Api.Configuration
{
    public static class DependencyInjection
    {
        public static void AddInjection(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddServices();      
            
            services.AddJwt();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<BaseService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IRatingService, RatingService>();

            services.AddScoped<IBlobStorageService, BlobStorageService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthenticatedUser, AuthenticatedUser>();
            services.AddScoped<INotifier, Notifier>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<TrokatrokaDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
            services.AddScoped<ITradeRepository, TradeRepository>();
        }        
    }
}
