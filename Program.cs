using System;

namespace bitmapBfs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var bmp = new Bitmap(@"c:\temp\matrix.txt");
            var count = bmp.CountAreas();
            System.Console.WriteLine($"areas: {count}");
        }
    }
}
