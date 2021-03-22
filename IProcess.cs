using System;
using System.Collections.Generic;
using System.Text;

namespace BatchApp
{
    public interface IProcess
    {
        public BatchRun ProcessFile(string filename);
    }
}
