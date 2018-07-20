using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.Utilities.FileFormat
{
    public abstract class FileStorage
    {
        public abstract void Store(string fileName);
    }
}
