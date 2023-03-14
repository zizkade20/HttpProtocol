using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace HttBS
{

    class Program
    {
        static void Main()
        {
            URLChecker urlChecker = new URLChecker();
            urlChecker.Run();
        }
    }
    
}
