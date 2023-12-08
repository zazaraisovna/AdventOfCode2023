using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt");
        int n = lines[0].Length;
        int m = lines[1].Length - 1;
        Console.WriteLine("n = " + n);
        Console.WriteLine("m = " + m);
        char[,] arr = new char[lines[0].Length - 1, lines.Length];
        bool cypher = false;
        for (int i = 0; i < lines[0].Length - 1; i++)
        {
            List<int> number = new List<int>();
            for (int j = 0; j < lines.Length; j++)
            {
                arr[i, j] = lines[i][j];
                if (char.IsDigit(arr[i, j]))
                {
                    number.Add(arr[i, j]);
                    cypher = isCypher(arr, i, j, n, m);
                }
               // else
                //    number.RemoveAll();
                Console.Write(arr[i, j]);
            }
            Console.WriteLine();
        }

        int sum = 0;
        foreach (string line in lines)
        {

        }
        Console.WriteLine();
        Console.ReadLine();
    }

    private static bool isCypher(char[,] arr, int i, int j, int n, int m)
    {
        bool cypher = false;
        cypher = (i > 0) && (j > 0) && (arr[i - 1, j - 1] != '.') && !char.IsDigit(arr[i - 1, j - 1]);
        cypher = (i > 0) && (arr[i - 1, j] != '.') && !char.IsDigit(arr[i - 1, j]) && !cypher;
        cypher = (j > 0) && (arr[i, j - 1] != '.') && !char.IsDigit(arr[i, j - 1]) && !cypher;
        cypher = (i < n) && (j > 0) && (arr[i + 1, j - 1] != '.') && !char.IsDigit(arr[i + 1, j - 1]) && !cypher;
        cypher = (i < n) && (arr[i + 1, j] != '.') && !char.IsDigit(arr[i + 1, j]) && !cypher;
        if((i > 0) && (j < m))
            cypher = ((arr[i - 1, j + 1] != '.') && !char.IsDigit(arr[i - 1, j + 1]) && !cypher);
        cypher = (j < m) && (arr[i, j + 1] != '.') && !char.IsDigit(arr[i, j + 1]) && !cypher;
        cypher = (i < n) && (j < m) && (arr[i + 1, j + 1] != '.') && !char.IsDigit(arr[i + 1, j + 1]) && !cypher;
        return cypher;
    }
}