using System.Text.RegularExpressions;
const int MAX_RED = 12;
const int MAX_GREEN = 13;
const int MAX_BLUE = 14;

string[] lines = File.ReadAllLines("input.txt");

int conter = 0;
foreach (string line in lines)
{
    string[] split = line.Split(":");
    int game = int.Parse(split[0].Split(" ")[1]);
    string[] bagContents = split[1].Split(":");
    var max = new Dictionary<string, int>() {{"red", 0}, {"green", 0}, {"blue", 0}};
    foreach(var content in bagContents)
    {
        string pattern = @"(\d+) (\w+)";
        MatchCollection matches = Regex.Matches(content, pattern);
        foreach(Match match in matches)
        {
            int number = Int32.Parse(match.Groups[1].Value);
            string color = match.Groups[2].Value;
            max[color] = (max[color] >= number)? max[color] : number;
        }
    }

    conter += (max["red"] <= MAX_RED && max["green"] <= MAX_GREEN && max["blue"] <= MAX_BLUE) ? game : 0;
}
Console.WriteLine(conter);
Console.ReadLine();

//Output 2156