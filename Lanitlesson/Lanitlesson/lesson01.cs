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

                //var owner1 = con.Owners.Where(x => x.City == "Murmansk").FirstOrDefault();
                // var owner2 = con.Owners.Where(x => x.City == "Kaliningrad").FirstOrDefault();
                // var owner3 = con.Owners.Where(x => x.City == "Vladivostok").FirstOrDefault();
                //var owner4 = con.Owners.Where(x => x.City == "Krasnodar").FirstOrDefault();


                con.Autos.Add(new DbAutos {ID = Guid.NewGuid(), Model = "Mazda", Year = 2007, 
                    OwnerID = new Guid("5A905335-AA28-4C35-9CB6-2602F2CC7652"), Number = "M222MM"});

                //con.Owners.Add(new DbOwners { ID = Guid.NewGuid(), City = "Pskov", Name = "fgfgfg" });
                //con.Clients.Add(new DbClients { ID = Guid.NewGuid(), Name = "Belyi", License = "99 11 333333" });
                //con.ClientsAutos.Add(new DbClientsAutos { clientID = new Guid("9FD2BD32-C558-4011-938C-1947E4777C92"), autoID = Guid.NewGuid()});
                
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



































