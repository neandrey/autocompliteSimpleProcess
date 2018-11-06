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
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            if (args.Length != 0)
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
            else
            {
                helloString(">");
                var classData = new ClassData();
                var autocomplitWord = Console.ReadLine();
                classData.AutoComplite(connectStringDB, autocomplitWord);
            }
            //----------------------------------------------------------------
            Console.ReadKey();
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
                Console.WriteLine("File not found");
                throw new FileNotFoundException();
            }        
            else
               return fileName.ToString();

        }
        //-------------------------------------------------------------------
    }
}
