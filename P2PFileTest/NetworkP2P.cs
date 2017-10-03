using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.PeerToPeer;
using System.ServiceModel;
using System.Configuration;
using System.Windows.Forms;

namespace NetFileManager
{
    public class NetworkP2P
    {
        public string NetworkName;
        public string Comment;

        private Config Config;
        private PeerName peerName;
        private PeerNameRegistration pnReg;
        private PeerNameResolver resolver;
        private int Port = 13027;

        public static List<PeerEntry> Peers = new List<PeerEntry>();

        public NetworkP2P(string networkName, Config config)
        {
            NetworkName = networkName;
            Config = config;
        }

        public NetworkP2P(string networkName, int Port)
        {
            NetworkName = networkName;
        }

        internal void Init()
        {
            // Creates a secure (not spoofable) PeerName
            //peerName = new PeerName(Application.ProductName, PeerNameType.Secured);
            peerName = new PeerName(Application.ProductName + "." + Application.CompanyName, PeerNameType.Secured);
            pnReg = new PeerNameRegistration();
            pnReg.PeerName = peerName;

            pnReg.Port = (int)Config.Port;

            // OPTIONAL

            // The properties set below are optional.  
            // You can register a PeerName without setting these properties
            // but this properties can help identify PC
            pnReg.Comment = "up to 39 unicode char comment";
            pnReg.Data = Encoding.UTF8.GetBytes("A data blob associated with the name"); // @TODO Add binary data for Peer2Peer Netwwork

            // OPTIONAL
            // The properties below are also optional, but will not be set (ie. are commented out) for this example

            //pnReg.IPEndPointCollection = // a list of all {IPv4/v6 address, port} pairs to associate with the peername
            //pnReg.Cloud = //the scope in which the name should be registered (local subnet, internet, etc)
            //pnReg.Cloud = Cloud.Global; // resolve in Global Network - 
            pnReg.Cloud = Cloud.Global; // resolve in Global Network - 
        }

        internal void Stop()
        {
            //Stop the publish for others to resolve
            //Logger.Log.Info("Stop P2P.");
            pnReg.Stop();
        }

        internal void Start()
        {
            //Starting the registration means the name is published for others to resolve
            //Logger.Log.Info("Start P2P.");
            pnReg.Start();
        }

        internal void Resolve()
        {
            //Logger.Log.Info("Start P2P resolver...");
            // create a resolver object to resolve a peername
            PeerNameResolver resolver = new PeerNameResolver();

            // resolve the PeerName - this is a network operation and will block until the resolve completes
            PeerNameRecordCollection results = resolver.Resolve(peerName, Cloud.Available, 100); // max 100 PC

            foreach (PeerNameRecord record in results)
            {
                PeerEntry peer = new PeerEntry();
                if (record.Comment != null)
                {
                    peer.Comment = record.Comment;
                }

                if (record.Data != null)
                {
                    peer.Data = System.Text.Encoding.ASCII.GetString(record.Data);
                }

                peer.Endpoints = record.EndPointCollection;
                //foreach (IPEndPoint endpoint in record.EndPointCollection)
                //{
                //    Console.WriteLine("\t Endpoint:{0}", endpoint);
                //    Console.WriteLine();
                //}
                NetworkP2P.Peers.Add(peer);

                foreach (IPEndPoint endpoint in record.EndPointCollection)
                {
                    //Console.WriteLine("\t Endpoint:{0}", endpoint);
                    //Console.WriteLine();
                }
            }
        }
    }
}

