using System;
using System.Text;

namespace Lanitlesson
{
    class TextColor
    {
        //public string coloredtext;
        public static void Green(string coloredtext)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(coloredtext);
            Console.ResetColor();
        }
        public static void Red(string coloredtext)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(coloredtext);
            Console.ResetColor();
        }
        public static void Blue(string coloredtext)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(coloredtext);
            Console.ResetColor();
        }



    }
}
