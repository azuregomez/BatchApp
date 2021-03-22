using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BatchApp
{
    class Program
    {
        private static IConfiguration _iconfiguration;
        static void Main(string[] args)
        {            
            var filename = args[0];
            GetAppSettings();
            IProcess fileagent = new FileAgent(_iconfiguration);
            ISaveResult dac = new BatchDac(_iconfiguration);
            var result = fileagent.ProcessFile(filename);
            dac.SaveResult(result);
            Console.WriteLine("Processed file:" + result.FName);            
        }



        static void GetAppSettings()
        {
            // BaseDirectory returns the base directory that the assembly resolver uses to probe for the assemblies or where the executable file lies, 
            // CurrentDirectory returns the Current Working Directory in very simple means. It returns the path inside where you're executing the application.
            // In Az Batch, Directory.GetCurrentDirectory() would return the path of the task and appsettings would not be found
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }

  

        static void ShowRecords()
        {
            var dac = new BatchDac(_iconfiguration);
            var batchRunList = dac.Get();
            batchRunList.ForEach(item =>
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.FName);
                Console.WriteLine(item.Result);
                Console.WriteLine(item.NodeName);
                Console.WriteLine(item.TimeSaved);
                Console.WriteLine("--");
            });
            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();
        }
    }
}
