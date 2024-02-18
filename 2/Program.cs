namespace TEST2
{
    class Program
    {
        static void Main()
        { 
            string inputFilePath = @"C:\Users\user\source\3 семестр\TEST2\input.txt";
            string outputFilePath = @"C:\Users\user\source\3 семестр\TEST2\output.txt";

            // Чтение текстового файла
            string text = File.ReadAllText(inputFilePath);

            // Разделение текста на слова и подсчет количества употреблений каждого слова
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            string[] words = text.Split(new char[] { ' ', '\n', '\r', '\t', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                string cleanedWord = word.ToLower(); // Приводим к нижнему регистру
                if (wordCount.ContainsKey(cleanedWord))
                    wordCount[cleanedWord]++;
                else
                    wordCount[cleanedWord] = 1;
            }

            // Сортировка по убыванию количества употреблений
            var sortedWordCount = wordCount.OrderByDescending(w => w.Value);

            // Запись результатов в текстовый файл
            using (StreamWriter outputFile = new StreamWriter(outputFilePath))
            {
                foreach (var word in sortedWordCount)
                {
                    outputFile.WriteLine($"{word.Key} {word.Value}");
                }
            }

            Console.WriteLine("Анализ завершен. Результаты сохранены в файле output.txt");
        }
    }
}