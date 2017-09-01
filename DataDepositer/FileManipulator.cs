/**
 *  RuDiCon Soft (c) 2017
 * 
 *  Class for File operations ( crypt/ decrypt, divide/merge etc.)
 * 
 *  @created 2017-08-30 Artem Nikolaev
 * 
 *  @TODO add check folder exists and create if not exist.
 *  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataDepositer
{
    public class FileManipulator
    {
        // @return file content as byte array 
        public byte[] ReadLocalFile(string sFileName)
        {
            try
            {
                //using (FileStream oFS = new FileStream(sFileName, FileMode.Open, FileAccess.Read))
                //{
                //    using (BinaryReader oBR = new BinaryReader(oFS))
                //    {
                //        return oBR.ReadBytes((int)oFS.Length);
                //    }
                //}
                return File.ReadAllBytes(sFileName);
            }
            catch
            {
                return new byte[] { 0 };
            }
        }


        // @return true if 
        public  bool SaveLocalFile(string sFileName, byte[] buffer)
        {
            try
            {
                //using (FileStream oFS = new FileStream(sFileName, FileMode.Create, FileAccess.Read))
                //{
                //    using (BinaryWriter oBW = new BinaryWriter(oFS))
                //    {
                //        oBW.Write(buffer);
                //        return true;
                //    }
                //}
                File.WriteAllBytes(sFileName, buffer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // @return true if success write all parts
        //
        // @upadetd 2017-08-31  Artem Nikolaev
        //                      Fix partSize calc
        //                      Remove file exist check

        public bool SplitFile(string FileInputPath, string sSourceFileName, string FolderOutputPath, int OutputFiles)
        {
            try
            {
                // Store the file in a byte array
                Byte[] byteSource = System.IO.File.ReadAllBytes(FileInputPath);
                // Get file info
                FileInfo fiSource = new FileInfo(sSourceFileName);
                // Calculate the size of each part
                // int partSize = (int)Math.Ceiling((double)(fiSource.Length / OutputFiles)); // !!!!! ERROR lost last byte possible

                // need increase to 1 for correct 
                int partSize = (int)Math.Ceiling((double)(fiSource.Length / OutputFiles)) + 1; 
                // The offset at which to start reading from the source file
                int fileOffset = 0;

                // Stores the name of each file part
                string currPartPath;
                // The file stream that will hold each file part
                FileStream fsPart;
                // Stores the remaining byte length to write to other files
                int sizeRemaining = (int)fiSource.Length;

                // Create output folder if not exist
                Directory.CreateDirectory(FolderOutputPath);

                // Loop through as many times we need to create the partial files
                for (int i = 0; i < OutputFiles; i++)
                {
                    // Store the path of the new part
                    currPartPath = FolderOutputPath + "\\" + fiSource.Name + "." + String.Format(@"{0:D4}", i) + ".part";
                    // A filestream for the path
                    //if (!File.Exists(currPartPath))
                    {
                        //fsPart = new FileStream(currPartPath, FileMode.CreateNew);
                        fsPart = new FileStream(currPartPath, FileMode.Create);
                        // Calculate the remaining size of the whole file
                        sizeRemaining = (int)fiSource.Length - (i * partSize);
                        // The size of the last part file might differ because a file doesn't always split equally
                        if (sizeRemaining < partSize)
                        {
                            partSize = sizeRemaining;
                        }
                        fsPart.Write(byteSource, fileOffset, partSize);
                        fsPart.Close();
                        fileOffset += partSize;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.ToString());
                return false;
            }
        }


        // @return true if successful join files 
        public bool JoinFiles(string FolderInputPath, string FileOutputPath)
        {
            try
            {
                // Create output folder if not exist
                Directory.CreateDirectory(Path.GetDirectoryName(FileOutputPath));

                DirectoryInfo diSource = new DirectoryInfo(FolderInputPath);
                FileStream fsSource = new FileStream(FileOutputPath, FileMode.Append);

                foreach (FileInfo fiPart in diSource.GetFiles(@"*.part"))
                {
                    Byte[] bytePart = System.IO.File.ReadAllBytes(fiPart.FullName);
                    fsSource.Write(bytePart, 0, bytePart.Length);
                }
                fsSource.Close();

                return true;
            }
            catch (Exception e)
            {
                //Logger.Log.Error(e.ToString());
                return false; // @TODO add exception processing.
            }
        }


        // @return true if success Add header to file
        public bool AddHeaderToFile(STORED_FILE_HEADER header, String sFullPath)
        {
            try
            {
                // create byte arrays with header and file.
                Helper h = new Helper();
                byte[] bs = h.RawSerialize(header);
                byte[] fileBytes = File.ReadAllBytes(sFullPath);

                // rename file (add ".old" extention)
                ReserveFile(sFullPath);
                
                FileStream fsSource = new FileStream(sFullPath, FileMode.Append);
                fsSource.Write(bs, 0, bs.Length);
                fsSource.Write(fileBytes,0, fileBytes.Length);

                fsSource.Close();

                return true;
            }
            catch(Exception e)
            {
                Logger.Log.Error(e.ToString());
                return false;
            }
        }

        // 
        public bool GetHeaderFromFile()
        {
            return false;
        }


        // reserve file fileName by adding ".old" ext
        public void ReserveFile(string fileName)
        {
            string newName = fileName + ".old";
            File.Move(fileName, newName);
        }
    }
}
