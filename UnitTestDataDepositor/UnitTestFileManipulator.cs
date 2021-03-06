﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using DataDepositer;
using System.Runtime.InteropServices;

namespace UnitTestDataDepositor
{
    [TestClass]
    public class UnitTestFileManipulator
    {
        [TestMethod]
        public void SplitFile_TestMethod()
        {
            DataDepositer.Helper h = new DataDepositer.Helper();
            DataDepositer.FileManipulator fm = new DataDepositer.FileManipulator();

            //            String fileName = "test.txt";
            //String fileName = "d:\\test\\datadepositor\\test.txt";
            String filePath = "d:\\test\\datadepositor\\test.txt";
            String filePathParts = "d:\\test\\datadepositor\\parts";
            
            int num = 3;

            bool isOk = fm.SplitFile(filePath, filePathParts, num);

            if (!isOk)
            {
                throw new Exception("SplitFile_TestMethod()");
            }

        }

        [TestMethod]
        public void JoinFiles_TestMethod()
        {
            DataDepositer.Helper h = new DataDepositer.Helper();
            DataDepositer.FileManipulator fm = new DataDepositer.FileManipulator();

//            String filePath = "d:\\test\\datadepositor\\part\\test.txt";
            String filePath = "d:\\test\\datadepositor\\parts";
            String filePathJoin = "d:\\test\\datadepositor\\join\\test.txt";

            bool isOk = fm.JoinFiles(filePath, filePathJoin);
            if (!isOk)
            {
                throw new Exception("JoinFiles_TestMethod()");
            }

        }

        [TestMethod]
        public void AddHeaderToFile_TestMethod()
        {
            DataDepositer.Helper h = new DataDepositer.Helper();
            DataDepositer.FileManipulator fm = new DataDepositer.FileManipulator();

            String filePathFull = "d:\\test\\datadepositor\\join\\test.txt";
            String MD5Origin =  h.GetStringMD5("55555555555555555555555555555555");
            String MD5Chunk =   h.GetStringMD5("66666666666666666666666666666666");


            STORED_FILE_HEADER sfh = h.FillHeader(filePathFull, " Description Описание", MD5Origin, MD5Chunk, 3, 1, 3028, 1010);

            //sfh.cb = ;

            bool isOk = fm.AddHeaderToFile(sfh, filePathFull);
            if (!isOk)
            {
                throw new Exception("AddHeaderToFile_TestMethod()");
            }

        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
        public struct DISPLAY_DEVICE
        {
            public int cb;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string DeviceName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string DeviceInstanceId;
            //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            //public char[] DeviceString;
            public int StateFlags;
            //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            //public char[] DeviceID;
            //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            //public char[] DeviceKey;
        }

        [TestMethod]
        public void RawSerialize_TestMethod()
        {
            DataDepositer.Helper h = new DataDepositer.Helper();
            DataDepositer.FileManipulator fm = new DataDepositer.FileManipulator();

//            String filePathFull = "d:\\test\\datadepositor\\join\\test.txt";
            String filePathFull = "d:\\test\\datadepositor\\testHeader.txt";
            String MD5Origin = h.GetStringMD5("55555555555555555555555555555555");
            String MD5Chunk = h.GetStringMD5("66666666666666666666666666666666");

            DISPLAY_DEVICE dd = new DISPLAY_DEVICE();

            dd.cb = Marshal.SizeOf(dd);

            string str = "Cool Device";
            dd.DeviceInstanceId = str;
            dd.DeviceName = MD5Origin;
            dd.StateFlags = 12345;

            byte[] test = h.RawSerialize(dd);

            File.WriteAllBytes(filePathFull, test);

        }


        [TestMethod]
        public void GetHeader_TestMethod()
        {
            Helper h = new DataDepositer.Helper();
            FileManipulator fm = new DataDepositer.FileManipulator();

            //            String filePathFull = "d:\\test\\datadepositor\\join\\test.txt";
            String filePathFull = "d:\\test\\datadepositor\\testHeader.txt";
            String MD5Origin = h.GetStringMD5("55555555555555555555555555555555");
            String MD5Chunk = h.GetStringMD5("66666666666666666666666666666666");

            STORED_FILE_HEADER sfh = new STORED_FILE_HEADER();

            sfh.cb = (uint)Marshal.SizeOf(sfh); // size of struct
            sfh.ChunkNum = 3;
            sfh.ChunkSize = 0x1234;
            sfh.ChunksQty = 5;
            sfh.Description = @"Проверка описания на русском языке";
            sfh.FileName = Path.GetFileName(filePathFull);
            sfh.MD5Chunk = MD5Chunk;
            sfh.MD5Origin = MD5Origin;
            sfh.OriginSize = 0x5432;

            FileInfo fi = new FileInfo(filePathFull);

            string v = filePathFull + ".hdr";
            //string headerFile =

            File.Delete(v); // delete before copy

            fi.CopyTo(v);

            fm.AddHeaderToFile(sfh, v);

            STORED_FILE_HEADER newSfh = fm.GetHeaderFromFile(v);

            Console.WriteLine("{0}\n {1}\n{2}\n{3}\n{4}\n", newSfh.FileName, newSfh.Description, newSfh.MD5Origin, newSfh.MD5Chunk, newSfh.OriginSize);
        }

    }
}
