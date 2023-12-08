using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input.txt");
        int sum = 0;
        foreach (string line in lines)
        {
            string cardData = line.Substring(line.IndexOf(":") + 1).Trim().Replace("  ", " ");

            string[] cardParts = cardData.Split('|');
            string[] winningNumbers = cardParts[0].Trim().Split(" ");
            string[] elfsNumbers = cardParts[1].Trim().Split(" ");

            List<int> winningNumbersList = winningNumbers.Select(int.Parse).ToList();
            List<int> elfsNumbersList = elfsNumbers.Select(int.Parse).ToList();
            List<int> commonNumbers = winningNumbersList.Intersect(elfsNumbersList).ToList();

            sum += (int)Math.Pow(2, (commonNumbers.Count - 1));
        }
        Console.WriteLine(sum);
        Console.ReadLine();
    }
}