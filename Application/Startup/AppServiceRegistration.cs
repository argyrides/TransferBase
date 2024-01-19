using Coravel;
using Microsoft.AspNetCore.Components.Authorization;
using Spark.Library.Auth;
using Spark.Library.Database;
using Spark.Library.Logging;
using Spark.Library.Mail;
using TransferBase.Application.Database;
using TransferBase.Application.Events.Listeners;
using TransferBase.Application.Jobs;
using TransferBase.Application.Models;
using TransferBase.Application.Services;
using TransferBase.Application.Services.Auth;
using TransferBase.Application.Services.FixData;
using TransferBase.Application.Services.General;

namespace TransferBase.Application.Startup
{
    public static class AppServiceRegistration
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddCustomServices();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDatabase<DatabaseContext>(config);
            services.AddAutoMapper(typeof(Program).Assembly);
            services.AddLogger(config);
            services.AddAuthorization(config, new string[] { CustomRoles.Admin, CustomRoles.User });
            services.AddAuthentication<IAuthValidator>(config);
            services.AddScoped<AuthenticationStateProvider, SparkAuthenticationStateProvider>();
            services.AddJobServices();
            services.AddScheduler();
            services.AddQueue();
            services.AddEventServices();
            services.AddEvents();
            services.AddMailer(config);
            return services;
        }

        private static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // add custom services
            services.AddScoped<UsersService>();
            services.AddScoped<RolesService>();
            services.AddScoped<IAuthValidator, AuthValidator>();
            services.AddScoped<AuthService>();
            services.AddScoped<PlayerSkillsService>();
            services.AddScoped<PlayersService>();
            services.AddScoped<TransfersService>();
            services.AddScoped<ClubsService>();
            services.AddScoped<ValuesService>();
            services.AddScoped<CompetitionsService>();
            services.AddScoped<NationalTeamsService>();
            services.AddScoped<GamesService>();
            services.AddScoped<CoachesService>();
            services.AddScoped<AppearancesService>();

            return services;
        }

        private static IServiceCollection AddEventServices(this IServiceCollection services)
        {
            // add custom events here
            services.AddTransient<EmailNewUser>();
            return services;
        }

        private static IServiceCollection AddJobServices(this IServiceCollection services)
        {
            // add custom background tasks here
            services.AddTransient<ExampleJob>();
            return services;
        }
    }
}