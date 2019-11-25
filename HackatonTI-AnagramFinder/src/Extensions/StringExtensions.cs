using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions
{
    public static class StringExtensions
    {
        public static string Subtract(this string rangeOne, string rangeTwo)
        {
            var charList = rangeOne.ToList();

            for (int i = rangeTwo.Length - 1; i >= 0; i--)
            {
                char c = rangeTwo[i];
                charList.Remove(c);
            }
            return new string(charList.ToArray());
        }
    }
}
