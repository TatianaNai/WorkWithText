using TextReader;

string text = Console.ReadLine();

Console.WriteLine("Выберете необходимое действие");
Console.WriteLine("1 - Найти слова с максимальным количеством цифр"); 
Console.WriteLine("2 - Найти самое длинное слово"); 
Console.WriteLine("3 - Заменить цифры на слова");
Console.WriteLine("4 - Вывести на экран вопросительные и восклицательные предложения"); 
Console.WriteLine("5 - Вывести предложения без запятых"); 
Console.WriteLine("6 - Найти слова начинающиеся и заканчивающиеся на одну букву"); 

string choice = Console.ReadLine();
switch (choice)
{
    case "1":
        WordsFinder.FindWordsWithMaxNumbers(text);
        break;
    case "2":
        WordsFinder.FindTheLongestWord(text);
        break;
    case "3":
        Sentences.SwitchNumberToWord(text);
        break;
    case "4":
        Sentences.FindSentencesWithQuestionExclamationMark(text);
        break;
    case "5":
        Sentences.FindSentencesWithoutComma(text);
        break;
    case "6":
        WordsFinder.FindWordWithTheSameLetterAtFirstAndLastPosition(text);
        break;
    default:
        Console.WriteLine("Некорректный ввод");
        break;
}



