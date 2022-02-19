using Microsoft.Extensions.DependencyInjection;
using ServiceExtensions.BackgroundServices;

namespace ServiceExtensions.Extensions
{
    public static class AddTestWorkerExt
    {
        public static IServiceCollection AddTestWorker(this IServiceCollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            return collection
                .AddHostedService<TestBackgroundService>();
        }
    }
}
