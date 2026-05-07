using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] accessLog = { 1, 3, 2, 3, 3, 4, 5, 3, 6, 7, 8, 9, 10, 3 };
        int K = 2;

        Console.WriteLine("--- Access Pattern Analysis ---\n");

        // -------------------------------
        // 1. Longest Consecutive Sequence
        // -------------------------------
        HashSet<int> set = new HashSet<int>(accessLog);

        int longestLength = 0;
        List<int> longestSequence = new List<int>();

        foreach (int num in set)
        {
            // Start only if previous number doesn't exist
            if (!set.Contains(num - 1))
            {
                List<int> currentSequence = new List<int>();
                int currentNum = num;

                while (set.Contains(currentNum))
                {
                    currentSequence.Add(currentNum);
                    currentNum++;
                }

                if (currentSequence.Count > longestLength)
                {
                    longestLength = currentSequence.Count;
                    longestSequence = currentSequence;
                }
            }
        }

        Console.WriteLine("Longest Consecutive Sequence: " +
            string.Join(",", longestSequence) +
            $" (Length: {longestLength})\n");

        // -------------------------------
        // 2. Most Frequent Element
        // -------------------------------
        Dictionary<int, int> frequency = new Dictionary<int, int>();

        foreach (int num in accessLog)
        {
            if (frequency.ContainsKey(num))
                frequency[num]++;
            else
                frequency[num] = 1;
        }

        var mostFrequent = frequency.OrderByDescending(x => x.Value).First();

        Console.WriteLine($"Most Frequent Element: {mostFrequent.Key} " +
            $"(appears {mostFrequent.Value} times)\n");

        // -------------------------------
        // 3. First Non-Repeating Element
        // -------------------------------
        int firstNonRepeating = -1;

        foreach (int num in accessLog)
        {
            if (frequency[num] == 1)
            {
                firstNonRepeating = num;
                break;
            }
        }

        Console.WriteLine($"First Non-Repeating Element: {firstNonRepeating}\n");

        // -------------------------------
        // 4. Pairs with Difference K
        // -------------------------------
        Console.WriteLine($"Pairs with Difference {K}:\n");

        HashSet<string> printedPairs = new HashSet<string>();

        foreach (int num in set)
        {
            if (set.Contains(num + K))
            {
                string pair = $"({num}, {num + K})";

                if (!printedPairs.Contains(pair))
                {
                    Console.WriteLine(pair);
                    printedPairs.Add(pair);
                }
            }
        }

        // -------------------------------
        // 5. Majority Element
        // -------------------------------
        int n = accessLog.Length;

        var majorityCandidate = frequency
            .OrderByDescending(x => x.Value)
            .First();

        double percentage = (double)majorityCandidate.Value / n * 100;

        Console.WriteLine();

        if (majorityCandidate.Value > n / 2)
        {
            Console.WriteLine($"Majority Element: {majorityCandidate.Key} " +
                $"(appears {majorityCandidate.Value} out of {n} times)");
        }
        else
        {
            Console.WriteLine($"Majority Element: {majorityCandidate.Key} " +
                $"(appears {majorityCandidate.Value} out of {n} times - " +
                $"{percentage:F1}% - No majority)");
        }
    }
}