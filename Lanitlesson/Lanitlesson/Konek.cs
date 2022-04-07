using System;


namespace Lanitlesson
{
    class Konek
    {
        public static void ReadKonek()
        {
            using (StreamReader stream = new StreamReader("konyok-gorbunok.txt"))
            {
                List<string> konek_list = new List<string>();
                string s;
                int konek_count = 0;
                int n_lines = 0;
                int n1 = 0;
                int n2 = 0;
                string otvet;
                while ((s = stream.ReadLine()) != null)
                {
                    //Console.WriteLine(s);
                    konek_list.Add(s);
                    konek_count++;
                }
                //Console.WriteLine(konek_list[0]);
                while (true)
                {
                    TextColor.Green("Хотите почитать, введите 1; \n хотите выйти в главное меню, нажмите 2");
                    otvet = Console.ReadLine();
                    if (otvet == "2")
                    {
                        break;
                    }
                    else if (otvet == "1")
                    {
                        while (true)
                        {
                            TextColor.Green("Сколько cтрок хотите прочитать?");
                            try
                            {
                                n_lines = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException e)
                            {
                                TextColor.Red("Пожалуйста, введите целое число! \n" + e.Message);
                                continue;
                            }
                            catch (Exception e)
                            {
                               TextColor.Red("Что-то пошло не так.. \n" + e.Message);
                                continue;
                            }
                            if (n_lines < 0)
                            {
                                TextColor.Blue("Вы ввели отрицательное число строк, оно будет взято по модулю");
                                n_lines=Math.Abs(n_lines);
                            }
                            n2 = n1 + n_lines;
                            if (n2 >= konek_count)
                            {
                                TextColor.Blue("До конца осталось меньше строк, чем Вы хотите прочитать. Вот все оставшиеся: ");
                                n2 = konek_count;
                                for (int j = n1; j < n2; j++)
                                {
                                    Console.WriteLine(konek_list[j]);
                                }
                                TextColor.Blue("При продолжении чтения сказка будет начата с начала.");
                                n1 = 0;
                                break;
                            }
                            else
                            {
                                for (int j = n1; j < n2; j++)
                                {
                                    Console.WriteLine(konek_list[j]); 
                                }
                                n1 = n2;
                                Console.WriteLine();
                                TextColor.Green("Хотите почитать ещё - введите 1; \n хотите выйти - введите 2");
                                otvet = Console.ReadLine();
                                if (otvet == "2")
                                {
                                    n1 = 0;
                                    break;
                                }
                                else if (otvet == "1")
                                {
                                    continue;
                                }    
                                else
                                {
                                    TextColor.Red("Такого варианта нет, попробуйте ещё раз");
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        TextColor.Red("Такого варианта нет, попробуйте ещё раз");
                        continue;
                    }
                }
                MenuDZ.Call();
            }
        }
    }
}
