using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace severnmt
{
    public partial class Setting_from : Form
    {
        string port, folder;
        public Setting_from()
        {
           
            InitializeComponent();
        }
        public delegate void save(object s);
        public event save infomation;

        bool Tow_dictionary = false;

        bool refresh = false;
        bool saveGallery = false;





        private void Setting_from_Load(object sender, EventArgs e)
        {


            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(4,4 , paypal_button.Width-8 , paypal_button.Height-8 );

            paypal_button.Region= new Region(p);
            porttext.Text = Properties.Settings.Default.Port.ToString();
            textFolder.Text = Properties.Settings.Default.FolderName;

            Tow_Dictionary.Checked= Tow_dictionary = Properties.Settings.Default.TowDirectory;

            Refresh.Checked= refresh = Properties.Settings.Default.AutoRefreach;
            Save_grallery.Checked= saveGallery = Properties.Settings.Default.SaveGarllery;



        }
        
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FolderBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog _browserDialog = new FolderBrowserDialog();
            if (_browserDialog.ShowDialog() == DialogResult.OK) {

                textFolder.Text = _browserDialog.SelectedPath;




            }
        }

        private void Tow_Dictionary_CheckedChanged(object sender, EventArgs e)
        {
            Tow_dictionary = Tow_Dictionary.Checked;
          
        }

        private void Refresh_CheckedChanged(object sender, EventArgs e)
        {
            refresh = Refresh.Checked;

        }

        private void Save_grallery_CheckedChanged(object sender, EventArgs e)
        {
            saveGallery = Save_grallery.Checked;
        }

        private void paypal_button_click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/donate?hosted_button_id=9LJP5PTR5TXKW");

        }

        private void Save_Click(object sender, EventArgs e)
        {
            Save_paramter  Save = new Save_paramter() {  namefollder=textFolder.Text, port=Convert.ToInt32( porttext.Text) , Tow_Directory = this.Tow_dictionary, Refresh=refresh,GallryAtudo= saveGallery };
         //   d.namefollder = "hi nidal";
            if (infomation != null) { infomation(Save); }
            this.Close();


        }
    }
}
