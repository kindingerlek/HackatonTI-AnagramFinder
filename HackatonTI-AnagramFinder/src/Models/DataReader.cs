using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace HackatonTI_AnagramFinder
{
    public class DataReader
    {
        public static string[] GetValidWords()
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Reading the file...");

            stopwatch.Start();
            string[] list = File.ReadLines(@".\data\palavras.txt", Encoding.UTF8).ToArray();
            stopwatch.Stop();

            Console.WriteLine("Time elapsed to read word's file: {0}", stopwatch.Elapsed);
            return list.ToArray();
        }
    }
}
