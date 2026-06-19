using Domain.Curriculum.Subjects;
using Infrastructure.Curriculum.Subjects;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<HomeschoolHqDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("HomeschoolHq"));
        });

        services.AddScoped<ISubjectRepository, EfSubjectRepository>();

        return services;
    }
}