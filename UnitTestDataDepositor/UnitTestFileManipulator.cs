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

            bool isOk = fm.SplitFile(filePath, fileName, filePathParts, num);

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

            String filePath = "d:\\test\\datadepositor\\parts";
            String filePathJoin = "d:\\test\\datadepositor\\join\\test.txt";

            bool isOk = fm.JoinFiles(filePath, filePathJoin);
            if (!isOk)
            {
                throw new Exception("JoinFiles_TestMethod()");
            }

        }

    }
}
