using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataDepositer;

namespace UnitTestDataDepositor
{
    /// <summary>
    /// Сводное описание для UnitTestHelper
    /// </summary>
    [TestClass]
    public class UnitTestHelper
    {
        public UnitTestHelper()
        {
            //
            // TODO: добавьте здесь логику конструктора
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetCurrentAppDataFolder_TestMethod()
        {
            Helper h = new Helper();
            string strAppDataFolder = h.GetCurrentAppDataFolder();

            if (strAppDataFolder.Length == 0)
            {
                throw new Exception();
            }
        }

        [TestMethod]
        public void INIFileClass_TestMethod()
        {
            IniFile ini = new IniFile("testconfig.ini");
            Config conf = new Config();
            // Create sections
            conf.ToINI(ini);

            // Read sections
            conf.FromINI(ini);

            // change/ add sections

            conf.DDNSAddress = "soft.rudicon.ddns.net";
            conf.DDNSUserName = "soft.rudicon";
            conf.DDNSPassword = "soft.ddnspass";

            IniFile ini1 = new IniFile("testconfig_changed.ini");
            conf.ToINI(ini1);

        }
    }
}
