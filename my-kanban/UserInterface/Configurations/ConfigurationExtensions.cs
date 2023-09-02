using Repository;
using Repository.Interfaces;
using Repository.Repsitories;
using Service.Interfaces;
using Service.Services;

namespace UI.Configurations
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection collection)
        {
            collection
                .AddScoped<IUnitOfWork, ApplicationContext>()
                .AddScoped<IBoardRepository, BoardRepository>()
                .AddScoped<ITaskRepository, TaskRepository>();

            return collection;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection collection)
        {
            collection
                .AddScoped<IBoardService, BoardService>()
                .AddScoped<ITaskService, TaskService>();

            return collection;
        }
    }
}
