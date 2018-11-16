using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextProcessor
{

    class Program
    {
        static void Main(string[] args)
        {
            var connectStringDB = 
                ConfigurationManager.ConnectionStrings
                ["SimpleTextProcessor.Properties.Settings.simpleDataDBConnectionString"].
                ConnectionString;

            if (args.Length != 0)
            {
                try
                {
                    switch (args[0])
                    {
                        case "create":
                            var createData = new ClassData();
                                createData.InitialData(connectStringDB,
                                    File.ReadAllText(readFileText(new FileInfo(args[1])), Encoding.UTF8));
                            break;

                        case "delete":
                            var deleteData = new ClassData();
                            deleteData.DeleteData(connectStringDB);
                            break;

                        case "update":
                            var updateDate = new ClassData();
                            updateDate.UpdateData(connectStringDB,
                               File.ReadAllText(readFileText(new FileInfo(args[1])), Encoding.UTF8));
                            break;

                        default:
                            Console.WriteLine("Argument unknown. Right arg: create, delete, update");
                            break;
                    }
                }
                catch(FileNotFoundException e)
                {
                    Console.WriteLine("File not found");
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine("argsl[1].Length == 0");
                }
                finally
                {
                    exitProgramm();
                }
            }
            else
            {
                while (true)
                {
                    helloString(">");
                    var autoCompliteData = new ClassData();
                    var autocomplitWord = Console.ReadLine();
                    if (autocomplitWord.Length != 0)
                        autoCompliteData.AutoComplite(connectStringDB, autocomplitWord);

                    else
                        exitProgramm();
                }
            }
                    
        //----------------------------------------------------------------
            Console.ReadKey();
        }

        private static void exitProgramm()
        {
            Console.ReadKey();
            Environment.Exit(0);
        }

        //---------------------------------------------------------------------
        private static void helloString(string hello)
        {
            Console.Write(hello);
        }
        //--------------------------------------------------------------------
        public static string readFileText(FileInfo fileName)
        {
            Console.WriteLine("Directory path: {0}", fileName.Directory);
            Console.WriteLine("file name: {0}", fileName.Name);

            if (!fileName.Exists)
            { 
                throw new FileNotFoundException();
            }        
            else
               return fileName.ToString();

        }
        //-------------------------------------------------------------------
    }
}
