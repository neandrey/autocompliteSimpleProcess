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
            
            dataSetSimpleText ds = new dataSetSimpleText();
            dataSetSimpleText.NameDataTable tblName = ds.Name;

            dataSetSimpleTextTableAdapters.NameTableAdapter daName;

            daName = new dataSetSimpleTextTableAdapters.NameTableAdapter();
            Console.WriteLine(daName.ClearBeforeFill);

            var dataCount = daName.ScalarQuery();
            if (dataCount != 0)
            {
                dbDeleteMethod(connectStringDB);
            }

            // Console.WriteLine(daName.Fill(tblName));
            Console.WriteLine("Load data...");
            foreach (var e in frequency)
            {
                daName.Insert(e.Key, e.Value);
            }
            Console.WriteLine("End Load data...");
        }

        private static void DisplayRow(DataRow row)
        {
            DataTable tbl = row.Table;
            foreach (DataColumn col in tbl.Columns)
                Console.WriteLine("\t" + col.ColumnName + ": " + row[col]); 
        }

        //-------------------------------------------------------------------------------
        internal static void dbUpdateMethod(string connectStringDB, Dictionary<string, int> frequency)
        {
            dataSetSimpleText ds = new dataSetSimpleText();
            dataSetSimpleText.NameDataTable tblName = ds.Name;

            dataSetSimpleTextTableAdapters.NameTableAdapter daName;

            daName = new dataSetSimpleTextTableAdapters.NameTableAdapter();
            Console.WriteLine(daName.ClearBeforeFill);

            foreach (var e in frequency)
            {
                tblName.AddNameRow(e.Key, e.Value);
            }

            Console.WriteLine("Update data ...");
            daName.Update(tblName);
            Console.WriteLine("End Update data ");
           
        }

        //-------------------------------------------------------------------------------
        internal static void dbAutoComplSearch(string connectStringDB, string autocomplitWord)
        {
            var findWorldDict = new Dictionary<string, int>();
            var keyForRemove = new List<string>();
            dataSetSimpleText ds = new dataSetSimpleText();
            dataSetSimpleText.NameDataTable tblName = ds.Name;

            dataSetSimpleTextTableAdapters.NameTableAdapter daName;

            daName = new dataSetSimpleTextTableAdapters.NameTableAdapter();

            Console.WriteLine(daName.ClearBeforeFill);
            tblName.Clear();
            daName.Fill(tblName);


            foreach (dataSetSimpleText.NameRow rowName in tblName)
            {
                if (findWorldDict.ContainsKey(rowName.word) || !rowName.word.StartsWith(autocomplitWord))
                    continue;
                findWorldDict.Add(rowName.word, rowName.wordCount);
            }

            findWorldDict = findWorldDict.
                OrderByDescending(pair => pair.Value).
                ToDictionary(pair => pair.Key, pair => pair.Value);

            // Место для сортировки по ключу при равных значениях Value.

            printDisplayFiveValue(findWorldDict, 5);

        }

        
        //-------------------------------------------------------------------------------
        internal static void dbDeleteMethod(string connectStringDB)
        {
            string sqlExpression = "truncate table Name";
            using (SqlConnection connection = new SqlConnection(connectStringDB))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Удалено объектов: {0}", number);
            }
        }

        //-------------------------------------------------------------------------------
        internal static void dbSelectMethod(string connectStringDB)
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

        //-------------------------------------------------------------------------------
        private static void printDisplayFiveValue(Dictionary<string, int> findWorldDict, int iteral)
        {
            foreach (var searchFiveWords in findWorldDict)
            {
                if (iteral == 0)
                    break;
                Console.WriteLine("{0} \t {1}", searchFiveWords.Key, searchFiveWords.Value);
                iteral--;
            }

        }

    }
}