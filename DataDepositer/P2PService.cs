// Файл P2PService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace DataDepositer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class P2PService : IP2PService
    {
        private MainForm hostReference;
        private string username;

        public P2PService(object hostReference, string username)
        {
            this.hostReference = (MainForm) hostReference;
            this.username = username;
        }

        public string GetName()
        {
            return username;
        }

        public void SendMessage(string message, string from)
        {
            hostReference.DisplayMessage(message, from);
            // Async Command processing
        }

        public void SendCommand(Command command, string from)
        {
            //hostReference.DisplayMessage(message, from);
            // Async Command processing
            hostReference.ReciveCommand(command, from);
            //Vault.MainQueue.Enqueue(command);
           
            Logger.Log.Info(string.Format("Recieve command {0} from : {1}", command.Message, from));
        }
    }
}