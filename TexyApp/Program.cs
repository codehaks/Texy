using BenchmarkDotNet.Running;

namespace TexyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = @"D:\Data\books\Pride_and_prejudice.txt";
            var summary = BenchmarkRunner.Run<WordStat>();
        }
    }
}
