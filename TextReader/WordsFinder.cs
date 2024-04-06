using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextReader
{
    public static class WordsFinder
    {
        public static void FindWordsWithMaxNumbers(string text)
        {
            string[] words = text.Split(new char[] { ' ', '.', ',', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> ListWords = new List<string>();
            List<string> FinalListWords = new List<string>();
            int maxAmountOfNumbers = 0;
            int counter = 0;
            foreach (string word in words)
            {
                counter = 0;
                foreach (char letter in word)
                {
                    if (Char.IsDigit(letter))
                    {
                        counter++;
                    }
                }
                if (counter > 0)
                    ListWords.Add(word);
                if (counter > maxAmountOfNumbers)
                    maxAmountOfNumbers = counter;
            }

            if (counter == 0)
            { Console.WriteLine("В тексте отсутствуют числа"); }
            else
            {
                foreach (string word in ListWords)
                {
                    counter = 0;
                    foreach (char letter in word)
                    {
                        if (Char.IsDigit(letter))
                        {
                            counter++;
                        }
                    }
                    if (counter == maxAmountOfNumbers)
                        FinalListWords.Add(word);
                }
                foreach (string word in FinalListWords)
                {
                    Console.WriteLine(word);
                }
            }
        }

        public static void FindTheLongestWord(string text)
        {
            string[] words = text.Split(new char[] { ' ', '.', ',', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            int index = 0;
            int length = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > length)
                {
                    length = words[i].Length;
                    index = i;
                }
            }
            string theLongestWord = words[index];

            Regex regex = new Regex(theLongestWord, RegexOptions.IgnoreCase);
            int count = 0;
            foreach (string word in words)
            {
                if (regex.IsMatch(word))
                    count++;
            }

            Console.Write($"Cамое длинное слово - {theLongestWord}, встречается в тексте {count} раз/раза");
        }

        public static void FindWordWithTheSameLetterAtFirstAndLastPosition(string text)
        {
            string[] words = text.Split(new char[] { ' ', '.', ',', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> listWords = new List<string> ();

            foreach (var item in words)
            {
                if (item.EndsWith(Convert.ToString(item[0]), StringComparison.OrdinalIgnoreCase) && item.Length > 1)
                {
                    listWords.Add(item);
                }
            }

            foreach (string word in listWords) 
            {
                Console.WriteLine(word);
            }
        }
    }
}
