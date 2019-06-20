using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TexyApp
{
    public class WordToStat
    {
        [Benchmark]
        public void CountWordsMemoryIndex()
        {
            string filePath = @"D:\Data\books\Pride_and_prejudice.txt";
            var text = System.IO.File.ReadAllText(filePath).ToCharArray().AsMemory<Char>();
            var s = text.Slice(1, 2);

            var count = 0;
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text.Slice(i, 2).Span[0] == 't' && text.Slice(i, 2).Span[1] == 'o')
                    count++;
            }
            Console.WriteLine("Count : {0}", count);
        }
        [Benchmark]
        public void CountWordsSpanIndex()
        {
            string filePath = @"D:\Data\books\Pride_and_prejudice.txt";
            var text = System.IO.File.ReadAllText(filePath).ToCharArray().AsSpan<Char>();
            var count = 0;
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text.Slice(i, 2)[0] == 't' && text.Slice(i, 2)[1] == 'o')
                    count++;
            }
            Console.WriteLine("Count : {0}", count);
        }

        [Benchmark]
        public void CountWordsSpanToString()
        {
            string filePath = @"D:\Data\books\Pride_and_prejudice.txt";
            var text = System.IO.File.ReadAllText(filePath).ToCharArray().AsSpan<Char>();
            var count = 0;
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text.Slice(i, 2).ToString() == "to")
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
