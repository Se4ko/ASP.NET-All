﻿﻿using System;
using System.Text.RegularExpressions;

class Program
{
    static int width, height, depth;
    static int[, ,] cube;
    static int result = 0;
    static int totalSum = 0;

    static void Input()
    {
        string[] dimensions = Console.ReadLine().Split();

        width = int.Parse(dimensions[0]);
        height = int.Parse(dimensions[1]);
        depth = int.Parse(dimensions[2]);

        cube = new int[width, height, depth];

        for (int h = 0; h < height; h++)
        {
            string[] line = Regex.Split(Console.ReadLine(), @" \| ");

            for (int d = 0; d < depth; d++)
            {
                string[] line1 = line[d].Split();

                for (int w = 0; w < width; w++)
                    totalSum += cube[w, h, d] = int.Parse(line1[w]);
            }
        }
    }

    static void PrintCube()
    {
#if DEBUG
        for (int d = 0; d < depth; d++)
        {
            for (int h = 0; h < height; h++)
                for (int w = 0; w < width; w++)
                    Console.Write(cube[w, h, d] + (w == width - 1 ? "\n" : " "));

            if (d < depth - 1) Console.WriteLine();
        }
#endif
    }

    static void Output()
    {
        Console.WriteLine(result);
    }

    static void Count()
    {
        int currentSum;

        currentSum = 0;
        for (int w = 0; w < width - 1; w++)
        {
            for (int h = 0; h < height; h++)
                for (int d = 0; d < depth; d++)
                    currentSum += cube[w, h, d];

            if (currentSum == totalSum / 2) result++;
        }

        currentSum = 0;
        for (int h = 0; h < height - 1; h++)
        {
            for (int d = 0; d < depth; d++)
                for (int w = 0; w < width; w++)
                    currentSum += cube[w, h, d];

            if (currentSum == totalSum / 2) result++;
        }

        currentSum = 0;
        for (int d = 0; d < depth - 1; d++)
        {
            for (int w = 0; w < width; w++)
                for (int h = 0; h < height; h++)
                    currentSum += cube[w, h, d];

            if (currentSum == totalSum / 2) result++;
        }
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        Input();

        PrintCube();

        Count();

        Output();
    }
}
