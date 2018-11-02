using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SimpleTextProcessor
{
    internal class dataBaseInitial
    {

      
        internal static void dbInitialMethod(string connectStringDB, Dictionary<string, int> frequency)
        {
            string sql = string.Format("INSERT Into Name (word, wordCount) VALUES (@word, @wordCount)");
            using (SqlConnection connection = new SqlConnection(connectStringDB))
            {
                
                connection.Open();
                Console.WriteLine("Подключение открыто");
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("@word", SqlDbType.NVarChar);
                command.Parameters.Add("@wordCount", SqlDbType.Int);
                foreach(KeyValuePair<string, int> key in frequency.AsEnumerable())
                {
                    command.Parameters["@word"].Value = key.ToString();
                    command.Parameters["@wordCount"].Value = key.Value;
                    command.ExecuteNonQuery();
                }
                
            }
             Console.WriteLine("Подключение закрыто...");
        }

        internal static void dbSelectMethod(string connectStringDB, Dictionary<string, int> frequency)
        {
            string sqlExpression = "SELECT * FROM NAME";
            using (SqlConnection connection = new SqlConnection(connectStringDB))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
            }
        }




        //private static DataTable ConvertToDataTable(Dictionary<string, int> frequency)
        //{
        //    var dt = new DataTable();
        //    dt.Columns.Add("word", typeof(string));
        //    dt.Columns.Add("wordCount", typeof(Int32));
        //    foreach (var pair in frequency)
        //    {
        //        var row = dt.NewRow();
        //        row["word"] = pair.Key;
        //        row["wordCount"] = pair.Value;
        //        dt.Rows.Add(row);
        //    }
        //    return dt;
        //}
    }
}