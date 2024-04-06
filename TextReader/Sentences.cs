using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextReader
{
    public static class Sentences
    {
        public static void FindSentencesWithoutComma(string text)
        {
            bool check1 = text.Contains('.') || text.Contains('!') || text.Contains('?');
            bool check2 = text[text.Length - 1] == '.' || text[text.Length - 1] == '!' || text[text.Length - 1] == '?';
            if (check1 && check2)
            {
                List<string> sentence = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                List<char> symbol = new List<char>();

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '.' || text[i] == '?' || text[i] == '!')
                    {
                        symbol.Add(text[i]);
                    }
                }

                for (int i = 0; i < sentence.Count; i++)
                {
                    if (sentence[i].Contains(','))
                    {
                        sentence.Remove(sentence[i]);
                        symbol.RemoveAt(i);
                        i--;
                    }
                }
                if (sentence.Count == 0)
                { Console.WriteLine("Отсутствуют предложения без запятых."); }
                else
                {
                    for (int i = 0; i < sentence.Count; i++)
                    {
                        Console.Write(sentence[i]);
                        Console.Write(symbol[i]);
                        if (i != sentence.Count - 1)
                        {
                            Console.Write(" ");
                        }
                    }
                }
            }
            else
            {
                if (text.Contains(','))
                { Console.WriteLine("Отсутствуют предложения без запятых или ввод некорректный."); }
                else
                {
                    Console.WriteLine(text);
                }
            }
        }

        public static void FindSentencesWithQuestionExclamationMark (string text)
        {
            string[] textArray = text.Split(' ');
            int indexFirstItem = 0;
            string oneSentence = string.Empty;
            StringBuilder finalResult = new StringBuilder();
            Queue<string> queueofSentences = new Queue<string>();

            if (text.Contains('!') || text.Contains('?'))
            {
                for (int i = 0; i < textArray.Length; i++)
                {
                    if (textArray[i].Contains('.'))
                    {
                        indexFirstItem = i + 1;
                    }
                    else if (textArray[i].Contains('!'))
                    {
                        for (int j = indexFirstItem; j < i + 1; j++)
                        {
                            oneSentence += textArray[j] + " ";
                        }
                        queueofSentences.Enqueue(oneSentence);
                        indexFirstItem = i + 1;
                        oneSentence = string.Empty;
                    }
                    else if (textArray[i].Contains('?'))
                    {
                        for (int j = indexFirstItem; j < i + 1; j++)
                        {
                            oneSentence += textArray[j] + " ";
                        }
                        finalResult.Append(oneSentence);
                        indexFirstItem = i + 1;
                        oneSentence = string.Empty;
                    }
                }

                while (queueofSentences.Count != 0)
                {
                    finalResult.Append(queueofSentences.Dequeue());
                }
                Console.WriteLine(finalResult.ToString());
            }
            else { Console.WriteLine("Отсутствуют вопросительные и восклицательные предложения в тексте."); }
        }
        
        
        public static void SwitchNumberToWord(string text)
        {
            var numbers = new Dictionary<int, string>()
            {
                { 0, "zero"},
                { 1, "one"},
                { 2, "two"},
                { 3, "three"},
                { 4, "four"},
                { 5, "five"},
                { 6, "six"},
                { 7, "seven"},
                { 8, "eight"},
                { 9, "nine"},
            };

            string[] textArray = text.Split();
            for (int i = 0; i < textArray.Length; i++)
            {
                if (Int32.TryParse(textArray[i], out int number) && number >= 0 && number < 10)
                {
                    numbers.TryGetValue(number, out string value);
                    textArray[i] = value;
                }
                else if (Char.IsDigit(textArray[i][0]) && (textArray[i][1] == '.' || textArray[i][1] == ',' 
                    || textArray[i][1] == '!' || textArray[i][1] == '?'))
                {
                    Int32.TryParse(Convert.ToString(textArray[i][0]), out int number2);
                    numbers.TryGetValue(number2, out string value2);
                    textArray[i] = value2 + textArray[i][1];
                }
            }

            foreach (var item in textArray)
            {
                Console.Write(item + " ");
            }
        }
    }
}
