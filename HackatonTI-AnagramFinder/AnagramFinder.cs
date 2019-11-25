using Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HackatonTI_AnagramFinder
{
    public class AnagramFinder
    {
        string[] wordsList = null;

        public AnagramFinder(string[] validWords)
        {
            wordsList = validWords.OrderBy(x => x).ToArray();
        }

        public string[] GetAnagram(string word)
        {
            word = word.ToUpper().Replace(" ", "");

            Stack<string> temp = new Stack<string>();
            HashSet<string> validKeys = new HashSet<string>();
            HashSet<string> validSubset = new HashSet<string>();
            FindAnagramsRecursively(word, wordsList, temp, validKeys, validSubset);

            return validSubset.OrderBy(x => x).ToArray();
        }

        private void FindAnagramsRecursively(string word, IEnumerable<string> source, Stack<string> stack, HashSet<string> validKeys, HashSet<string> subset)
        {
            var list = source                                   // Separa um novo array
                            .Where(x =>                             // Onde todos os valores possuem:
                                    (x.Length <= word.Length)           // - Tamanho menor ou igual a palavra
                                    && x.All(word.Contains)             // - Todas as letras contidas na palavra
                                    && x.Subtract(word).Length == 0     // - O resto da subtração dos caracteres, é zero
                                    && !validKeys.Contains(x)           // - Não é um valor já conhecido
                                    )
                            .ToArray();

            if (list.Length == 0)
                return;

            for (int i = 0; i < list.Length; i++)
            {
                string validWord = list[i];
                // Guarda a chave na pilha temporária
                stack.Push(validWord);

                // Armazena o resto da subtração dos caracteres da palavra
                var leftResult = word.Subtract(validWord);

                // Caso não haja caracteres sobrando
                if (leftResult.Length == 0)
                {
                    // Salva a base da pilha como um item já validado
                    validKeys.Add(stack.Last());

                    // Salva na lista, como string unica, o conjunto encontrado
                    subset.Add(string.Join(" ", stack.OrderBy(x => x).ToArray()));
                }

                // Caso contrario, caso ainda haja caracteres sobrando, continua a busca por anagramas
                FindAnagramsRecursively(leftResult, list, stack, validKeys, subset);  
                stack.Pop();
            }
        }
    }
}
