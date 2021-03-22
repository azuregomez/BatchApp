using System;
using System.Collections.Generic;
using System.Text;

namespace BatchApp
{
    public class BatchRun
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string Result { get; set; }
        public string NodeName { get; set; }
        public DateTime TimeSaved { get; set; }

    }
}
