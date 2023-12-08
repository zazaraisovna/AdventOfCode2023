using System.Text;

int total_sum = 0;
Dictionary<string, int> spelledOutDigits = new Dictionary<string, int>
        {
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9}
        };
List<int> list = new List<int>();

string[] lines = File.ReadAllLines("test.txt");
foreach (string str in lines)
{
    int sum = 0;
    string currentNumber = "";
    int word_index;
    int word_value;

    foreach (char ch in str.ToCharArray())
    {

    }
      foreach (KeyValuePair<string, int> words in spelledOutDigits)
      {
          word_index = str.IndexOf(words.Key);
          if (word_index != -1)
          {
            word_value = words.Value;
            Console.WriteLine(word_value);
            break;
          }
      }

      foreach (char c in str)
      {
          if (char.IsDigit(c))
          {
              if (int.TryParse(c.ToString(), out int digit))
              {
                  list.Add(digit);
              }
              currentNumber = "";
          }
          else if (currentNumber.Length > 0)
          {
              if (spelledOutDigits.ContainsKey(currentNumber))
              {
                  if (spelledOutDigits.ContainsKey(currentNumber))
                  {
                      list.Add(spelledOutDigits[currentNumber]);
                  }
                  currentNumber = ""; // Reset for the next potential spelled-out digit
              }
          }

          if (spelledOutDigits.ContainsKey(currentNumber))
          {
              list.Add(spelledOutDigits[currentNumber]);
          }
      }
      int firstDigit = list[0];
      int lastDigit = list[list.Count - 1];
      sum = firstDigit * 10 + lastDigit;

      StringBuilder digitStringBuilder = new StringBuilder();
      foreach (int li in list)
      {
          digitStringBuilder.Append(li);
      }
      Console.WriteLine(digitStringBuilder.ToString());

      Console.WriteLine("sum = " + sum);
      list.Clear();
      total_sum += sum;
}




/*
    int j = 0;
    while (j < input.Length && !char.IsDigit(input[j])) j++;
    return input[j];


 * public static int GetSum(List<string> input)
{
    List<int> num = new();

    for (int i = 0; i < input.Count; i++)
    {
        string reversed = new string(input[i].ToCharArray().Reverse().ToArray()); //reversing the array, so the GetNumber can search the end of the string
        char[] numbers = { input[i].GetNumber(), reversed.GetNumber() };

        num.Add(Convert.ToInt32(new string(numbers)));
    }
    return num.Sum();
}*/

Console.WriteLine("total_sum = " + total_sum);
Console.ReadLine();