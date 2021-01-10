using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace severnmt
{
    public partial class IPForm : Form
    {
        public IPForm(string ip,string port)
        {
            InitializeComponent();
            IP_label.Text = ip;
            Portlabel.Text = port;
            this.Text = "Ip Address"; 
                }

        private void Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
