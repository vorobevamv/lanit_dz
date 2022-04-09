using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lanitlesson
{
    internal class CRUDLINQ
    {
        public static void Menu()
        {
            string otvetLINQ;

            TextColor.Green("МЕНЮ LINQ\n " +
                "добавить данные о новом клиенте - введите 1\n " +
                "посмотреть данные об аренде автомобилей или данные о клиенте  - введите 2\n " +
                "уточнить номер водительского удостоверения клиента - введите 3\n " +
                "уточнить номер водительского удостоверения клиента - введите 4\n " +
                "ВЫХОД - введите 0");

            otvetLINQ = Console.ReadLine();

            switch (otvetLINQ)
            {
                case "1":
                    CRUDLINQ.Create();
                    break;
                case "2":
                    CRUDLINQ.Read();
                    break;
                case "3":
                    CRUDLINQ.Update();
                    break;
                case "4":
                    CRUDLINQ.Delete();
                    break;
                case "0":
                    MenuDZ.Call();
                    break;
                default:
                    TextColor.Red("в меню нет такого пункта");
                    CRUDSQL.Menu();
                    break;
            }
        }

        public static void Create()
        {
            string otvetName;
            string otvetLicense;
            string otvetAuto;

            TextColor.Green("Введите фамилию нового клиента");
            otvetName = Console.ReadLine();
            TextColor.Green("Введите номер водительского удостоверения (xx xx xxxxxx)");
            otvetLicense = Console.ReadLine();

            TextColor.Blue("Какой автомобиль хотите арендовать?");

            using (DatabaseContext con = new DatabaseContext())
            {
                var d = from a in con.Autos
                        join o in con.Owners on a.ownerID equals o.ID
                        orderby o.City
                        select new { o.City, a.Model, a.Number, a.Year };

                foreach (var p in d)
                {
                    Console.WriteLine(p.City + "--" + p.Model + "--" + p.Number + "--" + p.Year);
                }
            }


            while (true)
            {
                TextColor.Green("Введите марку автомобиля");
                otvetAuto = Console.ReadLine();

                using (DatabaseContext con = new DatabaseContext())
                {
                    var models = con.Autos.Select(x => x.Model).ToList();

                    if (models.Any(x => x == otvetAuto))
                    {
                        DbClients client = new DbClients();
                        client.ID = Guid.NewGuid();
                        client.Name = otvetName;
                        client.License = otvetLicense;

                        con.Clients.Add(client);
                        con.SaveChanges();

                        var autoID = con.Autos.Where(x => x.Model == otvetAuto).FirstOrDefault().ID;

                        string connString = "Server=localhost\\sqlexpress01;Database=OrdersDB;Trusted_Connection=True";
                        SqlConnection conn = new SqlConnection(connString);
                        try
                        {
                            conn.Open();
                            string sqlQuery = @"INSERT INTO Orders VALUES ('" + client.ID + "', '" + autoID + "')";
                            using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                            {
                                int n = command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception e)
                        {
                            TextColor.Red("Что-то пошло не так..\n" + e.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }

                        var d = from o in con.Orders
                                join c in con.Clients on o.clientID equals c.ID
                                join a in con.Autos on o.autoID equals a.ID
                                where o.clientID == client.ID
                                select new { c.Name, c.License, a.Model, a.Number, a.Year };

                        foreach (var p in d)
                        {
                            Console.WriteLine(p.Name + "--" + p.License + "--" + p.Model + "--" + p.Number + "--" + p.Year);
                        }

                        break;
                    }
                    else
                    {
                        TextColor.Red("Такого автомобиля нет в списке, введите существующую модель");
                        continue;
                    }
                }
            }
            using (DatabaseContext con = new DatabaseContext())
            {
                con.Database.Migrate();
            }
            CRUDLINQ.Menu();
        }

        public static void Update()
        {
            string otvetName;
            string otvetLicense;

            TextColor.Blue("Список клиентов:");

            using (DatabaseContext con = new DatabaseContext())
            {
                var d = (from c in con.Clients orderby c.Name select new { c.Name, c.License }).Distinct();
                var clients = con.Clients.Select(x => x.Name).ToList();
                foreach (var p in d)
                {
                    Console.WriteLine(p.Name + "--" + p.License);
                }

                while (true)
                {
                    TextColor.Green("Введите фамилию клиента");
                    otvetName = Console.ReadLine();

                    if (clients.Any(x => x == otvetName))
                    {
                        TextColor.Green("Введите новый номер водительского удостоверения");
                        otvetLicense = Console.ReadLine();

                        var l = con.Clients.Where(x => x.Name == otvetName).FirstOrDefault();
                        l.License = otvetLicense;
                        con.SaveChanges();
                        con.Database.Migrate();

                        TextColor.Blue("Данные изменены");

                        var g = from c in con.Clients.Where(x => x.License == otvetLicense) select new { c.Name, c.License };
                        foreach (var p in g)
                        {
                            Console.WriteLine(p.Name + "--" + p.License);
                        }

                        break;
                    }
                    else
                    {
                        TextColor.Red("Такого клиента нет в списке, уточните фамилию");
                        continue;
                    }
                }
            }
            CRUDLINQ.Menu();
        }

        public static void Read()
        {
            string otvet;
            string otvetCity;
            string otvetClient;

            TextColor.Green("Посмотреть аренду авто в вашем городе, введите 1 \n посмотреть поезки клиента, введите 2");
            otvet = Console.ReadLine();

            if (otvet == "1")
            {
                using (DatabaseContext con = new DatabaseContext())
                {
                    TextColor.Blue("Услуги аренды есть в следующих городах:");
                    var cities = con.Owners.Select(x => x.City).Distinct().ToList();
                    foreach (var p in cities)
                    {
                        Console.WriteLine(p);
                    }


                    while (true)
                    {
                        TextColor.Green("Какой город интересует?");
                        otvetCity = Console.ReadLine();

                        if (cities.Any(x => x == otvetCity))
                        {
                            var g = from o in con.Owners
                                    join a in con.Autos on o.ID equals a.ownerID
                                    where o.City == otvetCity
                                    select new { o.City, o.Name, a.Model, a.Number, a.Year };

                            foreach (var p in g)
                            {
                                Console.WriteLine(p.City + "--" + p.Name + "--" + p.Model + "--" + p.Number + "--" + p.Year);
                            }
                            break;
                        }
                        else
                        {
                            TextColor.Red("Такого города нет в списке");
                            continue;
                        }
                    }
                }
            }
            else if (otvet == "2")
            {
                using (DatabaseContext con = new DatabaseContext())
                {
                    TextColor.Blue("Список клиентов:");
                    var clients = con.Clients.Select(x => x.Name).Distinct().ToList();
                    foreach (var p in clients)
                    {
                        Console.WriteLine(p);
                    }

                    while (true)
                    {
                        TextColor.Green("Какой клиент интересует?");
                        otvetClient = Console.ReadLine();

                        if (clients.Any(x => x == otvetClient))
                        {
                            var b = from or in con.Orders
                                    join c in con.Clients on or.clientID equals c.ID
                                    join a in con.Autos on or.autoID equals a.ID
                                    join ow in con.Owners on a.ownerID equals ow.ID
                                    where c.Name == otvetClient
                                    select new { c.Name, c.License, ow.City, a.Model };

                            foreach (var p in b)
                            {
                                Console.WriteLine(p.Name + "--" + p.License + "--" + p.City + "--" + p.Model);
                            }
                            break;
                        }
                        else
                        {
                            TextColor.Red("Такого клиента нет");
                            continue;
                        }
                    }
                }
            }
            else
            {
                TextColor.Red("Такого варианта нет!");
            }
            CRUDLINQ.Menu();
        }

        public static void Delete()
        {
            string otvetName;
            string otvetLicense;
            string otvetDelete;

            TextColor.Blue("Список клиентов:");

            using (DatabaseContext con = new DatabaseContext())
            {
                var d = (from c in con.Clients orderby c.Name select new { c.Name, c.License }).Distinct();
                var clients = con.Clients.Select(x => x.Name).ToList();
                foreach (var p in d)
                {
                    Console.WriteLine(p.Name + "--" + p.License);
                }

                while (true)
                {
                    TextColor.Green("Введите фамилию клиента");
                    otvetName = Console.ReadLine();

                    if (clients.Any(x => x == otvetName))
                    {
                        while (true)
                        {
                            TextColor.Green("Введите номер водительского удостоверения");
                            otvetLicense = Console.ReadLine();

                            var licenses = con.Clients.Where(x => x.Name == otvetName).Select(x => x.License).ToList();
                       
                            if (licenses.Any(x => x == otvetLicense))
                            {
                                TextColor.Green($"Удалить запись {otvetName} -- {otvetLicense}? (чтобы удалить, введите 'y')");
                                otvetDelete = Console.ReadLine();

                                if (otvetDelete == "y")
                                {
                                    var clientToDelete = con.Clients.Where(x=>x.Name == otvetName && x.License==otvetLicense).FirstOrDefault();
                                    con.Clients.Remove(clientToDelete);
                                    con.SaveChanges();
                                    con.Database.Migrate();

                                    TextColor.Blue("Элемент удалён");
                                    break;
                                }
                                else
                                {
                                    CRUDLINQ.Menu();
                                }
                            }
                            else
                            {
                                TextColor.Red("Такого клиента нет в списке, уточните номер водительского удостоверения");
                                continue;
                            }

                        }
                        break;
                    }
                    else
                    {
                        TextColor.Red("Такого клиента нет в списке, уточните фамилию");
                        continue;
                    }
                }
                con.Database.Migrate();
            }
            CRUDLINQ.Menu();
        }
    }
}