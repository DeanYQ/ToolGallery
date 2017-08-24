using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class XmlDataManager
    {
        public XmlDataManager()
        {
            Dict = new Dictionary<string, XmlItem>();
        }

        public Dictionary<string, XmlItem> Dict;
    }
}
