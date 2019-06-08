using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
namespace TexyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\Data\books\Pride_and_prejudice.txt";
            var summary = BenchmarkRunner.Run<WordAnalysis>();
        }

        


    }


    public class WordAnalysis
    {
        [Benchmark]
        public void GetMostUsedWordsUsingLinq()
        {
            string filePath= @"D:\Data\books\Pride_and_prejudice.txt";
            var text = System.IO.File.ReadAllText(filePath);
            var words = text.Split(" ");
            var distinctWords = words.Distinct();
            var wordGroups = words.GroupBy(w => w);
            foreach (var g in wordGroups.OrderByDescending(g => g.Count()).Take(10))
            {
                Console.WriteLine($"{g.Key.Trim()} -> {g.Count()}");
            }
        }

        [Benchmark]
        public void GetMostUsedWords()
        {
            string filePath = @"D:\Data\books\Pride_and_prejudice.txt";

            var text = System.IO.File.ReadAllText(filePath);
            var words = text.Split(" ");


            var dic = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (dic.ContainsKey(words[i]))
                {
                    dic[words[i]]++;
                }
                else
                {
                    dic.Add(words[i], 1);
                }

            }

            foreach (var d in dic.OrderByDescending(d => d.Value).Take(10))
            {
                Console.WriteLine($"{d.Key} -> {d.Value}");
            }
        }
    }
}
