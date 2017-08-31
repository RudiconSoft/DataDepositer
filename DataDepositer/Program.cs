using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace DataDepositer
{
   
    static class Program
    {
        //public static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [MTAThread]
        static void Main()
        {

            Logger.Log.Info(DateTime.Now.ToString() + "  Start DataDepositor.");

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
            }
        }
    }
}
