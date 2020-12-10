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
using static severnmt.Tranferclint;
using System.Diagnostics;
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
        int movmouse = 1;
        bool anycheckbox_ischecked = false;
        bool openconntion;
        string data;
        List<cilent> cilents = new List<cilent>();
        Tranferclint transferClient;
        bool ClintConnction = false;

        bool finsh = false;

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
        { Form1_Load(null, null); }




        private void connction() {
            Invoke((MethodInvoker)delegate
                 {

                     if (openconntion != true)
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
                             if (transferClient != null)
                                 transferClient.Close();
                        //   transferClient = null;
                        if (_cilent != null)
                             {

                                 _cilent.close();
                             }
                             transferClient = new Tranferclint();
                         }
                         catch { }
                         connectbutton.Text = "Conncetion";
                         listfiles.ContextMenuStrip = null;
                        openconntion = false;
                     }

                 });

        }

        private void tranlistening_Accepted(Socket Sk)
        {
            try
            {


               
                    // return;
                    //Create our new transfer client.
                    //And attempt to connect
                    transferClient = new Tranferclint();
                    transferClient.Connect(Sk);
                    transferClient.OutputFolder = outputFolder;
                    //  Run the client
                   

                    transferClient.Queued += TransferClient_Queued;
                transferClient.ProgressChanged += TransferClient_ProgressChanged;
                    //  Enabled = false;
                    transferClient.Stopped += TransferClient_Stopped;

                transferClient.Complete += TransferClient_Complete;
                transferClient.Disconnected += TransferClient_Disconnected; ;

                transferClient.Run();



            }
            catch { }
        }

        private void TransferClient_Complete(object sender, queue queue)
        {
            bool finsh = false;
            foreach (queue q in queueList)
            {

                if (q.Progress == 100 || !q.Running)
                {

                

                finsh = true;


            }
                else
                {

                    finsh = false;
                    break;

                }


            }
            if (finsh)
            {
              
                queueList.Clear();
                if (queue.Filename != "list.json")
                {
                    Process.Start(outputFolder);
                }
                 File.Delete(outputFolder + "\\commad.json");
               
            }
         







        }

        private void TransferClient_ProgressChanged(object sender, queue queue)
        {
            if (InvokeRequired)
            {
                Invoke(new TransferEventHandler(TransferClient_ProgressChanged), sender, queue);
                return;
            }
        //    listfiles.Items[queue.ID.ToString()].SubItems[2].Text = queue.Progress + "%";


            progessing(queue);
        }

        private void TransferClient_Disconnected(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
            foreach (queue q in queueList) { q.Close(); }
            transferClient = null;
            deregisterEvents();
        }

        private void TransferClient_Stopped(object sender, queue queue)
        {


            //  if(i==0)
            queueList.Clear();
        }

        // List<cilent> cilentlist = new List<cilent>();
        private void _listen_Accepted(Socket Sk)
        {
            // sck = Sk;
            //  MessageBox.Show("connct");
            cilent cilent = new cilent(Sk);
            cilent.Receive += Cilent_Receive;
            cilent.Disconnted += Cilent_Disconnted;
            ClintConnction = true;
            listfiles.ContextMenuStrip = MouseRight;
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
                queueList.Clear();
                //transferClient.Close();
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

        private void Cilent_Receive(cilent sender, byte[] Data)
        {
            string stringdata = Encoding.UTF8.GetString(Data);

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

        private void _checkBox_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < Boxes.Count)
            {
                if (Boxes[i].Checked)
                {

                    MessageBox.Show(i.ToString());




                }
                i++;
            }
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
            if (InvokeRequired)
            {
                Invoke(new TransferEventHandler(TransferClient_Queued), sender, queue);
                return;
            }


          


            //   string namefile = Path.GetFileName(file);
            //  string typefile = Path.GetExtension(file).ToLower().Contains("jpg") || Path.GetExtension(file).ToLower().Contains("png") ? "Image" : "Video";

            string type = queue.Type == QueueType.Download ? "Download" : "Upload";



            if (type == "Upload") {
                if (Path.GetFileName(queue.Filename)!= "commad.json") {
                    AddViewItem(queue.Filename, queue.Typefile, type, queue); } }



            if (queue.Type == QueueType.Download)
            {
                transferClient.StartTransfer(queue);

                existIthem(queue);
                queueList.Add(queue);
            }
           
        }

    private void existIthem(queue queue)// check were is name file in Listview to dowload
       {  

                for (int i = 0; i < listfiles.Items.Count; i++) {

                if ( Path.GetFileName( queue.Filename) == listfiles.Items[i].SubItems[0].Text)
                {

                    listfiles.Items[i].Tag = queue; //Set the tag to queue so we can grab is easily.
                    listfiles.Items[i].Name = queue.ID.ToString();

                    listfiles.Items[i].SubItems[2].Text = "0%   Downloading";


                }

            }
        }
        List<string> file = new List<string>();
        bool sendfile = false;

        public object MouseButtonState { get; private set; }

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
                        bool allowupload = true;
                       // transferClient.QueueTransfer(file);
                      
                     for(int i=0; i < listfiles.Items.Count; i++)
                        {
                            if(Path.GetFileName(file) == listfiles.Items[i].SubItems[0].Text)
                            {

                                allowupload = false;
                                MessageBox.Show("Please change name"+" file  "+ Path.GetFileName(file) + " this name ready Exist");
                                break;
                            }



                        }


                        if (allowupload)
                        {
                            transferClient.QueueTransfer(file);
                        }




                    }

                }




            }
           



            
        } 
            
        




        private void Progress_Complete()
        {

            for (int i = 0; i < queueList.Count; i++)
            {







                try
                {

                    if (queueList[i].Progress == 100 || !queueList[i].Running)
                    {
                        for (int j = 0; j < listfiles.Items.Count; j++)




                            if (listfiles.Items[j].SubItems[0].Text == Path.GetFileName(queueList[i].Filename))
                            {



                                listfiles.Items[j].UseItemStyleForSubItems = false;

                                listfiles.Items[j].SubItems[2].ForeColor = System.Drawing.Color.Green;
                                listfiles.Items[j].SubItems[2].Text = " 100% Complete";



                                //  if(i==0)
                                queueList.RemoveAt(i);

                            }
                    }

                }
                catch { }


            }





        }

        bool readbool = false;

        private void progessing(queue queue)
        {
            try
            {
                //   for (int i = 0; i < queueList.Count; i++)
                // {










                // for (int j = 0; j < listfiles.Items.Count; j++)




                //  if (listfiles.Items[j].SubItems[0].Text == Path.GetFileName(queueList[i].Filename))
                // {

                if (queue.Filename != "list.json" & queue.Filename !="commad.json")
                {

                    listfiles.Items[queue.ID.ToString()].UseItemStyleForSubItems = false;

                    listfiles.Items[queue.ID.ToString()].SubItems[2].ForeColor = queue.Type == QueueType.Download ? System.Drawing.Color.Brown : System.Drawing.Color.Blue;

                    string type = queue.Type == QueueType.Download ? "Downloading" : "Uploading";
                    // listfiles.Items[j].SubItems[2].Text = queue.Progress.ToString() + "%" + type;

                    listfiles.Items[queue.ID.ToString()].SubItems[2].Text = queue.Progress + "%" + type;
                }

                    if (queue.Progress == 100 || !queue.Running)
                    {
                    if (queue.Filename ==Path.GetFileName( "list.json"))
                    {

                        readbool = true;
                           
                        
                    }


                    else
                    {
                        if (queue.Filename != "list.json" & queue.Filename != "commad.json")
                        {

                            listfiles.Items[queue.ID.ToString()].UseItemStyleForSubItems = false;

                            listfiles.Items[queue.ID.ToString()].SubItems[2].ForeColor = System.Drawing.Color.Green;
                            listfiles.Items[queue.ID.ToString()].SubItems[2].Text = " 100% Complete";
                        }
                    }
                    }

                     







                //}
            }
            catch { }
        }

        private void readjsonFile()
        {
            using (StreamReader read = new StreamReader(outputFolder + "/list.json"))
            {


                string reader = read.ReadToEnd();
                string Arrayjson = reader;


                JArray formatted = JArray.Parse(Arrayjson);


                //ListViewItem item = new ListViewItem(formatted[0]["NameFile"].Value<string>());
                int i = 0;

                while (i>-1) {
                    // MessageBox.Show(formatted[i]["NameFile"].Value<string>());

                    try
                    {
                        ListViewItem item = new ListViewItem(formatted[i]["NameFile"].Value<string>());

                        item.SubItems.Add(formatted[i]["Type"].Value<string>());
                        item.SubItems.Add("");
                        listfiles.Items.Add(item);


                        i++;
                        AddIhem++;
                    }
                    catch { break; }
                  
                }
                read.Close();
                File.Delete(outputFolder + "/list.json");
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!ClintConnction) { clear_Listview();

                listfiles.ContextMenuStrip = null;


            }

            if (transferClient == null)
            
                return;
                ProgressBar.Value = transferClient.GetOverallProgress();





            //   progessing();
            //   Progress_Complete();


            if (readbool)
            {
                readbool = false;


                readjsonFile();

            }


        }

        private void Refresh_Button(object sender, EventArgs e)
        {
            commandjson _commandjson = new commandjson { numbcommdan = 100 };


            //   JsonConvert.SerializeObject(json_list)
            string convert = JsonConvert.SerializeObject(_commandjson);
            StreamWriter witer = new StreamWriter(outputFolder + "\\commad.json");

            witer.Write(convert);

            witer.Close();

            transferClient.QueueTransfer(outputFolder + "\\commad.json");
            
            clear_Listview();
          
        }

        private void listfiles_DragDrop(object sender, DragEventArgs e)
        {
            List<string> fileDrage = new List<string>();
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
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


                //  AddViewItem(namefile, typefile, "Upload");

                bool allowupload = true;
                // transferClient.QueueTransfer(file);

                for (int j = 0; j< listfiles.Items.Count; j++)
                {
                    if (Path.GetFileName(files[i]) == listfiles.Items[j].SubItems[0].Text)
                    {

                        allowupload = false;
                        MessageBox.Show("Please change name" + " file  " + Path.GetFileName(files[i]) + " this name ready Exist");
                        break;
                    }



                }


                if (allowupload)
                {
                    transferClient.QueueTransfer(files[i]);
                }



               // transferClient.QueueTransfer(files[i]);

                i++;



            }

           





            // MessageBox.Show(m[]);
        }
        private void AddViewItem(string Namefile, string type, string pros, queue q)
        {
            ListViewItem item = new ListViewItem(Namefile);
            item.SubItems.Add(type);
            item.SubItems.Add("0% " + pros);
            listfiles.Items.Add(item);
            item.Tag = q; //Set the tag to queue so we can grab is easily.
            item.Name = q.ID.ToString();
           

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


            if (folder.ShowDialog() == DialogResult.OK)
            {

                label_browser.Text = Path.GetFileName(folder.SelectedPath);
                outputFolder = folder.SelectedPath;
                transferClient.OutputFolder = outputFolder;

            }


        }
        private void deregisterEvents()
        {
            if (transferClient == null)
                return;



            transferClient.Queued -= TransferClient_Queued;
                //  Enabled = false;
             transferClient.Stopped -= TransferClient_Stopped;
             transferClient.Disconnected -= TransferClient_Disconnected;

            transferClient.ProgressChanged -= TransferClient_ProgressChanged;


        }

       

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)// Download button right on mouse
        {
            if (anycheckbox_ischecked)
            {
                checkbox_files(0);
            }
            else { checkbox_files(3); }
            anycheckbox_ischecked = false;

        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)//   Delete button right on mouse
        {
            if (anycheckbox_ischecked)
            {
                checkbox_files(1);
            }
            else { checkbox_files(2); }
            anycheckbox_ischecked = false;

        }
        void checkbox_files(int num)//  send command to clint
        {
            bool Checked = true;
            List<string> st = new List<string>();
            int i = 0;
            if (num == 0 || num == 1)
            {
                while (i < listfiles.Items.Count)
                {
                    if (listfiles.Items[i].Checked)
                    {

                        st.Add(listfiles.Items[i].SubItems[0].Text);




                    }
                    i++;
                }
            }
            else { st.Add(string.Empty); Checked = false; }
            commandjson _commandjson = new commandjson { numbcommdan = num, array = st };


         //   JsonConvert.SerializeObject(json_list)
            string convert = JsonConvert.SerializeObject(_commandjson);
            StreamWriter witer = new StreamWriter(outputFolder + "\\commad.json");

            witer.Write(convert);

            witer.Close();

            transferClient.QueueTransfer(outputFolder + "\\commad.json");


            //  byte[] byet = Encoding.UTF8.GetBytes(convert);



            //  _cilent.send(byet);



            if (num==1||num==2) {

                type_delete(Checked); }
                foreach (ListViewItem item in listfiles.Items) { item.Checked = false; }





        }
        private void type_delete(bool check)//type delete file
        {


            if (check)
            {



                foreach (ListViewItem item in listfiles.Items)
                {



                    if (item.Checked)
                    {

                        item.UseItemStyleForSubItems = false;

                        item.SubItems[2].ForeColor = System.Drawing.Color.Red;
                        item.SubItems[2].Text = "Delete ";



                    };
                }
            }
            else { foreach (ListViewItem item in listfiles.Items) {
                    item.UseItemStyleForSubItems = false;

                    item.SubItems[2].ForeColor = System.Drawing.Color.Red;
                    item.SubItems[2].Text = "Delete ";
                } }

        }
        private void MouseRight_Opening(object sender, CancelEventArgs e)//check any checkbox is checked
        {



            isChecked();




        }
        private void isChecked() {
        for (int i = 0; i < listfiles.Items.Count; i++)
        {
                
            if (listfiles.Items[i].Checked)
            {
                anycheckbox_ischecked = true;
                break;


            }
        }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string convert = "100";



            byte[] byet = Encoding.ASCII.GetBytes(convert);



            transferClient.send(byet);
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            isChecked();
            if (anycheckbox_ischecked)
            {
                checkbox_files(1);
            }
            else { checkbox_files(2); }
            anycheckbox_ischecked = false;
        }

        private void clear_check_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listfiles.Items) { item.Checked = false; }
        }

        private void sreachbox_Enter(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter) {


                foreach (ListViewItem items in listfiles.Items)
                {

                    if (items.SubItems[0].Text.ToLower().Contains(sreachbox.Text)|| items.SubItems[0].Text.ToUpper().Contains(sreachbox.Text)) { items.Checked = true; }


                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
        int movx, movy;
        private void toolStripLabel3_MouseDown(object sender, MouseEventArgs e)
        {


           if (e.Button == MouseButtons.Left)
    {
        // Release the mouse capture started by the mouse down.
       // lblMoveForm.Capture = false;

        // Create and send a WM_NCLBUTTONDOWN message.
        const int WM_NCLBUTTONDOWN = 0x00A1;
        const int HTCAPTION = 2;
        Message msg =
            Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                new IntPtr(HTCAPTION), IntPtr.Zero);
        this.DefWndProc(ref msg);
    }

        }

        private void toolStripLabel3_MouseUp(object sender, MouseEventArgs e)
        {
            movmouse = 0;
        }

        private void toolStripLabel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (movmouse==1)
            {
                this.SetDesktopLocation(MousePosition.X  , MousePosition.Y );
            
            }
        }
    }
}
        
