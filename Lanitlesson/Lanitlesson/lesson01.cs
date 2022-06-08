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
                
                con.Database.Migrate();


                /*DbCars car = new DbCars();
                car.ID = Guid.NewGuid();
                car.Model = "Ford";
                car.Number = "М111ММ";
                car.Year = 2007;
                car.CompanyID = new Guid("41B8CA89-4FD0-4C9E-AB84-DEA9C9C358E4");
                con.Cars.Add(car);


                con.SaveChanges();*/
            }



            ConcreteMediator mediator = new ConcreteMediator();

            Homework konek = new Konek(mediator);
            Homework urltofile = new UrlToFile(mediator);
            Homework fibonachchi = new Fibonachchi(mediator);
            Homework serialization = new Serialization(mediator);
            Homework crudsql = new CRUDSQL(mediator);
            Homework crudlinq = new CRUDLINQ(mediator);

            mediator.hKonek = konek;
            mediator.hUrlToFile = urltofile;
            mediator.hFibonachchi = fibonachchi;
            mediator.hSerialization = serialization;
            mediator.hCRUDSQL = crudsql;
            mediator.hCRUDLINQ = crudlinq;
            
            while (true)
            {
                TextColor.Green("ГЛАВНОЕ МЕНЮ\n " +
                             "почитать сказку - введите 1\n " +
                             "записать код  в файл - введите 2\n " +
                             "вычислить элемент последовательности Фибоначчи - введите 3\n " +
                             "провести сериализацию массива в *json или в *xml - введите 4\n " +
                             "поработать с БД библиотек (SQL) - введите 5\n " +
                             "поработать с БД аренды автомобилей (LINQ) - введите 6\n ");

                string otvetMenu = Console.ReadLine();

                if (otvetMenu == "1")
                {
                    konek.Activate();
                }
                else if (otvetMenu == "2")
                {
                    urltofile.Activate();
                }
                else if (otvetMenu == "3")
                {
                    fibonachchi.Activate();
                }
                else if (otvetMenu == "4")
                {
                    serialization.Activate();
                }
                else if (otvetMenu == "5")
                {
                    crudsql.Activate();
                }
                else if (otvetMenu == "6")
                {
                    crudlinq.Activate();
                }
                else
                {
                    TextColor.Red("нет такого варианта");
                    continue;
                }
            }
          
          
            //MenuDZ.Call();

        }
    }
}



































