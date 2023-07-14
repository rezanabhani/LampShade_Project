using System;
using System.IO;

namespace Streams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(@"D:\1.txt"));
            StreamReader sr = new StreamReader(ms);

            //Console.WriteLine(sr.ReadToEnd());

            //    string result;
            //    while ((result = sr.ReadLine()) != null)
            //    {
            //        if (result.Contains("age"))
            //        {
            //            Console.WriteLine(result);
            //            break;
            //        }
            //    }
            //}
             
            StreamWriter sw = new StreamWriter(@"D:\1.txt");

        }
    }
}
