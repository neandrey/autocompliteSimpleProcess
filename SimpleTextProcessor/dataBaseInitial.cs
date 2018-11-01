using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SimpleTextProcessor
{
    internal class dataBaseInitial
    {

        //string connectStringDB = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //using (SqlConnection connection = new SqlConnection(connectStringDB))
        //{
        //    connection.Open();
        //    Console.WriteLine("Подключение открыто");
        //}
        //internal static void dbInitialMethod(string connectStringDB, string key, int value)
        //{
        //    int number;
        //    string sql = string.Format("Insert Into Name (word, wordCount) Values('{0}', '{1}')", key, value);
        //        //using (SqlConnection connection = new SqlConnection(connectStringDB))
        //        //{

        //    SqlCommand command = new SqlCommand(sql, connection);
        //    Console.WriteLine(key);
        //    number = command.ExecuteNonQuery();
        //    Console.WriteLine(number);
        //    //}
        //    //Console.WriteLine("Подключение закрыто...");
        //}
    }
}