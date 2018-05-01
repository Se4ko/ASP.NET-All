﻿using System;
using System.Numerics;

class Program
{
    static BigInteger[,] dp;

    static char[] input;

    static BigInteger Variations(int start, int stack)
    {
        if (stack < 0) return 0;

        if (start == input.Length)
            return stack == 0 ? 1 : 0;

        if (dp[start, stack] != -1)
            return dp[start, stack];

        BigInteger result = 0;

        if (input[start] == '?' || input[start] == '(')
            result += Variations(start + 1, stack + 1);

        if (input[start] == '?' || input[start] == ')')
            result += Variations(start + 1, stack - 1);

        dp[start, stack] = result;
        return result;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        input = Console.ReadLine().ToCharArray();

        dp = new BigInteger[input.Length, input.Length];

        for (int row = 0; row < dp.GetLength(0); row++)
            for (int col = 0; col < dp.GetLength(1); col++)
                dp[row, col] = -1;

        Console.WriteLine(Variations(0, 0));

#if DEBUG
        for (int row = 0; row < dp.GetLength(0); row++)
        {
            for (int col = 0; col < dp.GetLength(1); col++)
                Console.Write("{0, 3} ", dp[row, col]);

            Console.WriteLine();
        }
#endif
    }
}
