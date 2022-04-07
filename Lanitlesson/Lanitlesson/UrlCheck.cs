/*using System;
using System.Text.RegularExpressions;

namespace Lanitlesson
{
    class UrlCheck
    {
        public static void Check()
        {
            string otvet;
            string urlurl;
            TextColor.Green("Чтобы проверить ссылку, введите 1; \n чтобы выйти в главное меню, нажмите другую клавишу");
            otvet = Console.ReadLine();

            if (otvet == "1")
            {
                while (true)
                {
                    TextColor.Green("Введите ссылку");
                    urlurl = Console.ReadLine();
                    Regex pattern = new Regex(@"https?://([a-z1-9]+.)?[a-z1-9\-]+(\.[a-z]+){1,}/?");
                    if (pattern.IsMatch(urlurl))
                    {
                        TextColor.Blue("Это ссылка");
                    }
                    else
                    {
                        TextColor.Blue("Это  не ссылка");
                    }
                    TextColor.Green("Проверить другую ссылку? - введите 1; \n чтобы выйти, нажмите другую клавишу");
                    otvet = Console.ReadLine();
                    if (otvet == "1")
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            MenuDZ.Call();
        }
    }
}
*/