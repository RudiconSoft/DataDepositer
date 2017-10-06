// Файл IP2PService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace DataDepositer
{
    [ServiceContract]
    public interface IP2PService
    {
        [OperationContract]
        string GetName();

        [OperationContract(IsOneWay = true)]
        void SendMessage(string message, string from);

        [OperationContract(IsOneWay = true)]
        void SendCommand(Command command, string from);
        //void SendMessage(string message, string counter);
    }
}