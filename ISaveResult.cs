using System;
using System.Collections.Generic;
using System.Text;

namespace BatchApp
{
    public interface ISaveResult
    {
        public void SaveResult(BatchRun batchrun);
    }
}
