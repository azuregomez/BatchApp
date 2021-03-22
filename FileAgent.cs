using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace BatchApp
{
    public class FileAgent: IProcess
    {
        //private string _basePath;
        private int _delay;
        public FileAgent(IConfiguration iconfiguration)
        {            
            _delay = Int32.Parse(iconfiguration.GetSection("DelaySeconds").Value);
        }

        public BatchRun ProcessFile(string fileName)
        {
           string text = File.ReadAllText(fileName);
            Thread.Sleep(_delay * 1000);
            return new BatchRun()
            {
                 FName=fileName,
                 NodeName=System.Environment.MachineName,
                 Result= text.Length.ToString()
            };
        }
    }
}
