using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.ResourceAccess.DataProcessors
{
    public abstract class DataProcessor : IDataProcessor
    {
        public readonly int userId;
        public DataProcessor(int userId)
        {
            this.userId = userId;
        }
        public abstract string Connect();
    }
}
