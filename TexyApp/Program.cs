using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
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
           

            var sectionLength = text.Length / 4;
            var total = 0;

            IList<char[]> sections = new List<char[]>();
            sections.Add(text.Take(sectionLength).ToArray());
            sections.Add(text.Skip(1 * sectionLength).Take(sectionLength).ToArray());
            sections.Add(text.Skip(2 * sectionLength).Take(sectionLength).ToArray());
            sections.Add(text.Skip(3 * sectionLength).Take(sectionLength).ToArray());


            Parallel.For(0, 4, index =>
            {               

                var count = 0;
                for (int i = 0; i < sections[(int)index].Length - 1; i++)
                {
                    if (sections[(int)index].AsSpan().Slice(i, 2)[0] == 't' && sections[(int)index].AsSpan().Slice(i, 2)[1] == 'o')
                        count++;
                }
                total = total + count;
                //Console.WriteLine("Task{0} -> Count : {1}",index, count);
            });


            Console.WriteLine("Count : {0}", total);
        }
    }
}
