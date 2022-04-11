using System;
using System.Data.SqlClient;
using System.Data.Sql;


namespace Lanitlesson
{
    class CRUDSQL:Homework

    {
        public CRUDSQL(Mediator mediator) : base(mediator)
        {
        }

        public static void Start() //Menu
        {
            string otvetSQL;

            TextColor.Green("МЕНЮ SQL\n " +
                "добавить данные о книге или читателе - введите 1\n " +
                "посмотреть данные о читателях или книгах  - введите 2\n " +
                "уточнить возраст читателя - введите 3\n " +
                "удалить книгу из базы - введите 4\n ");
                //+"ВЫХОД - введите 0");

            otvetSQL = Console.ReadLine();

            switch (otvetSQL)
            {
                case "1":
                    CRUDSQL.CreateSQL();
                    break;
                case "2":
                    CRUDSQL.ReadSQL();
                    break;
                case "3":
                    CRUDSQL.UpdateSQL();
                    break;
                case "4":
                    CRUDSQL.DeleteSQL(); ;
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
        public static void ReadSQL()
        {
            string otvet;
            List<string> columnNames = new List<string>();
            string query;
            int columnsNumber;

            TextColor.Green("Если хотите найти книгу, введите 1 \n если хотите получить данные о читателе, нажмите 2");
            otvet = Console.ReadLine();

            if (otvet == "1")
            {
                TextColor.Blue("Вот авторы, книги которых есть в библиотеках:");

                columnNames.Add("book_author");
                MSSQL.QueryToPrint("SELECT DISTINCT book_author FROM Books ORDER BY book_author", 1, columnNames);
                List<string> authors = MSSQL.QueryToList("SELECT DISTINCT book_author FROM Books ORDER BY book_author", 1, columnNames);
                columnNames.Clear();

                TextColor.Green("Введите фамилию автора, книгу которого хотите найти");
                otvet = Console.ReadLine();

                if (authors.Any(x => x == otvet))
                {
                    columnNames.Add("book_author");
                    columnNames.Add("book_title");
                    columnNames.Add("lib_name");
                    columnNames.Add("lib_adress");
                    TextColor.Blue("book_author -- book_title -- lib_name -- lib_adress");
                    query = "SELECT B.book_author, B.book_title, L.lib_name, L.lib_adress FROM Books AS B JOIN Libraries AS L " +
                        "ON L.lib_id = B.lib_id WHERE B.book_author = '" + otvet + "'";
                    columnsNumber = 4;
                    MSSQL.QueryToPrint(query, columnsNumber, columnNames);
                    columnNames.Clear();
                }
                else
                {
                    TextColor.Red("Такого автора нет!");
                    CRUDSQL.Start();
                }
            }
            else if (otvet == "2")
            {
                TextColor.Blue("Вот фамилии читателей:");

                columnNames.Add("reader_surname");
                MSSQL.QueryToPrint("SELECT DISTINCT reader_surname FROM Readers ORDER BY reader_surname", 1, columnNames);
                List<string> readers = MSSQL.QueryToList("SELECT DISTINCT reader_surname FROM Readers ORDER BY reader_surname", 1, columnNames);
                columnNames.Clear();

                TextColor.Green("Введите фамилию читателя, информацию о котором хотите найти");
                otvet = Console.ReadLine();

                if (readers.Any(x => x == otvet))
                {
                    columnNames.Add("reader_surname");
                    columnNames.Add("reader_name");
                    columnNames.Add("reader_age");
                    columnNames.Add("lib_name");
                    columnNames.Add("lib_adress");
                    columnNames.Add("book_author");
                    columnNames.Add("book_title");
                    query = "SELECT R.reader_surname, R.reader_name,R.reader_age, L.lib_name, L.lib_adress, B.book_author, B.book_title " +
                        "FROM Readers AS R JOIN BooksReaders AS BR ON R.reader_id = BR.reader_id JOIN Books AS B " +
                        "ON B.book_id = BR.book_id JOIN Libraries AS L ON L.lib_id = B.lib_id WHERE R.reader_surname = '" + otvet + "'";
                    columnsNumber = 7;
                    TextColor.Blue("reader_surname -- reader_name -- reader_age -- lib_name -- lib_adress -- book_author -- book_title");
                    MSSQL.QueryToPrint(query, columnsNumber, columnNames);
                    columnNames.Clear();
                }
                else
                {
                    TextColor.Red("Такого читателя нет!");
                    CRUDSQL.Start();
                }
            }
            else
            {
                TextColor.Red("Такого варианта нет!");
                CRUDSQL.Start();
            }
            CRUDSQL.Start();
        }
        public static void CreateSQL()
        {
            string otvet;
            string otvetSurname;
            string otvetName;
            int otvetAge;
            string otvetLibrary;
            string otvetAuthor;
            string otvetTitle;
            List<string> columnNames = new List<string>();
            string query;
            int columnsNumber;

            TextColor.Green("Если хотите добавить новую книгу, введите 1 \n если хотите добавить нового читателя, введите 2");
            otvet = Console.ReadLine();

            if (otvet == "1")
            {
                TextColor.Green("Введите фамилию автора");
                otvetAuthor = Console.ReadLine();
                TextColor.Green("Введите название книги");
                otvetTitle = Console.ReadLine();

              
                TextColor.Blue("Сейчас доступны следующие библиотеки:");

                columnNames.Add("lib_name");
                query = "SELECT lib_name FROM Libraries ORDER BY lib_name";
                columnsNumber = 1;
                MSSQL.QueryToPrint(query, columnsNumber, columnNames);
                List<string> libraries = MSSQL.QueryToList("SELECT DISTINCT lib_name FROM Libraries", 1, columnNames);
                columnNames.Clear();

                while (true)
                {
                    TextColor.Green("В какой библиотеке будет храниться эта книга?");
                    otvetLibrary = Console.ReadLine();

                    if (libraries.Any(x => x == otvetLibrary))
                    {
                        break;
                    }
                    else
                    {
                        TextColor.Red("Такой библиотеки в списке доступных нет!");
                        continue;
                    }
                }
                query = "INSERT INTO Books VALUES (NEWID(),'" + otvetAuthor + "','" + otvetTitle + "',(SELECT lib_id FROM Libraries WHERE lib_name = '" + otvetLibrary + "'))";
                MSSQL.QueryToDo(query);
                columnNames.Clear();

                columnNames.Add("book_author");
                columnNames.Add("book_title");
                columnNames.Add("lib_name");
                query = "SELECT B.book_author, B.book_title, L.lib_name  FROM Books AS B " +
                    "JOIN Libraries AS L ON B.lib_id = L.lib_id " +
                    "WHERE B.book_author = '"+ otvetAuthor + "' AND B.book_title = '"+ otvetTitle + "'";
                columnsNumber = 3;
                TextColor.Blue("книга добавлена: \n book_author -- book_title -- lib_name");
                MSSQL.QueryToPrint(query, columnsNumber, columnNames);
                columnNames.Clear();
            }
            else if (otvet == "2")
            {
                TextColor.Green("Введите фамилию читателя");
                otvetSurname = Console.ReadLine();
                TextColor.Green("Введите имя читателя");
                otvetName = Console.ReadLine();

                while (true)
                {
                    TextColor.Green("Введите возраст читателя");
                    try
                    {
                        otvetAge = Int32.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        TextColor.Red("Пожалуйста, введите число \n"+e.Message);
                        continue;
                    }
                    if (otvetAge < 10)
                    {
                        TextColor.Red("Этот читатель слишком юн; уточните, пожалуйста, возраст");
                        continue;
                    }
                    else if (otvetAge > 110)
                    {
                        TextColor.Red("Этот читатель слишком стар; уточните, пожалуйста, возраст");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
               
                TextColor.Green("Какую книгу новый читатель хочет взять?");
                TextColor.Blue("Вот варианты: ");

                columnNames.Add("book_author");
                columnNames.Add("book_title");
                query = "SELECT DISTINCT book_author, book_title FROM Books ORDER BY book_author";
                columnsNumber = 2;
                TextColor.Blue("book_author -- book_title");
                MSSQL.QueryToPrint(query, columnsNumber, columnNames);
                columnNames.Clear();

                while (true)
                {
                    TextColor.Green("Введите фамилию автора книги");
                    otvetAuthor = Console.ReadLine();

                    columnNames.Add("book_author");
                    List<string> authors = MSSQL.QueryToList("SELECT DISTINCT book_author FROM Books", 1, columnNames);
                    columnNames.Clear();

                    if (authors.Any(x => x == otvetAuthor))
                    {
                        while (true)
                        {
                            TextColor.Green("Введите название книги");
                            otvetTitle = Console.ReadLine();

                            columnNames.Add("book_title");
                            query = "SELECT DISTINCT book_title FROM Books WHERE book_author = '" + otvetAuthor + "'";
                            List<string> titles = MSSQL.QueryToList(query, 1, columnNames);
                            columnNames.Clear();

                            if (titles.Any(x => x == otvetTitle))
                            {
                                break;
                            }
                            else
                            {
                                TextColor.Red("Такой книги этого автора в библиотеках нет, введите другое название");
                                continue;
                            }
                        }
                        break;
                    }
                    else
                    {
                        TextColor.Red("Книг такого автора в библиотеках нет, введите другого автора");
                        continue;
                    }
                }

                query = "INSERT INTO Readers VALUES (NEWID(),'" + otvetSurname + "','" + otvetName + "'," + otvetAge + ") ";
                MSSQL.QueryToDo(query);

                columnNames.Add("book_id");
                query = "SELECT book_id FROM Books WHERE book_author = '" + otvetAuthor + "' AND book_title = '" + otvetTitle + "'";
                string otvetBookID =MSSQL.QueryToList(query, 1, columnNames)[0];
                columnNames.Clear();

                columnNames.Add("reader_id");
                query = "SELECT reader_id FROM Readers WHERE reader_surname = '" + otvetSurname + "' AND reader_name = '" + otvetName + "' AND reader_age = " + otvetAge;
                string otvetReaderID = MSSQL.QueryToList(query, 1, columnNames)[0];
                columnNames.Clear();

                query = "INSERT INTO BooksReaders VALUES('" + otvetBookID + "','" + otvetReaderID + "')";
                MSSQL.QueryToDo(query);

                columnNames.Add("reader_surname");
                columnNames.Add("reader_name");
                columnNames.Add("reader_age");
                columnNames.Add("lib_name");
                columnNames.Add("lib_adress");
                columnNames.Add("book_author");
                columnNames.Add("book_title");
                query = "SELECT R.reader_surname, R.reader_name, R.reader_age, L.lib_name, L.lib_adress, B.book_author, B.book_title " +
                    "FROM Readers AS R " +
                    "JOIN BooksReaders AS BR ON R.reader_id = BR.reader_id " +
                    "JOIN Books AS B ON B.book_id = BR.book_id " +
                    "JOIN Libraries AS L ON L.lib_id = B.lib_id " +
                    "WHERE R.reader_surname = '" + otvetSurname + "'AND R.reader_name = '"+ otvetName + "' AND R.reader_age = "+ otvetAge;
                columnsNumber = 7;
                TextColor.Blue("читатель добавлен: \n reader_surname -- reader_name -- reader_age -- lib_name -- lib_adress -- book_author -- book_title");
                MSSQL.QueryToPrint(query, columnsNumber, columnNames);
                columnNames.Clear();
            }
            else
            {
                TextColor.Red("Такого варианта нет!");
                CRUDSQL.Start();
            }
            CRUDSQL.Start();
        }
        public static void UpdateSQL()
        {
            string otvetSurname;
            string otvetName;
            int otvetAge;
            List<string> columnNames = new List<string>();
            string query;
            int columnsNumber;

            TextColor.Blue("Список читателей:");

            columnNames.Add("reader_surname");
            columnNames.Add("reader_name");
            columnNames.Add("reader_age");
            query = "SELECT reader_surname, reader_name, reader_age FROM Readers ORDER BY reader_surname";
            columnsNumber = 3;
            MSSQL.QueryToPrint(query, columnsNumber, columnNames);
            columnNames.Clear();

            columnNames.Add("reader_surname");
            List<string> readerSurnames = MSSQL.QueryToList("SELECT DISTINCT reader_surname FROM Readers", 1, columnNames);
            columnNames.Clear();

            while (true)
            {
                TextColor.Green("Введите фамилию читателя, возраст которого хотите изменить");
                otvetSurname = Console.ReadLine();

                if (readerSurnames.Any(x => x == otvetSurname))
                {
                    columnNames.Add("reader_name");
                    query = "SELECT DISTINCT reader_name FROM Readers " +
                        "WHERE reader_surname = '" +otvetSurname +"'";
                    List<string> readerNames = MSSQL.QueryToList(query, 1, columnNames);
                    columnNames.Clear();

                    while (true)
                    {
                        TextColor.Green("Введите имя читателя, возраст которого хотите изменить");
                        otvetName = Console.ReadLine();

                        if (readerNames.Any(x => x == otvetName))
                        {
                            while (true)
                            {
                                TextColor.Green("Введите новый возраст");
                                try
                                {
                                    otvetAge = Int32.Parse(Console.ReadLine());
                                }
                                catch (Exception e)
                                {
                                    TextColor.Red("Пожалуйста, введите число \n" + e.Message);
                                    continue;
                                }
                                if (otvetAge < 10)
                                {
                                    TextColor.Red("Этот читатель слишком юн; уточните, пожалуйста, возраст");
                                    continue;
                                }
                                else if (otvetAge > 110)
                                {
                                    TextColor.Red("Этот читатель слишком стар; уточните, пожалуйста, возраст");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            TextColor.Blue("Информация обновлена: ");
                            columnNames.Add("reader_surname");
                            columnNames.Add("reader_name");
                            columnNames.Add("reader_age");
                            query = " UPDATE Readers SET reader_age = " + otvetAge + "" +
                                "WHERE reader_surname = '" + otvetSurname + "' AND reader_name = '" + otvetName + "' " +
                                "SELECT reader_surname,reader_name, reader_age FROM Readers " +
                                "WHERE reader_surname = '" + otvetSurname + "' AND reader_name = '" + otvetName + "'";
                            columnsNumber = 3;
                            MSSQL.QueryToPrint(query, columnsNumber, columnNames);
                            columnNames.Clear();
                            break;
                        }
                        else
                        {
                            TextColor.Red("Такого читателя нет!");
                            continue;
                        }
                    }
                    break;
                }
                else
                {
                    TextColor.Red("Такого читателя нет!");
                    continue;
                }
            }
            CRUDSQL.Start();
        }
        public static void DeleteSQL()
        {
            string otvetAuthor;
            string otvetTitle;
            List<string> columnNames = new List<string>();
            string query;
            int columnsNumber;

            TextColor.Blue("Список книг в библиотеках:");

            columnNames.Add("book_author");
            columnNames.Add("book_title");
            query = "SELECT book_author, book_title FROM Books ORDER BY book_author";
            columnsNumber = 2;
            MSSQL.QueryToPrint(query, columnsNumber, columnNames);
            columnNames.Clear();

            columnNames.Add("book_author");
            List<string> authors = MSSQL.QueryToList("SELECT DISTINCT book_author FROM Books", 1, columnNames);
            columnNames.Clear();

            while (true)
            {
                TextColor.Green("Введите фамилию автора");
                otvetAuthor = Console.ReadLine();

                if (authors.Any(x => x == otvetAuthor))
                {
                    while (true)
                    {
                        columnNames.Add("book_title");
                        query = "SELECT book_title FROM Books WHERE book_author = '"+otvetAuthor+"'";
                        List<string> titles = MSSQL.QueryToList(query, 1, columnNames);
                        columnNames.Clear();

                        TextColor.Green("Введите название книги");
                        otvetTitle = Console.ReadLine();

                        if (titles.Any(x => x == otvetTitle))
                        {
                            query = "DELETE FROM Books " +
                                "WHERE book_author = '"+otvetAuthor+"' AND book_title = '"+otvetTitle+"'";
                            MSSQL.QueryToDo(query);
                            columnNames.Clear();

                            TextColor.Blue($"Информация о книге ({otvetAuthor} '{otvetTitle}') удалена");
                            break;
                        }
                        else
                        {
                            TextColor.Red("Такой книги нет!");
                            continue;
                        }
                    }
                    break;
                }
                else
                {
                    TextColor.Red("Такого автора нет!");
                    continue;
                }
            }
            CRUDSQL.Start();
        }
    }
}
