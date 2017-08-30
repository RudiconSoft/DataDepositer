using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;


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
            String fileName = "d:\\test\\datadepositor\\test.txt";
            String filePath = "d:\\test\\datadepositor\\test.txt";
            String filePathParts = "d:\\test\\datadepositor\\parts";
            
            int num = 3;

            fm.SplitFile(filePath, fileName, filePathParts, num);

        }

        [TestMethod]
        public void JoinFiles_TestMethod()
        {
            DataDepositer.Helper h = new DataDepositer.Helper();
            DataDepositer.FileManipulator fm = new DataDepositer.FileManipulator();

//            String filePath = "d:\\test\\datadepositor\\part\\test.txt";
            String filePath = "d:\\test\\datadepositor\\part\\";
            String filePathJoin = "d:\\test\\datadepositor\\join";

            fm.JoinFiles(filePath, filePathJoin);

        }

    }
}
