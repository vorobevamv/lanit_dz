using System;


namespace Lanitlesson
{
    class Fibonachchi : Homework
    {
        public Fibonachchi(IMediator mediator) : base(mediator){ }
        

        public override void Start() //CountFibo
        {
            int countFibo=0;
            string otvet;
            long firstNumber = 0;
            long lastNumber = 1;
            long Fibo = default;

            TextColor.Green("Чтобы посчитать элемент последовательности Фибоначчи, введите 1; \n чтобы выйти в главное меню, нажмите другую клавишу");
            otvet = Console.ReadLine();

            if (otvet == "1")
            {
                while (true)
                {
                    TextColor.Green("Какой элемент последовательности вычислисть (введите целое число больше нуля)?");
                    try
                    {
                        countFibo = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        TextColor.Red("Пожалуйста, введите целое число!\n" + e.Message);
                        continue;
                    }
                    catch (Exception e)
                    {
                        TextColor.Red("Что-то пошло не так..\n" + e.Message);
                        continue;
                    }
                    if (countFibo < 0)
                    {
                        TextColor.Blue("Вы ввели отрицательное число, оно будет взято по модулю");
                        countFibo = Math.Abs(countFibo);
                    }
                    if (countFibo == 0)
                    {
                        TextColor.Red("Введите число больше нуля!");
                        continue;
                    }
                    else if (countFibo == 1)
                    {
                        Console.WriteLine("Элемент под номером 1 в последовательности Фибоначчи - это 0");
                        TextColor.Green("Посчитать другой эелемент? - введите 1; \n чтобы выйти, нажмите другую клавишу");
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
                    else if (countFibo == 2)
                    {
                        Console.WriteLine("Элемент под номером 2 в последовательности Фибоначи - это 1");
                        TextColor.Green("Посчитать другой эелемент? - введите 1; \n чтобы выйти, нажмите другую клавишу");
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
                    else
                    {
                        Console.WriteLine(0);
                        Console.WriteLine(1);

                        for (int f = 0; f <= countFibo - 3; f++)
                        {
                            Fibo = firstNumber + lastNumber;
                            Console.WriteLine(Fibo);
                            firstNumber = lastNumber;
                            firstNumber = Fibo;
                        }

                        Console.WriteLine($"Элемент под номером {countFibo} в последовательности Фибоначи - это {Fibo}");
                        TextColor.Green("Посчитать другой эелемент? - введите 1; \n чтобы выйти, нажмите другую клавишу");
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
            //MenuDZ.Call();
        }
    }
}
