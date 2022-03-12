using CommonLib.Interfaces;
using CommonLib.Interfaces.DataManagers;
using CommonLib.Interfaces.Mappers;
using CommonLib.Interfaces.Validators;
using Microsoft.Extensions.DependencyInjection;
using ServiceExtensions.BackgroundServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestParserExample.Classes;

namespace ServiceExtensions.Extensions
{
    public static class AddTestFileWorkerExtension
    {
        public static IServiceCollection AddTestFileWorker(this IServiceCollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            return collection
                .AddTransient<IBaseMapper, TestMapper>()
                .AddTransient<IBaseValidator, TestValidator>()
                .AddTransient<IBaseDataManager, TestDataManager>()
                .AddTransient<IFileParser, FileParser>()
                .AddHostedService<TestFileBackgroundService>();
        }
    }
}
