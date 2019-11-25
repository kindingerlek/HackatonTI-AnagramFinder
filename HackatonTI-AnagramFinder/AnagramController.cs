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

            stopwatch.Restart();
            Console.WriteLine("Buscando anagramas...");
            var anagramList = anagramFinder.GetAnagram(word.ToUpper());
            stopwatch.Stop();

            Console.WriteLine($"\nForam encontrados {anagramList.Count} conjuntos de anagramas válidos no tempo {stopwatch.Elapsed}");

            if (ReadUserDecision("Você deseja exibi-los?"))
            {
                foreach (var s in anagramList)
                    Console.WriteLine(s);
            }

        }

        private string ReadUserExpression()
        {
            string input;

            Regex rgx = new Regex(@"[^A-Z ]", RegexOptions.IgnoreCase);
            do
            {
                Console.WriteLine("Digite uma palavra ou frase de até 16 caracteres alfabéticos, ou '0' para sair:");
                input = Console.ReadLine();

                if (input == "0")
                    return null;

                if (rgx.IsMatch(input))
                    Console.WriteLine("A expressão digitada possui caracteres inválidos! Apenas letras (não acentuadas) são válidas.");

                if (input.Length > 16)
                    Console.WriteLine("A expressão digitada possui mais de 16 caracteres!");

            }
            while (input.Length > 16 || rgx.IsMatch(input));

            return input;
        }

        private bool ReadUserDecision(string ask)
        {
            string input;
            string[] acceptTerms = new string[] { "S", "SIM", "Y", "YES","1" };
            string[] denyTerms = new string[] { "N", "NO", "NAO", "0" };


            Console.WriteLine($"{ask} [S/N]");
            input = Console.ReadLine().ToUpper();

            if (acceptTerms.Contains(input))
                return true;

            if (denyTerms.Contains(input))
                return false;

            Console.WriteLine("Resposta inválida!");
            return ReadUserDecision(ask);
        }
    }
}
