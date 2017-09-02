﻿/**
 *  RuDiCon Soft (c) 2017 
 * 
 *  Helper class for using by Data Depositor
 * 
 *  @created 2017-08-28 Artem Nikolaev
 *  @updated 2017-08-28 Artem Nikolaev 
 *                      Added MD5 maipulation helper.
 *  @updated 2017-09-01 Artem Nikolaev
 *                      Replace in STORED_FILE_HEADER char[] to string
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

    //[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
    //public struct STORED_FILE_HEADER // 340 bytes size (660 in Unicode)
    //{
    //    public uint cb;             // Structure size // 4

    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
    //    public char[] FileName;     // Short file name

    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    //    public char[] MD5Origin;    // String MD5 of origin file

    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    //    public char[] MD5Chunk;     // String MD5 of chunk

    //    public uint ChunksQty;      // Chunks qty // 4

    //    public uint ChunkNum;       // Chunks number // 4

    //    public uint OriginSzie;     // origin file size //4

    //    public uint ChunkSize;      // chunk size   //4
    //}

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
    public struct STORED_FILE_HEADER // (660 in Unicode)
    {
        public uint cb;             // Structure size // 4 // indicator for non-initialized struct

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string FileName;     // Short file name

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string MD5Origin;    // String MD5 of origin file

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string MD5Chunk;     // String MD5 of chunk

        public uint ChunksQty;      // Chunks qty // 4

        public uint ChunkNum;       // Chunks number // 4

        public uint OriginSzie;     // origin file size //4

        public uint ChunkSize;      // chunk size   //4
    }


    public class Helper
    {
        // @created 2017-08-28 Artem Nikolaev
        // MD5 manipulation helper.
        public String GetStringMD5(String key)
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

        public object ReadStruct(FileStream fs, Type t)
        {
            byte[] buffer = new byte[Marshal.SizeOf(t)];
            fs.Read(buffer, 0, Marshal.SizeOf(t));
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            Object temp = Marshal.PtrToStructure(handle.AddrOfPinnedObject(), t);
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

        //public byte[] RawSerialize(object anything)
        //{
        //    int rawsize = Marshal.SizeOf(anything);
        //    IntPtr buffer = Marshal.AllocHGlobal(rawsize);
        //    Marshal.StructureToPtr(anything, buffer, false);
        //    byte[] rawdata = new byte[rawsize];
        //    Marshal.Copy(buffer, rawdata, 0, rawsize);
        //    Marshal.FreeHGlobal(buffer);
        //    return rawdata;
        //}


        // fill STORED_FILE_HEADER
        public STORED_FILE_HEADER FillHeader(   
                                                string FileName,     // Short file name
                                                string MD5Origin,    // String MD5 of origin file
                                                string MD5Chunk,     // String MD5 of chunk
                                                uint ChunksQty,      // Chunks qty 
                                                uint ChunkNum,       // Chunks number 
                                                uint OriginSzie,     // origin file size 
                                                uint ChunkSize       // chunk size   
                                            )
        {
            STORED_FILE_HEADER sfh = new STORED_FILE_HEADER();

            sfh.FileName = FileName;
            sfh.MD5Origin = MD5Origin;
            sfh.MD5Chunk = MD5Chunk;
            sfh.ChunksQty = ChunksQty;
            sfh.ChunkNum = ChunkNum;
            sfh.OriginSzie = OriginSzie;
            sfh.ChunkSize = ChunkSize;

            sfh.cb = (uint) System.Runtime.InteropServices.Marshal.SizeOf(sfh); // size of struct

            return sfh;
        }
    }
}
