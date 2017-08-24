using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class XmlDataStruct
    {
        public XmlDataStruct()
        {
            Id = string.Empty;
            Attributes = new Dictionary<string, int>();
        }

        public string Id;

        public Dictionary<string, int> Attributes;
    }
}
