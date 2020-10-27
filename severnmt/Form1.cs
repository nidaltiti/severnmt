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
        Listen tranlistening;
        private string outputFolder;
        Socket sck;
        cilent _cilent;
        bool openconntion;
        string data;
        List<cilent> cilents = new List<cilent>();
        Tranferclint transferClient;
        bool ClintConnction= false;
        int AddIhem = 0;

        List<CheckBox> Boxes = new List<CheckBox>();
        public Form1()
        {
            InitializeComponent();
           // _listen = new Listen(8);
           //_listen.socketAccpete += _listen_Accepted;
           // tranlistening = new Listen(9);
           
           // _listen.socketAccpete += tranlistening_Accepted;


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

                if (openconntion !=true)
                {
                    _listen = new Listen(8);
                    _listen.Start();
                    _listen.socketAccpete += _listen_Accepted;
                    tranlistening = new Listen(9);
                    tranlistening.Start();
                    tranlistening.socketAccpete += tranlistening_Accepted;
                    connectbutton.Text = "Diconncetion";
                    
                  //  ClintConnction = true;
                    openconntion = true;
                }
                else {
                    
                    try
                    {

                        _listen.Stop();
                        tranlistening.Stop();
                        transferClient.Close();
                        transferClient = null;
                        if (_cilent != null)
                        {

                            _cilent.close();
                        }

                    }
                    catch { }
                    connectbutton.Text = "Conncetion";
                   
                    openconntion = false;
                }
            });

        }

        private void tranlistening_Accepted(Socket Sk)
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
          //  MessageBox.Show("connct");
            cilent cilent = new cilent(Sk); 
                cilent.Receive += Cilent_Receive;
                cilent.Disconnted += Cilent_Disconnted;
            ClintConnction = true;

            _cilent = cilent;


            // cilents.Add(cilent);
            //Start();






            //   sck = Sk;



        }

        private void Cilent_Disconnted(cilent sender)
        {
            try
            {
                
                //tranlistening.Stop();
              //  _listen = null;
            }
            catch { MessageBox.Show("filed"); }

            new Thread(() =>
            {
             //   _listen.Stop();
                _cilent.close();
                sender.close();
                ClintConnction = false;
              //  clear_Listview();
                if (openconntion)
                {
                    //_listen = new Listen(8);
                    //_listen.Start();
                    ////tranlistening = new Listen(9);
                    ////tranlistening.Start();
                    //_listen.socketAccpete += _listen_Accepted;
                    Thread.Sleep(500);
                }
            }).Start();
               
            
            //tranlistening = new Listen(9);


            Invoke((MethodInvoker)delegate
            {
              //  new Thread(() => { Thread.Sleep(1000); }).Start();


                     // MessageBox.Show("close");


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
            string stringdata = Encoding.Default.GetString(Data);

          //  MessageBox.Show(stringdata);


            this.Invoke((MethodInvoker)delegate
            {


            try
            {
               
                string Arrayjson = "[" + stringdata + "]";
         

                JArray formatted = JArray.Parse(Arrayjson);
                  

                    ListViewItem item = new ListViewItem(formatted[0]["NameFile"].Value<string>());
                 
                    item.SubItems.Add(formatted[0]["Type"].Value<string>());
                    listfiles.Items.Add(item);
                    CheckBox _checkBox = new CheckBox();


                    System.Drawing.Point _point = new System.Drawing.Point(item.SubItems[1].Bounds.X +40, item.SubItems[1].Bounds.Y );

                    _checkBox.Location= _point;
                    Boxes.Add(_checkBox);
                    listfiles.Controls.Add(Boxes[AddIhem]);

                    AddIhem++;




                }
                catch
            {
               // int fox = Data.Length;

                //This means we're trying to disconnect.
              //  if (fox == 0)
              //  {

                    //   // MessageBox.Show(stringdata);

                    //  // _listen.Stop();
                    //  // tranlistening.Stop();

                    //}
                    //else
                    //{
                    //    if (ClintConnction)
                    //    {
                    //        // int fox = Data.Length;


                    //        ClintConnction = false;
                    //    }


                    //  }

                      }

                });


        }
        private void clear_Listview()
        {
            try
            {
                listfiles.Items.Clear();
               //  for (int n = 0; n <=listfiles.Items.Count; n++) { listfiles.Items.RemoveAt(n); }
               // listfiles.Items.RemoveAt(0);
               foreach (CheckBox b in Boxes) { listfiles.Controls.Remove(b); }
               AddIhem = 0;
                Boxes.Clear();
            }
            catch { }

        }
        private void checkboxes() { }
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
                        string namefile = Path.GetFileName(file);
                        string typefile = Path.GetExtension(file).ToLower().Contains("jpg") || Path.GetExtension(file).ToLower().Contains("png") ? "Image" : "Video";



                        AddViewItem(namefile, typefile);
                        transferClient.QueueTransfer(file);

                    }
                }
            }
        }


        private void timer_Tick(object sender, EventArgs e)
        {
         if(!ClintConnction ) { clear_Listview(); }

        }

        private void Reload_Click(object sender, EventArgs e)
        {

        }

        private void listfiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files= (string[] )e.Data.GetData(DataFormats.FileDrop, false);
            int i = 0;
            while (i < files.Length)
            {
                //ListViewItem item = new ListViewItem(Path.GetFileName(files[i]));
                //item.SubItems.Add(Path.GetExtension(files[i]).ToLower().Contains("jpg") ||Path.GetExtension(files[i]).ToLower().Contains("png") ? "Image" : "Video");

                //listfiles.Items.Add(item);
                //CheckBox _checkBox = new CheckBox();


                //System.Drawing.Point _point = new System.Drawing.Point(item.SubItems[1].Bounds.X + 40, item.SubItems[1].Bounds.Y);

                //_checkBox.Location = _point;
                //Boxes.Add(_checkBox);
                //listfiles.Controls.Add(Boxes[AddIhem]);

                //AddIhem++;

                string namefile = Path.GetFileName(files[i]);
                string typefile = Path.GetExtension(files[i]).ToLower().Contains("jpg") || Path.GetExtension(files[i]).ToLower().Contains("png") ? "Image" : "Video";


                AddViewItem(namefile, typefile);
                transferClient.QueueTransfer(files[i]);
                i++;

             

            }
           // MessageBox.Show(m[]);
        }
        private void AddViewItem(string Namefile , string type)
        {
            ListViewItem item = new ListViewItem(Namefile);
            item.SubItems.Add(type);

            listfiles.Items.Add(item);
            CheckBox _checkBox = new CheckBox();


            System.Drawing.Point _point = new System.Drawing.Point(item.SubItems[1].Bounds.X + 40, item.SubItems[1].Bounds.Y);

            _checkBox.Location = _point;
            Boxes.Add(_checkBox);
            listfiles.Controls.Add(Boxes[AddIhem]);

            AddIhem++;
        }
        private void listfiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;



        }
    }
}
        
