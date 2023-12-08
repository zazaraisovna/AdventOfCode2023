using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines("input.txt");

int conter = 0;
foreach (string line in lines)
{
    string[] split = line.Split(":");
    int game = int.Parse(split[0].Split(" ")[1]);
    string[] bagContents = split[1].Split(":");
    var max = new Dictionary<string, int>();
    foreach (var content in bagContents)
    {
        string pattern = @"(\d+) (\w+)";
        MatchCollection matches = Regex.Matches(content, pattern);
        foreach (Match match in matches)
        {
            int number = int.Parse(match.Groups[1].Value);
            string color = match.Groups[2].Value;
            if (!max.ContainsKey(color))
                max[color] = number;
            else if (number > max[color])
                max[color] = number;
        }
    }

    conter += max.Values.Aggregate(1,(total, value) => total * value);
}
Console.WriteLine(conter);
Console.ReadLine();

//output 66909