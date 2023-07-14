using System;
using static System.Net.Mime.MediaTypeNames;

namespace Directory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
            //System.IO.Directory.CreateDirectory("Test");
            //System.IO.Directory.CreateDirectory(@"D:\Test");
            //var di = System.IO.Directory.CreateDirectory(@"D:\Test");
            //Console.WriteLine(di.Name);

            //if (System.IO.Directory.Exists(@"D:\Test"))
            //    System.IO.Directory.Delete(@"D:\Test");

            Console.WriteLine(System.IO.Directory.GetCreationTime(@"D:\Test"));
            Console.WriteLine(System.IO.Directory.GetLastAccessTime(@"D:\Test"));
       
        
        }
    }
}
