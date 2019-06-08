using System;
using System.Collections.Generic;
using System.Linq;
namespace TexyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\Data\books\pp_sum.txt";

            var text = System.IO.File.ReadAllText(path);
            var words = text.Split(" ");
            var distinctWords=words.Distinct();
            var wordGroups = words.GroupBy(w => w);
            foreach (var g in wordGroups.OrderByDescending(g=>g.Count()))
            {
                Console.WriteLine($"{g.Key.Trim()} -> {g.Count()}");
            }

            Console.WriteLine($" Count = {words.Length}, Distinct = {distinctWords.Count()} ");
        }

        
    }
}
