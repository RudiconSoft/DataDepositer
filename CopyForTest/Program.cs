using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //D:\Develop\Projects\DataDepositer\DataDepositer\bin\Debug\ 
            //DataDepositer.exe
            //DataDepositer.pdb
            //NLog.config
            //NLog.dll
            //NLog.xml
            try
            {
                string filename = "List.xml";
                string sourcepath = ConfigurationManager.AppSettings["sourcepath"];
                string destpath = ConfigurationManager.AppSettings["destpath"];
                int count = Convert.ToInt32(ConfigurationManager.AppSettings["count"]);

                XMLHelper h = new XMLHelper();
                List<string> list = new List<string>();

                if (!File.Exists(filename) && args.Length > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(string.Format("Create XML list from args..."));
                    Console.ForegroundColor = ConsoleColor.Black;

                    h.SaveList(filename, new List<string>(args));
                }

                list = h.LoadList<string>(filename);

                foreach (var item in list)
                {
                    FileInfo fi = new FileInfo(Path.Combine(sourcepath, item));

                    if (fi.Exists)
                    {
                        for (int i = 1; i < count + 1; i++)
                        {
                            //File.Delete();
                            Console.Write(string.Format("Copy "));
                            string destname = Path.Combine(destpath, Convert.ToString(i));
                            destname = Path.Combine(destname, item);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(destname);
                            Console.ForegroundColor = ConsoleColor.Black;

                            fi.CopyTo(destname, true);
                        }
                    }
                }

            }
            catch (System.IO.IOException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Black;

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
    }
}

//private void CreateNewStorageList()
//{
//    DirectoryInfo di = new DirectoryInfo(config.StorageFolder);
//    if (di.Exists)
//    {
//        FileManipulator fm = new FileManipulator();
//        foreach (var f in di.GetFiles())
//        {
//            try
//            {
//                // get header from file
//                STORED_FILE_HEADER sfh = fm.GetHeaderFromFile(f.FullName);

//                // fill StorageItem from header
//                string originname = f.Name.Substring(0, f.Name.IndexOf(".part") - 5); // if string not found file name ignored
//                StorageItem si = new StorageItem(sfh.FileName, originname, sfh.Description, sfh.OriginSize, (uint)sfh.ChunksQty, (uint)sfh.ChunkNum, sfh.MD5Chunk, sfh.MD5Origin);

//                // add Storage item into List
//                Vault.StorageList.Add(si);

//            }
//            catch (Exception e)
//            {
//                Logger.Log.Error("Error in StoredList creation process.");
//                Logger.Log.Error(e.Message);
//                //throw;
//            }
//        }

//        // Serialize StorageList
//        XmlSerializer formatter = new XmlSerializer(typeof(List<StorageItem>));
//        using (FileStream fs = new FileStream(config.StorageFolder + "List.xml", FileMode.OpenOrCreate))
//        {
//            formatter.Serialize(fs, Vault.StorageList);
//        }
//    }
//    else
//    {
//        di.Create(); // just create empty StoredFolder 
//    }
//}

