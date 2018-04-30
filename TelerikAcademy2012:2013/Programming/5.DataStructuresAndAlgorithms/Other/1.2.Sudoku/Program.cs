﻿using System;
using System.Linq;
using System.Collections.Generic;

struct Coordinates
{
    public int Row { get; private set; }
    public int Col { get; private set; }

    public static readonly Coordinates Zero = new Coordinates();

    public Coordinates(int row, int col)
        : this()
    {
        this.Row = row;
        this.Col = col;
    }

    public override string ToString()
    {
        return string.Format("{0} {1}", this.Row, this.Col);
    }
}

class Program
{
    static char[][] sudoku = null;

    static IList<Coordinates> empty = null;

    static bool IsValid(Coordinates coordinates, char value)
    {
        if (sudoku[coordinates.Row].Contains(value))
            return false;

        if (sudoku.Select(row => row[coordinates.Col]).Contains(value))
            return false;

        var rows = sudoku.Skip((coordinates.Row / 3) * 3).Take(3).ToArray();

        var area = rows.Select(currentRow =>
            currentRow.Skip((coordinates.Col / 3) * 3).Take(3)
        ).SelectMany(cell => cell).ToArray();

        if (area.Contains(value))
            return false;

        return true;
    }

    static IList<Coordinates> GetEmpty()
    {
        var result = new List<Coordinates>();

        for (int row = 0; row < 9; row++)
            for (int col = 0; col < 9; col++)
                if (sudoku[row][col] == '-')
                    result.Add(new Coordinates(row, col));

        return result;
    }

    static void Permutation(int current)
    {
        if (current == empty.Count)
            throw new NotImplementedException(); // TODO

        for (int i = 1; i <= 9; i++)
        {
            var cell = empty[current];
            var value = (char)(i + '0');

            if (IsValid(cell, value))
            {
                sudoku[cell.Row][cell.Col] = value;
                Permutation(current + 1);
                sudoku[cell.Row][cell.Col] = '-';
            }
        }
    }

    static void Print()
    {
        Console.WriteLine(string.Join(Environment.NewLine,
            sudoku.Select(row => string.Concat(row))
        ));
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        sudoku = Enumerable.Range(0, 9)
            .Select(i => Console.ReadLine().ToCharArray())
            .ToArray();

        empty = GetEmpty();

        try
        {
            Permutation(0);
        }
        catch (NotImplementedException)
        {
            Print();
        }

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif
    }
}
