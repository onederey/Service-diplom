using CommonLib.Classes;
using CommonLib.DataManagers;
using CommonLib.Interfaces;
using CommonLib.Mails;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceExtensions.Extensions
{
    public static class AddCommonWorkerExt
    {
        public static IServiceCollection AddCommonWorker(this IServiceCollection collection)
        {
            if(collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            return collection
                .AddSingleton<ITaskDataManager, TaskDataManager>()
                .AddSingleton<IMailManager, MailManager>();
        }
    }
}