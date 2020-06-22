using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TestApplication.Interfaces;
using TestApplication.Services;

namespace TestApplication
{
    class Program
    {
        private static ServiceProvider _serviceProvider;

        static async Task Main(string[] args)
        {
            var isSuccess = true;

            var collection = new ServiceCollection();
            RegisterServices(collection);

            using (_serviceProvider = collection.BuildServiceProvider())
            {
                var wordProcessor = CreateCompoundWordProcessor();
                try
                {
                    await wordProcessor.SplitWords();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    isSuccess = false;
                }
            }

            var message = isSuccess ? "Input words have been split successfuly!" : "Input words haven't been split! Please see an error for more details.";
            Console.WriteLine(message);
            Console.ReadLine();
        }

        private static void RegisterServices(ServiceCollection collection)
        {
            collection.AddScoped<ICompoundWordProcessor, CompoundWordProcessor>();
            collection.AddScoped<IFileService<string>, TextFileService>();
            collection.AddScoped<IParseService, ParseService>();
        }

        private static ICompoundWordProcessor CreateCompoundWordProcessor()
        {
            return _serviceProvider.GetService<ICompoundWordProcessor>();
        }

    }
}

