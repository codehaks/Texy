using BenchmarkDotNet.Running;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TexyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MyWordToStat>();
            //MyCountWordsSpanIndexParallel();
        }

        public static void MyCountWordsSpanIndexParallel()
        {
            string filePath = @"D:\Data\books\Pride_and_prejudice.txt";
            var text = System.IO.File.ReadAllText(filePath);
            var count = 0;

            var sectionLength = text.Length / 4;

            Parallel.For(0, 4, index =>
            {
                var section = text.Skip((int)(index) * sectionLength).Take(sectionLength).ToArray().AsSpan<Char>();

                for (int i = 0; i < section.Length - 1; i++)
                {
                    if (section.Slice(i, 2)[0] == 't' && section.Slice(i, 2)[1] == 'o')
                        count++;
                }
            });


            Console.WriteLine("Count : {0}", count);
        }
    }
}
