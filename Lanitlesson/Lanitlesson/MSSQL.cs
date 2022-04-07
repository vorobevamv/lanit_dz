using System;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Lanitlesson
{
    class MSSQL
    {
        public static List<string> QueryToList(string query, int columnsNumber, List<string> columnNames)
        {

            List<string> MSSQLanswer = new List<string>();


            string connString = "Server=localhost\\sqlexpress01;Database=LibrariesDB;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlQuery = @query;
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))

                {
                    for (int i = 0; i < columnsNumber; i++)
                    {
                        using (SqlDataReader reader = command.ExecuteReader())

                        {

                            while (reader.Read())
                            {
                                //Console.WriteLine($"{reader[columnNames[i]]}");
                                MSSQLanswer.Add(Convert.ToString(reader[columnNames[i]]));
                            }
                        }
                    }
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

            return MSSQLanswer;
        }



        public static void QueryToPrint (string query, int columnsNumber, List<string> columnNames)
        {

            string connString = "Server=localhost\\sqlexpress01;Database=LibrariesDB;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlQuery = @query;
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))

                {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < columnsNumber; i++)
                                { 
                                    Console.Write($"{reader[columnNames[i]]}");
                                    Console.Write("--");
                                }
                                Console.Write("\n");
                            }
                        }
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
        }
    }
}
