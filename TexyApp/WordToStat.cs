using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexyApp
{
    public class MyWordToStat
    {
        //[Benchmark]
        public void MyCountWordsSubString()
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

        //[Benchmark]
        public void MyCountWordsSpanIndex()
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
        public void MyCountWordsSpanIndexParallel()
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
