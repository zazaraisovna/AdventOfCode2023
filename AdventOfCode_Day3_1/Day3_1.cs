using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input_.txt");

            int sum = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    char currentChar = lines[i][j];

                    // Check if the current character is a digit and adjacent to a symbol
                    if (char.IsDigit(currentChar) && isCypher(lines, i, j))
                    {
                        // Add the part number to the sum
                        sum += int.Parse(currentChar.ToString());
                    }
                }
            }


        Console.WriteLine(sum);
        Console.ReadLine();
    }

    private static bool isCypher(string[] lines, int row, int col/*char[,] arr, int i, int j, int n, int m*/)
    {
        // Check in all eight directions for symbols
        int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

        for (int i = 0; i < 8; i++)
        {
            int newRow = row + dx[i];
            int newCol = col + dy[i];

            // Check if the new position is within the bounds of the array
            if (newRow >= 0 && newRow < lines.Length && newCol >= 0 && newCol < lines[newRow].Length)
            {
                // Check if the character at the new position is a symbol
                if (lines[newRow][newCol] == '*' || lines[newRow][newCol] == '#' || lines[newRow][newCol] == '+'
                    || lines[newRow][newCol] == '$')
                {
                    return true;
                }
            }
        }

        return false;
    }
}