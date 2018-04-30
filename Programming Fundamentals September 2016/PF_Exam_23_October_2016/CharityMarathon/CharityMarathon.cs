﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
//01. Charity Marathon
namespace CharityMarathon
{
    class CharityMarathon
    {
        static void Main(string[] args)
        {
            decimal marathonDays = decimal.Parse(Console.ReadLine());
            decimal runners = decimal.Parse(Console.ReadLine());
            decimal laps = decimal.Parse(Console.ReadLine());
            decimal lapLength = decimal.Parse(Console.ReadLine());
            decimal trackCap = decimal.Parse(Console.ReadLine());
            decimal moneyPerKm = decimal.Parse(Console.ReadLine());

            decimal maxRunners = trackCap * marathonDays;
            decimal participants = 0;
            if (runners < maxRunners)
            {
                participants = runners;
            }
            else
            {
                participants = maxRunners;
            }

            decimal meters = participants * laps * lapLength;

            decimal kilometers = meters / 1000;

            decimal totalMoney = kilometers * moneyPerKm;

            Console.WriteLine($"Money raised: {totalMoney:f2}");
        }
    }
}
