using System;
using System.IO;

namespace Directories_and_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = "--- Directories & Files ---";
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.WriteLine(title);

            Console.WriteLine("Please enter a directory path to get file info >>");
            string path = Console.ReadLine();

            while (Directory.Exists(path) == false)
            {
                Console.WriteLine("Directory path doesn't exist, please try again >>");
                path = Console.ReadLine();
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            foreach (var file in directoryInfo.GetFiles())
            {
                Console.WriteLine(file.Name);
            }

            Console.ReadKey();
        }
    }
}
