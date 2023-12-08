using System.Text;

int total_sum = 0;
List<int> list = new List<int>();
string[] lines = File.ReadAllLines("test.txt");

foreach (string str in lines)
{
    int sum = 0;
    foreach (char c in str)
    {
        if (int.TryParse(c.ToString(), out int digit))
        {
            list.Add(digit);
        }
    }
    sum = list[0] * 10 + list[list.Count - 1];
    list.Clear();
    total_sum += sum;
}
Console.WriteLine(total_sum);
Console.ReadLine();
