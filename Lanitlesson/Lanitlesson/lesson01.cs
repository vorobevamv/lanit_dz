using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lanitlesson
{
    class lesson01
    {
        static void Main()
        {
            ConcreteMediator m = new ConcreteMediator();

            while (true)
            {
                TextColor.Green("ГЛАВНОЕ МЕНЮ\n " +
                    "почитать сказку - введите 1\n " +
                    "записать код  в файл - введите 2\n " +
                    "вычислить элемент последовательности Фибоначчи - введите 3\n " +
                    "провести сериализацию массива в *json или в *xml - введите 4\n " +
                    "поработать с БД библиотек (SQL) - введите 5\n " +
                    "поработать с БД аренды автомобилей (LINQ) - введите 6\n ");

                string otvetMediator = Console.ReadLine();
                m.Start(otvetMediator);
            }

            //MenuDZ.Call();
        }
    }
}



































