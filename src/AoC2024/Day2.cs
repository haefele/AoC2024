using System.Globalization;

namespace AoC2024;

public class Day2 : IDay
{
    public async Task Execute()
    {
        var fileContent = await InputHelper.GetInput("Day2.txt");
        var reports = ParseInput(fileContent);

        // Part 1
        var validReportCount = reports
            .Where(r => (IsIncreasing(r) || IsDecreasing(r))  && DistancesAreCorrect(r))
            .Count();

        Console.WriteLine($"Valid report count is {validReportCount}");
    }

    
    private static bool IsIncreasing(List<int> numbers)
    {
        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] < numbers[i - 1])
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsDecreasing(List<int> numbers)
    {
        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                return false;
            }
        }

        return true;
    }

    private static bool DistancesAreCorrect(List<int> numbers)
    {
        for (int i = 1; i < numbers.Count; i++)
        {
            var current = numbers[i];
            var previous = numbers[i - 1];
            
            var difference = Math.Abs(current - previous);
            if (difference < 1 || difference > 3)
            {
                return false;
            }
        }

        return true;
    }

    private static List<List<int>> ParseInput(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var result = new List<List<int>>();

        foreach (var line in lines)
        {
            var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var list = new List<int>();

            foreach (var number in numbers)
            {
                list.Add(int.Parse(number, CultureInfo.InvariantCulture));
            }

            result.Add(list);
        }

        return result;
    }
}
