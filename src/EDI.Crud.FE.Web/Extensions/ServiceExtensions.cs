using EDI.Crud.FE.Data.Api.UserRepo;
using EDI.Crud.FE.Data.Api.UserRepo.Impl;
using EDI.Crud.FE.Domain.UserService;
using EDI.Crud.FE.Domain.UserService.Impl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EDI.Crud.FE.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void InjectDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("EDI.Api", o =>
            {
                string mode = configuration.GetValue<string>("BaseUrl:EDI.Api:Mode");
                o.BaseAddress = new Uri(configuration.GetValue<string>($"BaseUrl:EDI.Api:Url:{mode}"));
            });

            services.AddScoped<IUserRepo, UserRepoImpl>();
        }


        public static void InjectDomainLayer(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserServiceImpl>();
        }
    }
}
