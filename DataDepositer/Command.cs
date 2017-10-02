/**
 * RuDiCon Soft (c) 2017
 * 
 * Class for single Command data.
 * 
 * @created 2017-09-27 Artem Niikolaev
 * 
 * 
 * @info
 * 
 * Command format : 
 *                  Type   - Type of Command
 *                  Sender - Who send command
 *                  Reciver - Who must recive command
 *                  List of Data - Command specific data.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDepositer
{
    //public enum CommandType
    //{
    //   None,
    //   TestConnect,
    //   Ready,
    //   StoreFile,
    //   SendFile,
    //   RequestFile,
    //   RequestChunk,
    //   CheckFile,
    //   CheckChunk
    //}

    [Serializable]
    public class Command
    {
        public CommandType type;
        public string Message { get => v1; set => v1 = value; }
        public int Counter { get => v2; set => v2 = value; }

        private string v1;
        private int v2;


        public Command()
        {

        }

        public Command(string v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

    }
}
