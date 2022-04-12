using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lanitlesson
{
    class lesson01
    {
        static void Main()
        {
            using (DatabaseContext con = new DatabaseContext())
            {
                con.Database.EnsureCreated();
                //con.Database.Migrate();


                DbCars car = new DbCars();
                car.ID = Guid.NewGuid();
                car.Model = "Ford";
                car.Number = "М111ММ";
                car.Year = 2007;
                car.CompanyID = new Guid("41B8CA89-4FD0-4C9E-AB84-DEA9C9C358E4");
                con.Cars.Add(car);


                con.SaveChanges();
            }



            /* ConcreteMediator m = new ConcreteMediator();

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
             }*/

            //MenuDZ.Call();

        }
    }
}



































