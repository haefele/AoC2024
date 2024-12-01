﻿using System.Globalization;
using System.Text.RegularExpressions;

namespace AoC2024;

public class Day1 : IDay
{
    public async Task Execute()
    {
        var input = await InputHelper.GetInput("Day1.txt");
        var (left, right) = ParseLists(input);
        
        left.Sort();
        right.Sort();

        var distanceSum = 0;

        for (int i = 0; i < left.Count; i++)
        {
            var leftValue = left[i];
            var rightValue = right[i];

            var distance = Math.Abs(leftValue - rightValue);            
            distanceSum += distance;
        }

        Console.WriteLine(distanceSum);
    }

    private static (List<int> left, List<int> right) ParseLists(string input)
    {
        List<int> left = [];
        List<int> right = [];

        var regex = new Regex(@"(\d+)\s+(\d+)");

        var reader = new StringReader(input);
        while (reader.ReadLine() is string line)
        {
            var match = regex.Match(line);
            if (match.Success)
            {
                left.Add(int.Parse(match.Groups[1].ValueSpan, CultureInfo.InvariantCulture));
                right.Add(int.Parse(match.Groups[2].ValueSpan, CultureInfo.InvariantCulture));
            }
        }

        return (left, right);
    }
}
