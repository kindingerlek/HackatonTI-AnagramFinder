using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HackatonTI_AnagramFinder
{
    public class AngramController
    {
        private string[] validWords;
        private AnagramFinder anagramFinder;
        private Stopwatch stopwatch;

        public AngramController()
        {
            validWords = DataReader.GetValidWords();
            anagramFinder = new AnagramFinder(validWords);
            stopwatch = new Stopwatch();
        }

        public void Start()
        {
            string word;
            if ((word = ReadUserExpression()) == null)
                return;

            Console.WriteLine($"\nWord: {word} - {word.Length} characters\n");
            Console.WriteLine("Looking for anagrams...");

            stopwatch.Restart();
            var anagramList = anagramFinder.GetAnagram(word.ToUpper());
            stopwatch.Stop();

            Console.WriteLine($"\nHas been found {anagramList.Length} anagrams set in time: {stopwatch.Elapsed}"); 

            if (ReadUserDecision("Do you want print them?[Y/N]"))
            {
                stopwatch.Restart();
                var s = string.Join('\n', anagramList);
                Console.WriteLine(s);
                stopwatch.Stop();
                Console.WriteLine($"Time to print all anagrams: {stopwatch.Elapsed}");
            }

        }

        private string ReadUserExpression()
        {
            string input;

            Regex rgx = new Regex(@"[^A-Z ]", RegexOptions.IgnoreCase);
           
            Console.WriteLine("Type a word or an expression with 16 alphabetic characters, or '0' to exit:");
            input = Console.ReadLine();

            if (input == "0")
                return null;

            if (rgx.IsMatch(input))
            {
                Console.WriteLine("The typed expression has invalid characters! Only letter is allowed.");
                return null;
            }

            if (input.Length > 16)
            {
                Console.WriteLine("The typed expression has more than 16 characters!");
                return null;
            }

            return input;
        }

        private bool ReadUserDecision(string ask)
        {
            string input;
            string[] acceptTerms = new string[] { "Y", "YES", "1" };
            string[] denyTerms = new string[] { "N", "NO", "0" };


            Console.WriteLine($"{ask} [Y/N]");
            input = Console.ReadLine().ToUpper();

            if (acceptTerms.Contains(input))
                return true;

            if (denyTerms.Contains(input))
                return false;

            Console.WriteLine("Invalid answer!");
            return ReadUserDecision(ask);
        }
    }
}
