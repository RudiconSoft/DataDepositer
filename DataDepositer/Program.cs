/**
 *  RuDiCon Soft (c) 2017
 * 
 *  Program Entry point.
 *  
 *  @created 2017-09-19 Artem Nikolaev
 *  
 */
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
        [STAThread]
        static void Main()
        {

            Logger.Log.Info(DateTime.Now.ToString() + "  Start DataDepositor.");
            bool IsExit = false;
            uint ErrorCounter = 0; // 20 for prevent undefined loop

            while (!IsExit && ErrorCounter < 20)
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                    IsExit = true;
                }
                catch (Exception e)
                {
                    Logger.Log.Error(e.Message);
                    ErrorCounter++;
                }
            }
        }
    }
}
