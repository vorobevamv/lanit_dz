using System;


namespace Lanitlesson
{
    class Konek:Homework
    {
        public Konek (IMediator mediator) : base(mediator) { }

        public override void Start() //ReadKonek
        {
            using (StreamReader stream = new StreamReader("konyok-gorbunok.txt"))
            {
                List<string> konekList = new List<string>();
                string s;
                int konekCount = 0;
                int nLines = 0;
                int firstLine = 0;
                int lastLine = 0;
                string otvet;

                while ((s = stream.ReadLine()) != null)
                {
                    konekList.Add(s);
                    konekCount++;
                }

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
                                nLines = Convert.ToInt32(Console.ReadLine());
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
                            if (nLines < 0)
                            {
                                TextColor.Blue("Вы ввели отрицательное число строк, оно будет взято по модулю");
                                nLines = Math.Abs(nLines);
                            }
                            lastLine = firstLine + nLines;
                            if (lastLine >= konekCount)
                            {
                                TextColor.Blue("До конца осталось меньше строк, чем Вы хотите прочитать. Вот все оставшиеся: ");
                                lastLine = konekCount;

                                for (int j = firstLine; j < lastLine; j++)
                                {
                                    Console.WriteLine(konekList[j]);
                                }

                                TextColor.Blue("При продолжении чтения сказка будет начата с начала.");
                                firstLine = 0;
                                break;
                            }
                            else
                            {
                                for (int j = firstLine; j < lastLine; j++)
                                {
                                    Console.WriteLine(konekList[j]); 
                                }

                                firstLine = lastLine;

                                Console.WriteLine();
                                TextColor.Green("Хотите почитать ещё - введите 1; \n хотите выйти - введите 2");
                                otvet = Console.ReadLine();

                                if (otvet == "2")
                                {
                                    firstLine = 0;
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
                //MenuDZ.Call();
            }
        }
    }
}
