namespace severnmt
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Timer timer;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listfiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MouseRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Addriss = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddrissBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.PortBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.label_browser = new System.Windows.Forms.ToolStripLabel();
            this.Open_Browser = new System.Windows.Forms.ToolStripButton();
            this.connectbutton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.sreachbox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.clear_check = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.Delete_Button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.clearCheckboxsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            timer = new System.Windows.Forms.Timer(this.components);
            this.MouseRight.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // listfiles
            // 
            this.listfiles.AllowDrop = true;
            this.listfiles.BackColor = System.Drawing.SystemColors.Info;
            this.listfiles.CheckBoxes = true;
            this.listfiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listfiles.ContextMenuStrip = this.MouseRight;
            this.listfiles.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listfiles.GridLines = true;
            this.listfiles.HideSelection = false;
            this.listfiles.Location = new System.Drawing.Point(0, 40);
            this.listfiles.Name = "listfiles";
            this.listfiles.Size = new System.Drawing.Size(725, 418);
            this.listfiles.TabIndex = 1;
            this.listfiles.UseCompatibleStateImageBehavior = false;
            this.listfiles.View = System.Windows.Forms.View.Details;
            this.listfiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listfiles_DragDrop);
            this.listfiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listfiles_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 174;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 189;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Process";
            this.columnHeader3.Width = 351;
            // 
            // MouseRight
            // 
            this.MouseRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.clearCheckboxsToolStripMenuItem});
            this.MouseRight.Name = "MouseRight";
            this.MouseRight.Size = new System.Drawing.Size(181, 92);
            this.MouseRight.Opening += new System.ComponentModel.CancelEventHandler(this.MouseRight_Opening);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Addriss,
            this.toolStripSeparator1,
            this.AddrissBox,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.toolStripSeparator3,
            this.PortBox,
            this.toolStripSeparator4,
            this.label_browser,
            this.Open_Browser,
            this.connectbutton,
            this.toolStripSeparator6,
            this.toolStripLabel3,
            this.sreachbox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(737, 27);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Addriss
            // 
            this.Addriss.Name = "Addriss";
            this.Addriss.Size = new System.Drawing.Size(62, 24);
            this.Addriss.Text = "Ip Address";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // AddrissBox
            // 
            this.AddrissBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AddrissBox.Name = "AddrissBox";
            this.AddrissBox.ReadOnly = true;
            this.AddrissBox.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(29, 24);
            this.toolStripLabel2.Text = "Port";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // PortBox
            // 
            this.PortBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(40, 27);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // label_browser
            // 
            this.label_browser.Name = "label_browser";
            this.label_browser.Size = new System.Drawing.Size(86, 24);
            this.label_browser.Text = "toolStripLabel1";
            // 
            // Open_Browser
            // 
            this.Open_Browser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Open_Browser.Image = ((System.Drawing.Image)(resources.GetObject("Open_Browser.Image")));
            this.Open_Browser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Open_Browser.Margin = new System.Windows.Forms.Padding(0, 5, 0, 2);
            this.Open_Browser.Name = "Open_Browser";
            this.Open_Browser.Size = new System.Drawing.Size(23, 20);
            this.Open_Browser.Text = "toolStripButton1";
            this.Open_Browser.Click += new System.EventHandler(this.Open_Browser_Click);
            // 
            // connectbutton
            // 
            this.connectbutton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.connectbutton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.connectbutton.Image = ((System.Drawing.Image)(resources.GetObject("connectbutton.Image")));
            this.connectbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectbutton.Name = "connectbutton";
            this.connectbutton.Padding = new System.Windows.Forms.Padding(1, 0, 10, 1);
            this.connectbutton.Size = new System.Drawing.Size(84, 24);
            this.connectbutton.Text = "Conncetion";
            this.connectbutton.Click += new System.EventHandler(this.Conn_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(42, 24);
            this.toolStripLabel3.Text = "Search";
            // 
            // sreachbox
            // 
            this.sreachbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sreachbox.Name = "sreachbox";
            this.sreachbox.Size = new System.Drawing.Size(130, 27);
            this.sreachbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sreachbox_Enter);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clear_check,
            this.toolStripSeparator7,
            this.ProgressBar,
            this.toolStripSeparator8,
            this.RefreshButton,
            this.toolStripSeparator9,
            this.toolStripButton2,
            this.toolStripSeparator5,
            this.Delete_Button,
            this.toolStripSeparator10,
            this.toolStripButton4,
            this.toolStripSeparator11,
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 461);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(737, 25);
            this.toolStrip2.TabIndex = 7;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // clear_check
            // 
            this.clear_check.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clear_check.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clear_check.Name = "clear_check";
            this.clear_check.Size = new System.Drawing.Size(99, 22);
            this.clear_check.Text = "Clear Checkboxs";
            this.clear_check.Click += new System.EventHandler(this.clear_check_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 22);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshButton.Image")));
            this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(69, 22);
            this.RefreshButton.Text = "Refresh ";
            this.RefreshButton.Click += new System.EventHandler(this.Refresh_Button);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(79, 22);
            this.toolStripButton2.Text = "Send Files";
            this.toolStripButton2.Click += new System.EventHandler(this.Send_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Image = ((System.Drawing.Image)(resources.GetObject("Delete_Button.Image")));
            this.Delete_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(116, 22);
            this.Delete_Button.Text = "Delete All /Select";
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton4.Text = "Setting";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // clearCheckboxsToolStripMenuItem
            // 
            this.clearCheckboxsToolStripMenuItem.Name = "clearCheckboxsToolStripMenuItem";
            this.clearCheckboxsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearCheckboxsToolStripMenuItem.Text = "Clear Checkboxs";
            this.clearCheckboxsToolStripMenuItem.Click += new System.EventHandler(this.clear_check_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 486);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listfiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseRight.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listfiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel Addriss;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox AddrissBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox PortBox;
        private System.Windows.Forms.ToolStripButton connectbutton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel label_browser;
        private System.Windows.Forms.ToolStripButton Open_Browser;
        private System.Windows.Forms.ContextMenuStrip MouseRight;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton clear_check;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton Delete_Button;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox sreachbox;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem clearCheckboxsToolStripMenuItem;
    }
}

