using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TexyApp
{
    public class WordCountStat
    {
        [Benchmark]
        public void CountWordsSplit()
        {
            string filePath = @"D:\Data\books\Pride_and_prejudice.txt";
            var text = System.IO.File.ReadAllText(filePath);
            var count = text.Split(" ").Length;
            Console.WriteLine("Count : {0}", count);
        }

        [Benchmark]
        public void CountWordsSpan()
        {
            string filePath = @"D:\Data\books\Pride_and_prejudice.txt";
            var text = System.IO.File.ReadAllText(filePath).ToCharArray().AsSpan<Char>();
            var count = 0;
            for (int i = 0; i < text.Length-1; i++)
            {
                if (text.Slice(i,1)[0]==' ')
                {
                    count++;
                }
            }
            Console.WriteLine("Count : {0}", count);
        }

        [Benchmark]
        public void CountWordsSpan2()
        {
            string filePath = @"D:\Data\books\Pride_and_prejudice.txt";
            var text = System.IO.File.ReadAllText(filePath).ToCharArray().AsSpan<Char>();
            var count = 0;
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == ' ') count++;
            }
            Console.WriteLine("Count : {0}", count);
        }

        [Benchmark]
        public void CountWordsCharArray()
        {
            string filePath = @"D:\Data\books\Pride_and_prejudice.txt";
            var text = System.IO.File.ReadAllText(filePath);
            var count = 0;
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == ' ') count++;
            }
            Console.WriteLine("Count : {0}", count);
        }

        [Benchmark]
        public void CountWordsSubString()
        {
            string filePath = @"D:\Data\books\Pride_and_prejudice.txt";
            var text = System.IO.File.ReadAllText(filePath);
            var count = 0;
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text.Substring(i,1) == " ") count++;
            }
            Console.WriteLine("Count : {0}", count);
        }
    }
}
