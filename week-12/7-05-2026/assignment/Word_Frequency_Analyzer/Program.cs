using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = "The quick brown fox jumps over the lazy dog. The fox is quick and the dog is lazy. Quick brown fox jumps over the lazy dog again.";

        int N = 3;

        // Convert to lowercase and remove punctuation
        string cleanedText = Regex.Replace(text.ToLower(), @"[^\w\s]", "");

        // Split into words
        string[] words = cleanedText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Dictionary to store word frequency
        Dictionary<string, int> frequency = new Dictionary<string, int>();

        // Count frequencies
        foreach (string word in words)
        {
            if (frequency.ContainsKey(word))
                frequency[word]++;
            else
                frequency[word] = 1;
        }

        Console.WriteLine("--- Word Frequency Analysis ---\n");

        // Total words
        Console.WriteLine($"Total words: {words.Length}");

        // Unique words
        Console.WriteLine($"Unique words: {frequency.Count}\n");

        // Top N frequent words
        Console.WriteLine($"Top {N} Frequent Words:\n");

        var topWords = frequency
            .OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .Take(N);

        foreach (var item in topWords)
        {
            Console.WriteLine($"{item.Key}: {item.Value} times");
        }

        // Words appearing exactly once
        Console.WriteLine("\nWords appearing exactly once:\n");

        var singleWords = frequency
            .Where(x => x.Value == 1)
            .Select(x => x.Key)
            .OrderBy(x => x);

        Console.WriteLine(string.Join(", ", singleWords));

        // Average frequency
        double averageFrequency = (double)words.Length / frequency.Count;

        Console.WriteLine($"\nAverage frequency: {averageFrequency:F2} times per unique word");
    }
}