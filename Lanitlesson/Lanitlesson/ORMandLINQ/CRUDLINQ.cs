using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lanitlesson
{
   public class CRUDLINQ:Homework
    {
        public CRUDLINQ(IMediator mediator) : base(mediator) { }

        public override void Start() //Menu
        {
            string otvetLINQ;

            TextColor.Green("МЕНЮ LINQ\n " +
                "добавить данные о новом клиенте - введите 1\n " +
                "посмотреть данные об аренде автомобилей или данные о клиенте  - введите 2\n " +
                "уточнить номер водительского удостоверения клиента - введите 3\n " +
                "удалить данные о клиенте - введите 4\n ");
                //+"ВЫХОД - введите 0");

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
                /*case "0":
                    MenuDZ.Call();
                    break;*/
                default:
                    TextColor.Red("в меню нет такого пункта");
                    //CRUDSQL.Start();
                    break;
            }
        }

        public static void Create()
        {
            string otvetName;
            string otvetLicense;
            string otvetCar;

            TextColor.Green("Введите фамилию нового клиента");
            otvetName = Console.ReadLine();
            TextColor.Green("Введите номер водительского удостоверения (xx xx xxxxxx)");
            otvetLicense = Console.ReadLine();

            TextColor.Blue("Какой автомобиль хотите арендовать?");

            using (DatabaseContext con = new DatabaseContext())
            {
                var d = from a in con.Cars
                        join o in con.Companies on a.CompanyID equals o.ID
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
                otvetCar = Console.ReadLine();

                using (DatabaseContext con = new DatabaseContext())
                {
                    var models = con.Cars.Select(x => x.Model).ToList();

                    if (models.Any(x => x == otvetCar))
                    {
                        DbCustomers customer = new DbCustomers();
                        customer.ID = Guid.NewGuid();
                        customer.Name = otvetName;
                        customer.License = otvetLicense;

                        con.Customers.Add(customer);
                        con.SaveChanges();

                        var CarID = con.Cars.Where(x => x.Model == otvetCar).FirstOrDefault().ID;

                        string connString = "Server=localhost\\sqlexpress01;Database=OrdersDB;Trusted_Connection=True";
                        SqlConnection conn = new SqlConnection(connString);
                        try
                        {
                            conn.Open();
                            string sqlQuery = @"INSERT INTO Orders VALUES ('" + customer.ID + "', '" + CarID + "')";
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

                        var d = from o in con.CustomersCars
                                join c in con.Customers on o.CustomerID equals c.ID
                                join a in con.Cars on o.CarID equals a.ID
                                where o.CustomerID == customer.ID
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
            /*using (DatabaseContext con = new DatabaseContext())
            {
                con.Database.Migrate();
            }*/
            //CRUDLINQ.Start();
        }

        public static void Update()
        {
            string otvetName;
            string otvetLicense;

            TextColor.Blue("Список клиентов:");

            using (DatabaseContext con = new DatabaseContext())
            {
                var d = (from c in con.Customers orderby c.Name select new { c.Name, c.License }).Distinct();
                var customers = con.Customers.Select(x => x.Name).ToList();
                foreach (var p in d)
                {
                    Console.WriteLine(p.Name + "--" + p.License);
                }

                while (true)
                {
                    TextColor.Green("Введите фамилию клиента");
                    otvetName = Console.ReadLine();

                    if (customers.Any(x => x == otvetName))
                    {
                        TextColor.Green("Введите новый номер водительского удостоверения");
                        otvetLicense = Console.ReadLine();

                        var l = con.Customers.Where(x => x.Name == otvetName).FirstOrDefault();
                        l.License = otvetLicense;
                        con.SaveChanges();
                        con.Database.Migrate();

                        TextColor.Blue("Данные изменены");

                        var g = from c in con.Customers.Where(x => x.License == otvetLicense) select new { c.Name, c.License };
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
           // CRUDLINQ.Start();
        }

        public static void Read()
        {
            string otvet;
            string otvetCity;
            string otvetCustomer;

            TextColor.Green("Посмотреть аренду авто в вашем городе, введите 1 \n посмотреть поезки клиента, введите 2");
            otvet = Console.ReadLine();

            if (otvet == "1")
            {
                using (DatabaseContext con = new DatabaseContext())
                {
                    TextColor.Blue("Услуги аренды есть в следующих городах:");
                    var cities = con.Companies.Select(x => x.City).Distinct().ToList();
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
                            var g = from o in con.Companies
                                    join a in con.Cars on o.ID equals a.CompanyID
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
                    var customers = con.Customers.Select(x => x.Name).Distinct().ToList();
                    foreach (var p in customers)
                    {
                        Console.WriteLine(p);
                    }

                    while (true)
                    {
                        TextColor.Green("Какой клиент интересует?");
                        otvetCustomer = Console.ReadLine();

                        if (customers.Any(x => x == otvetCustomer))
                        {
                            var b = from or in con.CustomersCars
                                    join c in con.Customers on or.CustomerID equals c.ID
                                    join a in con.Cars on or.CarID equals a.ID
                                    join ow in con.Companies on a.CompanyID equals ow.ID
                                    where c.Name == otvetCustomer
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
            //CRUDLINQ.Start();
        }

        public static void Delete()
        {
            string otvetName;
            string otvetLicense;
            string otvetDelete;

            TextColor.Blue("Список клиентов:");

            using (DatabaseContext con = new DatabaseContext())
            {
                var d = (from c in con.Customers orderby c.Name select new { c.Name, c.License }).Distinct();
                var customers = con.Customers.Select(x => x.Name).ToList();
                foreach (var p in d)
                {
                    Console.WriteLine(p.Name + "--" + p.License);
                }

                while (true)
                {
                    TextColor.Green("Введите фамилию клиента");
                    otvetName = Console.ReadLine();

                    if (customers.Any(x => x == otvetName))
                    {
                        while (true)
                        {
                            TextColor.Green("Введите номер водительского удостоверения");
                            otvetLicense = Console.ReadLine();

                            var licenses = con.Customers.Where(x => x.Name == otvetName).Select(x => x.License).ToList();
                       
                            if (licenses.Any(x => x == otvetLicense))
                            {
                                TextColor.Green($"Удалить запись {otvetName} -- {otvetLicense}? (чтобы удалить, введите 'y')");
                                otvetDelete = Console.ReadLine();

                                if (otvetDelete == "y")
                                {
                                    var customerToDelete = con.Customers.Where(x=>x.Name == otvetName && x.License==otvetLicense).FirstOrDefault();
                                    con.Customers.Remove(customerToDelete);
                                    con.SaveChanges();
                                    con.Database.Migrate();

                                    TextColor.Blue("Элемент удалён");
                                    break;
                                }
                                else
                                {
                                    //CRUDLINQ.Start();
                                    break;
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
            //CRUDLINQ.Start();
        }
    }
}