using System;

namespace Lanitlesson
{
    class MenuDZ

    {
        public static void Call()
        {
            string main_otvet;
            TextColor.Green("ГЛАВНОЕ МЕНЮ\n " +
                "почитать сказку - введите 1\n " +
                "записать код  в файл - введите 2\n " +
                "вычислить элемент последовательности Фибоначчи - введите 3\n " +
                "провести сериализацию массива в *json или в *xml - введите 4\n " +
                "поработать с БД с помощью SQL - введите 5\n " +
                "ВЫХОД - введите 0");

            main_otvet = Console.ReadLine();

            switch (main_otvet)
            {
                case "1":
                    Konek.ReadKonek();
                    break;
                case "2":
                    UrlToFile.ToFile();
                    break;
                case "3":
                    Fibonachchi.CountFibo();
                    break;
               case "4":
                    Serialization.Start();;
                    break;
                case "5":
                    CRUDSQL.Menu();
                    break;
                case "0":
                    //Environment.Exit(0);
                    //System.Threading.Thread.Sleep(3000);
                    Console.Clear();
                    break;
                default:
                    TextColor.Red("в меню нет такого пункта");
                    MenuDZ.Call();
                    break;
            }
        }
    }
}
