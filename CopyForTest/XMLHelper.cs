using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CopyForTest
{
    [Serializable]
    public class CopyData
    {
        public string SourcePath;
        public string DestPath;
    }

    public class XMLHelper
    {
        public void SaveList<T>(string filename, List<T> list)
        {
            //DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(filename));
            //if (!di.Exists)
            //{
            //    // Create directory if not exist
            //    di.Create();
            //}
            try
            {
                // Serialize StorageList
                XmlSerializer formatter = new XmlSerializer(typeof(List<T>));
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, list);
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        public List<T> LoadList<T>(string filename)
        {
            List<T> list = new List<T>();
            //DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(filename));

            try
            {
                // Deserialize StorageList
                XmlSerializer formatter = new XmlSerializer(typeof(List<T>));
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    list = (List<T>)formatter.Deserialize(fs);
                }
            }
            catch (Exception)
            {

                //throw;
            }

            return list;
        }

    }
}
