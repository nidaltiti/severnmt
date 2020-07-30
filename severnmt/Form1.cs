using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Xamarin.Forms;
using System.Threading;
using System.Runtime.InteropServices;
//using Microsoft.DirectX.AudioVideoPlayback;
namespace severnmt
{

    public partial class Form1 : Form
    {
        Listen _listen;
        Listen _listen2;
        private string outputFolder;
        Socket sck;
        string data;
        
        Tranferclint transferClient;
        bool ClintConnction= false;
        public Form1()
        {
            InitializeComponent();
           // _listen = new Listen(8);
           //_listen.socketAccpete += _listen_Accepted;
           // _listen2 = new Listen(9);
           
           // _listen.socketAccpete += _listen2_Accepted;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            outputFolder = "Transfers";

            //If it does not exist, create it.
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }
        }


        private void Conn_Click(object sender, EventArgs e)
        {
            
            Invoke((MethodInvoker)delegate
            {

                if (connectbutton.Text == "Conncetion")
                {
                    _listen = new Listen(8);
                    _listen.Start();
                    _listen.socketAccpete += _listen_Accepted;
                    _listen2 = new Listen(9);
                    _listen2.Start();
                    _listen.socketAccpete += _listen2_Accepted;
                    connectbutton.Text = "Diconncetion";

                    ClintConnction = true;

                }
                else {
                    connectbutton.Text = "Conncetion";


                    _listen.Stop();
                    _listen2.Stop();

                }
            });

        }

        private void _listen2_Accepted(Socket Sk)
        {
            try
            {


                if (transferClient == null)
                {
                    //Create our new transfer client.
                    //And attempt to connect
                    transferClient = new Tranferclint();
                    transferClient.Connect(Sk);
                    transferClient.OutputFolder = outputFolder;
                    //  Run the client
                    transferClient.Run();

                    transferClient.Queued += TransferClient_Queued;
                    //  Enabled = false;
                }  
                else
                {
                    //This means we're trying to disconnect.

                }
            }
            catch { }
        }
       // List<cilent> cilentlist = new List<cilent>();
        private void _listen_Accepted(Socket Sk)
        {

            cilent cilent = new cilent(Sk); 
                cilent.Receive += Cilent_Receive;
                cilent.Disconnted += Cilent_Disconnted;
           
                //Start();






            //   sck = Sk;



        }

        private void Cilent_Disconnted(cilent sender)
        {
            Invoke((MethodInvoker)delegate
            { 


                   
                       
                        MessageBox.Show("close");
                    
                
            });
        }

        //private void _Cilent_Receive(cilent sender, byte[] data)
        //{
        //    MessageBox.Show("xxx");

        //}


        private void DataRecevived_FReceived(string Data)
        {
            throw new NotImplementedException();
        }

        private void Cilent_Receive( cilent sender,byte[] Data)
        {



            this.Invoke((MethodInvoker)delegate
            {
                string stringdata = Encoding.Default.GetString(Data);

               

                try
                {
                    //  string stringdata = n.ToString();
                    string Arrayjson = "[" + stringdata + "]";
                    string Sendjson = JsonConvert.SerializeObject(Arrayjson);

                    JArray formatted = JArray.Parse(stringdata);
                    int number = formatted[0]["filebyet"].Value<int>();
                    byte[] bytes = BitConverter.GetBytes(number);
                    if (BitConverter.IsLittleEndian) { }




                    //MemoryStream theMemStream = new MemoryStream();

                    //theMemStream.Write(bytes, 0, bytes.Length);


                    //FileStream fileStream = File.Open(@"C:\Users\nidal\Desktop\temp.txt", FileMode.Create);

                    //theMemStream.WriteTo(fileStream);

                    //fileStream.Close();

                    ListViewItem item = new ListViewItem(formatted[0]["NameFile"].Value<string>());
                    // item.SubItems.Add(formatted[0]["NameFile"].Value<string>());
                    //  MessageBox.Show(formatted[0]["Type"].Value<string>());
                    item.SubItems.Add(formatted[0]["Type"].Value<string>());
                    listfiles.Items.Add(item);
                }
                catch
                {
                    int fox = Data.Length;

                    //This means we're trying to disconnect.
                    if (fox > 0)

                    MessageBox.Show(stringdata);
                    else
                    { if (ClintConnction )
                        {
                            // int fox = Data.Length;

                            
                             ClintConnction = false;
                        }
                       

                    }

                }

            });


        }
        //  private Tranferclint transferClient=new  Tranferclint;
        private void TransferClient_Queued(object sender, queue queue)
        {
            if (queue.Type == QueueType.Download)
            {
                transferClient.StartTransfer(queue);
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog o = new OpenFileDialog())
            {
                o.Filter = "All Files (*.*)|*.*";
                o.Multiselect = true;

                if (o.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (string file in o.FileNames)
                    {
                        //transferClient.QueueTransfer(file);

                        transferClient.QueueTransfer(file);

                    }
                }
            }
        }
    }
}
        
