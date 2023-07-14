using System;
using System.IO;

namespace File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // System.IO.File.Create("1.txt");
            // System.IO.File.Create(@"D:\1.txt");
            //System.IO.File.Create(@"D:\1.txt");
            //var file = System.IO.File.Open(@"D:\1.txt", FileMode.Open);
            //byte[] bytes = System.Text.Encoding.UTF8.GetBytes("this is a test");
            //file.Write(bytes, 0, bytes.Length);
            //file.Close();
            var file = System.IO.File.Open(@"D:\1.txt", FileMode.Open);
        }
    }
}
