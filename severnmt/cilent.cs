using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace severnmt
{
    class cilent
    { public string ID {
            get;
            private set;


        }
        public IPEndPoint EndPoint {
            get;
            private set;

        }
        Socket sck= new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public cilent(Socket accpet)
        {
            sck = accpet;
            ID = Guid.NewGuid().ToString();

            EndPoint = (IPEndPoint)sck.RemoteEndPoint;
            sck.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
        }
        void callback(IAsyncResult ar)
        {

            try
            {
                sck.EndReceive(ar);



                byte[] buf = new byte[8192];
                int rec = sck.Receive(buf, buf.Length, 0);




                if (rec <= buf.Length)
                {

                    Array.Resize<byte>(ref buf, rec);

                    if (Receive != null)
                    {

                        Receive(this, buf);

                    }
                    if (rec <= 0)
                    {
                        if (Disconnted != null)
                        {

                            Disconnted(this);

                        }
                       

                    }
                    sck.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
                }

            


                }
                catch
                {


                    close();
                    if (Disconnted != null)
                    {

                        Disconnted(this);

                    }

                }
            }

        public void send()
        {

           byte[] byetes = Encoding.ASCII.GetBytes("look");
            sck.Send(byetes);
        }
        public void close() {

            sck.Close();
                }
        public delegate void cilentReceiveHanldy(cilent sender, byte[] data);
        public event cilentReceiveHanldy Receive;

        public delegate void cilentDisconnctedhandly(cilent sender);
        public event cilentDisconnctedhandly Disconnted;


    }
}
