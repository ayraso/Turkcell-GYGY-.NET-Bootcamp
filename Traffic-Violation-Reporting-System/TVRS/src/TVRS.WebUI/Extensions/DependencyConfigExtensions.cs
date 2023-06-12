using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using TVRS.Application.Services;
using TVRS.Application.Services.Option_Service;
using TVRS.Application.Services.Report_Service;
using TVRS.Domain.Repositories;
using TVRS.Infrastructure.Data_Context;
using TVRS.Infrastructure.Repositories;

namespace TVRS.WebUI.Extensions
{
    public static class DependencyConfigExtensions
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TvrsDbContext>(opt => opt.UseSqlServer(connectionString));

            services.AddScoped<IAttachmentRepository, EFAttachmentRepository>();
            services.AddScoped<IDistrictRepository, EFDistrictRepository>();
            services.AddScoped<IMainTopicRepository, EFMainTopicRepository>();
            services.AddScoped<IProvinceRepository, EFProvinceRepository>();
            services.AddScoped<IReportLogRepository, EFReportLogRepository>();
            services.AddScoped<ISubtopicRepository, EFSubtopicRepository>();
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IViolationReportRepository, EFViolationReportRepository>();

            services.AddScoped<IMapper, Mapper>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOptionService, OptionService>();
            services.AddScoped<IReportService, ReportService>();



            return services;
        }
    }
}
