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
            this.Send = new System.Windows.Forms.Button();
            this.boxmix = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Addriss = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddrissBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.PortBox = new System.Windows.Forms.ToolStripTextBox();
            this.connectbutton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.label_browser = new System.Windows.Forms.ToolStripLabel();
            this.Open_Browser = new System.Windows.Forms.ToolStripButton();
            this.Reload = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            timer = new System.Windows.Forms.Timer(this.components);
            this.MouseRight.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.listfiles.GridLines = true;
            this.listfiles.HideSelection = false;
            this.listfiles.Location = new System.Drawing.Point(44, 48);
            this.listfiles.Name = "listfiles";
            this.listfiles.Size = new System.Drawing.Size(618, 309);
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
            this.columnHeader3.Width = 180;
            // 
            // MouseRight
            // 
            this.MouseRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.MouseRight.Name = "MouseRight";
            this.MouseRight.Size = new System.Drawing.Size(129, 48);
            this.MouseRight.Opening += new System.ComponentModel.CancelEventHandler(this.MouseRight_Opening);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(685, 224);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(93, 23);
            this.Send.TabIndex = 2;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // boxmix
            // 
            this.boxmix.Location = new System.Drawing.Point(170, 403);
            this.boxmix.Name = "boxmix";
            this.boxmix.Size = new System.Drawing.Size(255, 20);
            this.boxmix.TabIndex = 3;
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
            this.connectbutton,
            this.toolStripSeparator4,
            this.label_browser,
            this.Open_Browser});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 38);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Addriss
            // 
            this.Addriss.Name = "Addriss";
            this.Addriss.Size = new System.Drawing.Size(62, 35);
            this.Addriss.Text = "Ip Address";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // AddrissBox
            // 
            this.AddrissBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AddrissBox.Name = "AddrissBox";
            this.AddrissBox.ReadOnly = true;
            this.AddrissBox.Size = new System.Drawing.Size(100, 38);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(29, 35);
            this.toolStripLabel2.Text = "Port";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // PortBox
            // 
            this.PortBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(100, 38);
            // 
            // connectbutton
            // 
            this.connectbutton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.connectbutton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.connectbutton.Image = ((System.Drawing.Image)(resources.GetObject("connectbutton.Image")));
            this.connectbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectbutton.Name = "connectbutton";
            this.connectbutton.Padding = new System.Windows.Forms.Padding(1, 15, 10, 1);
            this.connectbutton.Size = new System.Drawing.Size(84, 35);
            this.connectbutton.Text = "Conncetion";
            this.connectbutton.Click += new System.EventHandler(this.Conn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // label_browser
            // 
            this.label_browser.Name = "label_browser";
            this.label_browser.Size = new System.Drawing.Size(86, 35);
            this.label_browser.Text = "toolStripLabel1";
            // 
            // Open_Browser
            // 
            this.Open_Browser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Open_Browser.Image = ((System.Drawing.Image)(resources.GetObject("Open_Browser.Image")));
            this.Open_Browser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Open_Browser.Margin = new System.Windows.Forms.Padding(0, 5, 0, 2);
            this.Open_Browser.Name = "Open_Browser";
            this.Open_Browser.Size = new System.Drawing.Size(23, 31);
            this.Open_Browser.Text = "toolStripButton1";
            this.Open_Browser.Click += new System.EventHandler(this.Open_Browser_Click);
            // 
            // Reload
            // 
            this.Reload.Location = new System.Drawing.Point(685, 85);
            this.Reload.Name = "Reload";
            this.Reload.Size = new System.Drawing.Size(93, 23);
            this.Reload.TabIndex = 5;
            this.Reload.Text = "Reload";
            this.Reload.UseVisualStyleBackColor = true;
            this.Reload.Click += new System.EventHandler(this.Reload_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(685, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "sendsrting";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Reload);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.boxmix);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.listfiles);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseRight.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listfiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.TextBox boxmix;
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
        private System.Windows.Forms.Button Reload;
        private System.Windows.Forms.ToolStripButton Open_Browser;
        private System.Windows.Forms.ContextMenuStrip MouseRight;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

