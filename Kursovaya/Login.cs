using System;
using System.Collections.Generic;
using System.Text;

namespace Kursovaya
{
    static class Login
    {
        public static string login { get; set; }
        
    }
    static class Film
    {
        public static string NAME { get; set; }

    }
    static class Split
    {
        public static string text { get; set; }
        public static string criteria { get; set; }

        public static string findFirst3(string criteria, string text)
        {
            string foundWord = string.Empty;
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if(string.Compare(word, 0, criteria, 0, 3) == 0)
                {
                    foundWord = word;
                    break;
                }
            }
            return foundWord;
        }
    }
}
