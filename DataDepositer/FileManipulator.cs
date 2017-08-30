/**
 *  RuDiCon Soft (c) 2017
 * 
 *  Class for File operations ( crypt/ decrypt, divide/merge etc.)
 * 
 *  @created 2017-08-30 Artem Nikolaev
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

        public void SplitFile(string FileInputPath, string FolderOutputPath, int OutputFiles)
        {
            // Store the file in a byte array
            Byte[] byteSource = System.IO.File.ReadAllBytes(FileInputPath);
            // Get file info
            FileInfo fiSource = new FileInfo(txtSourceFile.Text);
            // Calculate the size of each part
            int partSize = (int)Math.Ceiling((double)(fiSource.Length / OutputFiles));
            // The offset at which to start reading from the source file
            int fileOffset = 0;

            // Stores the name of each file part
            string currPartPath;
            // The file stream that will hold each file part
            FileStream fsPart;
            // Stores the remaining byte length to write to other files
            int sizeRemaining = (int)fiSource.Length;

            // Loop through as many times we need to create the partial files
            for (int i = 0; i < OutputFiles; i++)
            {
                // Store the path of the new part
                currPartPath = FolderOutputPath + "\\" + fiSource.Name + "." + String.Format(@"{0:D4}", i) + ".part";
                // A filestream for the path
                if (!File.Exists(currPartPath))
                {
                    fsPart = new FileStream(currPartPath, FileMode.CreateNew);
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
        }

        private void JoinFiles(string FolderInputPath, string FileOutputPath)
        {
            DirectoryInfo diSource = new DirectoryInfo(FolderInputPath);
            FileStream fsSource = new FileStream(FileOutputPath, FileMode.Append);

            foreach (FileInfo fiPart in diSource.GetFiles(@"*.part"))
            {
                Byte[] bytePart = System.IO.File.ReadAllBytes(fiPart.FullName);
                fsSource.Write(bytePart, 0, bytePart.Length);
            }
            fsSource.Close();
        }


    }
}
