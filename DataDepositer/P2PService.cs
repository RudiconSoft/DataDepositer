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
            //hostReference.DisplayMessage(message, from);
        }
    }
}