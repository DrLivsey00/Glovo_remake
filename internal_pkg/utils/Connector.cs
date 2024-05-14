using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glovo.internal_pkg.utils
{
    internal class Connector
    {
        public string filePath;

        public Connector(string filePath)
        {
            if(filePath==null || filePath.Length == 0)
            {
                throw new ArgumentException("Wrong file path!");
            }
            this.filePath = filePath;
        }

        public static str
    }
}
