using MailService.Domain.Repositories;
using MailService.Domain.Services;
using MailService.Repositories;

namespace MailService.Api;

/// <summary>
/// DI контейнер
/// </summary>
public static class DependencyContainer
{
    /// <summary>
    /// Зарегистрировать доменный слой (сервисы, репозитории)
    /// </summary>
    public static void RegisterDomainLayer(this IServiceCollection services)
    {
        RegisterRepositories(services);
        RegisterServices(services);
    }
    
    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IMailRepository, MailRepository>();
    }
    
    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ISmtpService, SmtpService>();
        services.AddScoped<IMailService, MailsService>();
    }
}