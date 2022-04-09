using System;
using System.Text.Json;

namespace Lanitlesson
{
    internal class Serialization
    {
        public static void Start()
        {
            string otvet;

            string[] arrayCities = new string[] {"Mumansk","Pskov","Vologda","Saint-Petersburg","Arhangel'sk"};
            bool[] arrayBool = new bool[] {true,false};
            string[] arraySex = new string[] {"male","female"};
            Random rnd = new Random();

            TextColor.Green("Чтобы запустить сериализацию, введите 1; \n чтобы выйти в главное меню, нажмите другую клавишу");
            otvet = Console.ReadLine();

            if (otvet == "1")
            {
                //создание массива свойств Parent случайной длины
                int l = rnd.Next(3, 11);
                int xmlcount=0;
                string xmltext;

                Console.WriteLine($"l= {l}");
                Parent[] arrayParents = new Parent[l];

                for (int i = 0; i <= l-1; i++)          //заполнение массива
                {
                    Child child = new Child();
                    child.Sex = arraySex[rnd.Next(2)];
                    child.Age = rnd.Next(19);

                    Parent parent = new Parent(arrayCities[rnd.Next(arrayCities.Length)], rnd.Next(100,20000), arrayBool[rnd.Next(arrayBool.Length)],
                        new DateTime(rnd.Next(1950, 1985), rnd.Next(1,13), rnd.Next(1,29)), child);

                    Console.WriteLine($"{parent.City}--{parent.Income}--{parent.IsFree}--{parent.WasBorn}--{parent.ChildType.Sex}--{parent.ChildType.Age}");
                    
                    arrayParents[i] = parent;
                }
                TextColor.Blue("Массив создан");


                while (true)
                {
                    TextColor.Green("Чтобы запустить сериализацию в *json, введите 1; \n чтобы запустить сериализацию в *xml, нажмите 2");
                    otvet = Console.ReadLine();

                    if (otvet == "1")               //сериализация *json
                    {
                        try
                        {
                            string json = JsonSerializer.Serialize(arrayParents);
                            File.WriteAllText(@"SerialToJSON.json", json);
                            Console.WriteLine(json);

                            TextColor.Blue("сериализация в *json проведена, файл создан");
                        }
                        catch (Exception e)
                        {
                            TextColor.Red("Что-то пошло не так..\n" + e.Message);
                        }

                        TextColor.Green("Чтобы провести сериализацию этого же массива, введите 1; \n чтобы выйти, нажмите любую другую клавишу");
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
                    else if (otvet == "2")          //сериализация *xml
                    {
                        xmlcount = 0;
                        xmltext = "<?xml version=\"1.0\"?>\n<root>\n";

                        for (int j = 0; j <= l - 1; j++)
                        {
                            xmltext += "<item";
                            xmltext += Convert.ToString(xmlcount);
                            xmltext += ">\n<City>";
                            xmltext += arrayParents[j].City;
                            xmltext += "</City>\n<Income>";
                            xmltext += Convert.ToString(arrayParents[j].Income);
                            xmltext += "</Income>\n<IsFree>";
                            xmltext += Convert.ToString(arrayParents[j].IsFree);
                            xmltext += "</IsFree>\n<WasBorn>";
                            xmltext += Convert.ToString(arrayParents[j].WasBorn);
                            xmltext += "</WasBorn>\n<ChildType>\n<Sex>";
                            xmltext += arrayParents[j].ChildType.Sex;
                            xmltext += "</Sex>\n<Age>";
                            xmltext += Convert.ToString(arrayParents[j].ChildType.Age);
                            xmltext += "</Age>\n</ChildType>\n</item";
                            xmltext += Convert.ToString(xmlcount);
                            xmltext += ">\n";
                            xmlcount++;
                        }
                        xmltext += "</root>";

                        try
                        {
                            File.WriteAllText(@"SerialToXML.xml", xmltext);
                            TextColor.Blue("сериализация в *xml проведена, файл создан");
                            Console.WriteLine(xmltext);
                        }
                        catch (Exception e)
                        {
                            TextColor.Red("Что-то пошло не так..\n" + e.Message);
                        }

                        TextColor.Green("Чтобы провести сериализацию этого же массива, введите 1; \n чтобы выйти, нажмите любую другую клавишу");
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
                        TextColor.Red("Такого варианта нет, попробуйте ещё раз");
                        continue;
                    }
                }
            }
            MenuDZ.Call();
        }
    }
}
//string[,] arrayParentsProp= new string[l, 6];
/*arrayParents[i, 0] = parent.City;
arrayParentsProp[i, 1] = Convert.ToString(parent.Income);
arrayParentsProp[i, 2] = Convert.ToString(parent.IsFree);
arrayParentsProp[i, 3] = Convert.ToString(parent.WasBorn);
arrayParentsProp[i, 4] = Convert.ToString(parent.ChildType.Sex);
arrayParentsProp[i, 5] = Convert.ToString(parent.ChildType.Age);*/

//xmltext = "<?xml version=\"1.0\"?><root>";
/*xmltext += "<item";
xmltext += xmlcount;
xmltext += "><City>";
xmltext += arrayParents[j].City;
xmltext += "</City><Income>";
xmltext += Convert.ToString(arrayParents[j].Income);
xmltext += " </Income><IsFree>";
xmltext += Convert.ToString(arrayParents[j].IsFree);
xmltext += "</IsFree><WasBorn>";
xmltext += Convert.ToString(arrayParents[j].WasBorn);
xmltext += "</WasBorn><ChildType><Sex>";
xmltext += arrayParents[j].ChildType.Sex;
xmltext += "</Sex><Age>";
xmltext += Convert.ToString(arrayParents[j].ChildType.Age);
xmltext += "</Age></ChildType></item";
xmltext += xmlcount;
xmltext += ">";*/