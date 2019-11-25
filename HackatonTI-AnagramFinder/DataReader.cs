using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace HackatonTI_AnagramFinder
{
    public class DataReader
    {
        public static string[] GetValidWords()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<string> list = new List<string>();

            foreach (string line in File.ReadLines(@".\data\palavras.txt", Encoding.UTF8))
                list.Add(line);

            stopwatch.Stop();
            Console.WriteLine("Time elapsed to read word's file: {0}", stopwatch.Elapsed);
            return list.ToArray();
        }
    }
}
