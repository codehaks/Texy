using BenchmarkDotNet.Running;
using System;
using System.Linq;

namespace TexyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = @"D:\Data\books\Pride_and_prejudice.txt";
            //var summary = BenchmarkRunner.Run<WordCountStat>();
            BenchmarkRunner.Run<WordToStat>();
            
        }
    }
}
