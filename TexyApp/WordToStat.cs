﻿using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TexyApp
{
    public class WordToStat
    {
        [Benchmark]
        public void CountWordsSpan()
        {
            string filePath = @"D:\Data\books\Pride_and_prejudice.txt";
            var text = System.IO.File.ReadAllText(filePath).ToCharArray().AsSpan<Char>();
            var count = 0;
            var toWord = "to".ToCharArray();
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text.Slice(i, 2)[0] == 't' && text.Slice(i, 2)[1] == 'o')
                    count++;
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
                if (text.Substring(i, 2) == "to") count++;
            }
            Console.WriteLine("Count : {0}", count);
        }
    }
}