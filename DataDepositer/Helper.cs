/**
 *  RuDiCon Soft (c) 2017 
 * 
 *  Helper class for using by Data Depositor
 * 
 *  @created 2017-08-28 Artem Nikolaev
 *  @updated 2017-08-28 Artem Nikolaev 
 *                      Added MD5 maipulation helper.
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.IO;


namespace DataDepositer
{

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
    public struct STORED_FILE_HEADER
    {
        public uint cb;             // Structure size

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] FileName;     // Short file name

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] MD5Origin;    // String MD5 of origin file

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] MD5Chunk;     // String MD5 of chunk

        public uint ChunksQty;      // Chunks qty

        public uint ChunkNum;       // Chunks number

        public uint OriginSzie;     // origin file size 

        public uint ChunkSize;      // chunk size
    }

    public class Helper
    {
        // @created 2017-08-28 Artem Nikolaev
        // MD5 manipulation helper.
        public String getMD5(String key)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                        
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(key);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        //
        // Read struct bytes from filesteram and return struct
        // 
        // @use SOMESTRUCTURE stExmpl = ReadStruct<SOMESTRUCTURE>(filesteram);
        //
        //
        public T ReadStruct<T>(FileStream fs)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];
            fs.Read(buffer, 0, Marshal.SizeOf(typeof(T)));
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            T temp = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return temp;
        }

        //
        // @return raw data of given object
        //
        public byte[] RawSerialize(object anything)
        {
            int rawsize = Marshal.SizeOf(anything);
            byte[] rawdata = new byte[rawsize];
            GCHandle handle = GCHandle.Alloc(rawdata, GCHandleType.Pinned);
            Marshal.StructureToPtr(anything, handle.AddrOfPinnedObject(), false);
            handle.Free();
            return rawdata;
        }

    }
}
