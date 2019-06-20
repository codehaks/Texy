using BenchmarkDotNet.Running;
using System;
using System.Linq;

namespace TexyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MyWordToStat>();
        }
    }
}
