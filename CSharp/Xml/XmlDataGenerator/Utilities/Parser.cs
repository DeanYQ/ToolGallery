using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Parser
    {
        static int Parse(string str)
        {
            int y = 0;
            //var len = str.Length;
            for (var i = 0; i < str.Length; i++)
            {
                y = y * 10 + (str[i] - '0');
            }
            return y;
        }
    }
}
