using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDepositer
{
    public static class Vault
    {
        public static List<StorageItem> StorageList = new List<StorageItem>();
        public static List<SendItem> SendList = new List<SendItem>();
        public static List<StorageItem> AssembleList = new List<StorageItem>();
        public static CommandQueue MainQueue;
        public static List<PeerEntry> Peers = new List<PeerEntry>();
    }
}
