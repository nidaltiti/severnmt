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
        List<queue> queueList = new List<queue>();

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
            myAddriss();
            label_browser.Text = Path.GetFileName(outputFolder);

            //If it does not exist, create it.
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            connction();


        }

        private void myAddriss()
        {


            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    AddrissBox.Text = ip.ToString();
                }






            }
            PortBox.Text = "9";
            
        }
        private void Conn_Click(object sender, EventArgs e)
        { connction();  }
      
        
        
        
        private void connction() { 
       Invoke((MethodInvoker)delegate
            {

                if (openconntion !=true)
                {
                    int tranport = Convert.ToInt32(PortBox.Text);
                    int port = tranport - 1;
                    _listen = new Listen(port);
                    _listen.Start();
                    _listen.socketAccpete += _listen_Accepted;
                    tranlistening = new Listen(tranport);
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
                        if(transferClient !=null)
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
                    item.SubItems.Add("");
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
            queueList.Add(queue);
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


      
        
        private void Progress_Complete()
        {

            for (int i = 0; i <  queueList.Count; i++)
            {









                if (queueList[i].Progress == 100 || !queueList[i].Running)
                {
                    for (int j = 0; j <listfiles.Items.Count; j++)




                        if (listfiles.Items[j].SubItems[0].Text == Path.GetFileName(queueList[i].Filename))
                        {



                            listfiles.Items[j].UseItemStyleForSubItems = false;

                            listfiles.Items[j].SubItems[2].ForeColor = System.Drawing.Color.Green;
                            listfiles.Items[j].SubItems[2].Text = " 100% Complete";

                            

                          //  if(i==0)
                                queueList.RemoveAt(i);
                            if (i == 0)
                            
                            { break; }
                        }

                }


                }





            }



        private void progessing()
        {
            for (int i = 0; i < queueList.Count; i++)
            {









                
                    for (int j = 0; j < listfiles.Items.Count; j++)




                        if (listfiles.Items[j].SubItems[0].Text == Path.GetFileName(queueList[i].Filename))
                        {



                            listfiles.Items[j].UseItemStyleForSubItems = false;

                            listfiles.Items[j].SubItems[2].ForeColor = System.Drawing.Color.Blue;
                            
                        
                        listfiles.Items[j].SubItems[2].Text = queueList[i].Progress.ToString()+"%  Upload ";

                           

                        }


                        




                }
            }


        private void timer_Tick(object sender, EventArgs e)
        {
         if(!ClintConnction ) { clear_Listview(); }

            progessing();
            Progress_Complete();

          



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
            item.SubItems.Add("0% Upload");
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

        private void Open_Browser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

          //  folder.ShowDialog();
        
       
        if(folder.ShowDialog() == DialogResult.OK)
            {

                label_browser.Text = Path.GetFileName(folder.SelectedPath);
                outputFolder = folder.SelectedPath;

            }


        }
    }
}
        
