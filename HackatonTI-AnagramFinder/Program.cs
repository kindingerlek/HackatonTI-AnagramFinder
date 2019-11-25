using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace HackatonTI_AnagramFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            AngramController controller = new AngramController();

            controller.Start();
        }
    }
}
