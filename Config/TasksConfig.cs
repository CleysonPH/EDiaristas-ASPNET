using EDiaristas.Core.Tasks;

namespace EDiaristas.Config;

public static class TasksConfig
{
    public static void RegisterTasks(this IServiceCollection services)
    {
        services.AddHostedService<SelecionarDiaristaTask>();
    }
}