using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;


namespace Lanitlesson
{
    public class UrlToFile: Homework
    {
        public UrlToFile(IMediator mediator) : base(mediator) { }

        public override void Start() //ToFile
        {

            WebClient web = new WebClient();
            string UrlCode;
            string urlurl;
            string otvet;

            while (true)
            {
                TextColor.Green("Введите ссылку");
                urlurl = Console.ReadLine();
                Regex pattern = new Regex(@"https?://([a-z1-9]+.)?[a-z1-9\-]+(\.[a-z]+){1,}/?");

                if (pattern.IsMatch(urlurl))
                {
                    TextColor.Blue("Это ссылка");
                    try
                    {
                        UrlCode = web.DownloadString(urlurl);
                        ///File.WriteAllLines("yndex.txt", YaCode);
                        
                        using (FileStream stream = new FileStream("url_copy.txt", FileMode.OpenOrCreate))
                        {
                            byte[] array = System.Text.Encoding.Default.GetBytes(UrlCode);
                            stream.Write(array, 0, array.Length);
                        }

                        TextColor.Blue("Файл создан");
                    }
                    catch (ArgumentNullException e)
                    {
                        TextColor.Red("ArgumentNullException! Что-то пошло не так..\n" + e.Message);
                    }
                    catch (WebException e)
                    {
                        TextColor.Red("WebException! Что-то пошло не так..\n" + e.Message);
                    }
                    catch (NotSupportedException e)
                    {
                        TextColor.Red("NotSupportedException! Что-то пошло не так..\n" + e.Message);
                    }
                    catch (Exception e)
                    {
                        TextColor.Red("Что-то пошло не так..\n" + e.Message);
                    }
                    break;
                }
                else
                {
                    TextColor.Blue("Это  не ссылка");

                    TextColor.Green("Если хотите ввести другую ссылку, нажмите 1 \n для выхода в главное меню - нажмите любую другую клавишу");
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
        }
    }
}