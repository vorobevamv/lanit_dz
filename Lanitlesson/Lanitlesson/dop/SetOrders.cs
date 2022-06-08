using System;

namespace Lanitlesson
{
    internal class SetOrders
    {
        /*using (DatabaseContext con = new DatabaseContext())
        {
        
        con.Database.EnsureCreated();
        con.Database.Migrate();

         DbCustomers customer = new DbCustomers();
                customer.ID = Guid.NewGuid();
                customer.Name = "Ivanov";
                customer.License = "78 11 111111";
                con.Customers.Add(customer);

                DbCompanies company = new DbCompanies();
                company.ID = Guid.NewGuid();
                company.Name = "NothStar";
                company.City = "Murmansk";
                con.Companies.Add(company);






        DbOwners owner1 = new DbOwners();
        owner1.ID = Guid.NewGuid();
        owner1.Name = "NothStar";
        owner1.City = "Murmansk";

        DbOwners owner2 = new DbOwners();
        owner2.ID = Guid.NewGuid();
        owner2.Name = "WestStar";
        owner2.City = "Kaliningrad";

        DbOwners owner3 = new DbOwners();
        owner3.ID = Guid.NewGuid();
        owner3.Name = "EastStar";
        owner3.City = "Vladivostok";

        DbOwners owner4 = new DbOwners();
        owner4.ID = Guid.NewGuid();
        owner4.Name = "SouthStar";
        owner4.City = "Krasnodar";

        con.Owners.Add(owner1);
        con.Owners.Add(owner2);
        con.Owners.Add(owner3);
        con.Owners.Add(owner4);
        var d = con.Owners.ToList();
        foreach (var d2 in d)
        { 
        Console.WriteLine(d2.ID+"--"+ d2.Name + "--" + d2.City);
        }

        DbClients client1 = new DbClients();
                client1.ID = Guid.NewGuid();
                client1.Name = "Ivanov";
                client1.License = "78 11 111111";

                DbClients client2= new DbClients();
                client2.ID = Guid.NewGuid();
                client2.Name = "Petrov";
                client2.License = "78 11 222222";

                DbClients client3 = new DbClients();
                client3.ID = Guid.NewGuid();
                client3.Name = "Sidorov";
                client3.License = "78 11 333333";

                DbClients client4 = new DbClients();
                client4.ID = Guid.NewGuid();
                client4.Name = "Popov";
                client4.License = "78 11 444444";

                DbClients client5 = new DbClients();
                client5.ID = Guid.NewGuid();
                client5.Name = "Smirnov";
                client5.License = "78 11 555555";

                con.Clients.Add(client1);
                con.Clients.Add(client2);
                con.Clients.Add(client3);
                con.Clients.Add(client4);
                con.Clients.Add(client5);

                var d = con.Clients.ToList();
                foreach (var p in d)
                { 
                Console.WriteLine(p.ID+"--"+ p.Name + "--" + p.License);
                }

         DbAutos auto1 = new DbAutos();
                auto1.ID = Guid.NewGuid();
                auto1.Model = "Ford";
                auto1.Number = "М111ММ";
                auto1.Year = 2007;
                auto1.ownerID = new Guid("9dd12d86-1b23-4681-aacd-24264fb7995c");

                DbAutos auto2 = new DbAutos();
                auto2.ID = Guid.NewGuid();
                auto2.Model = "Mazda";
                auto2.Number = "М222ММ";
                auto2.Year = 2008;
                auto2.ownerID = new Guid("9dd12d86-1b23-4681-aacd-24264fb7995c");

                DbAutos auto3 = new DbAutos();
                auto3.ID = Guid.NewGuid();
                auto3.Model = "Lada";
                auto3.Number = "М333ММ";
                auto3.Year = 2009;
                auto3.ownerID = new Guid("708a777a-f8fc-40c6-97d0-b3307a001fd7");

                DbAutos auto4 = new DbAutos();
                auto4.ID = Guid.NewGuid();
                auto4.Model = "Skoda";
                auto4.Number = "М444ММ";
                auto4.Year = 2010;
                auto4.ownerID = new Guid("708a777a-f8fc-40c6-97d0-b3307a001fd7");

                DbAutos auto5 = new DbAutos();
                auto5.ID = Guid.NewGuid();
                auto5.Model = "Subaru";
                auto5.Number = "М555ММ";
                auto5.Year = 2011;
                auto5.ownerID = new Guid("dd0a3eba-2fe7-4108-9978-d152e8eafe83");

                DbAutos auto6 = new DbAutos();
                auto6.ID = Guid.NewGuid();
                auto6.Model = "Renault";
                auto6.Number = "М666ММ";
                auto6.Year = 2012;
                auto6.ownerID = new Guid("dd0a3eba-2fe7-4108-9978-d152e8eafe83");

                DbAutos auto7 = new DbAutos();
                auto7.ID = Guid.NewGuid();
                auto7.Model = "Audi";
                auto7.Number = "М777ММ";
                auto7.Year = 2001;
                auto7.ownerID = new Guid("e832a6ca-afc5-462a-b9b5-e41bbecfe5f4");

                DbAutos auto8 = new DbAutos();
                auto8.ID = Guid.NewGuid();
                auto8.Model = "Toyota";
                auto8.Number = "М888ММ";
                auto8.Year = 2018;
                auto8.ownerID = new Guid("e832a6ca-afc5-462a-b9b5-e41bbecfe5f4");


                con.Autos.Add(auto1);
                con.Autos.Add(auto2);
                con.Autos.Add(auto3);
                con.Autos.Add(auto4);
                con.Autos.Add(auto5);
                con.Autos.Add(auto6);
                con.Autos.Add(auto7);
                con.Autos.Add(auto8);

                var d = con.Autos.ToList();
                foreach (var p in d)
                { 
                Console.WriteLine(p.ID+"--"+ p.Model + "--" + p.Number + "--" + p.Year + "--" + p.ownerID);
                }

                
        var d = con.Orders.ToList();
                foreach (var p in d)
                {
                    Console.WriteLine(p.clientID + "--" + p.autoID);
                }


    con.SaveChanges();
        }*/


    }

}
