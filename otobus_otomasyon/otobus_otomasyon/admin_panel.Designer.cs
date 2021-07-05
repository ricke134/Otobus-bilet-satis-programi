namespace otobus_otomasyon
{
    partial class admin_panel
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.işlemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.biletPaneliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcıPaneliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.biletİptalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.biletListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oturumKapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.işlemlerToolStripMenuItem,
            this.hakkındaToolStripMenuItem,
            this.oturumKapatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(645, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // işlemlerToolStripMenuItem
            // 
            this.işlemlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.biletPaneliToolStripMenuItem,
            this.kullanıcıPaneliToolStripMenuItem,
            this.biletİptalToolStripMenuItem,
            this.biletListeleToolStripMenuItem});
            this.işlemlerToolStripMenuItem.Name = "işlemlerToolStripMenuItem";
            this.işlemlerToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.işlemlerToolStripMenuItem.Text = "İşlemler";
            this.işlemlerToolStripMenuItem.Click += new System.EventHandler(this.işlemlerToolStripMenuItem_Click);
            // 
            // biletPaneliToolStripMenuItem
            // 
            this.biletPaneliToolStripMenuItem.AutoSize = false;
            this.biletPaneliToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.biletPaneliToolStripMenuItem.Image = global::otobus_otomasyon.Properties.Resources.bus_ticket_icon;
            this.biletPaneliToolStripMenuItem.Name = "biletPaneliToolStripMenuItem";
            this.biletPaneliToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.biletPaneliToolStripMenuItem.Text = "Bilet Paneli";
            this.biletPaneliToolStripMenuItem.Click += new System.EventHandler(this.biletPaneliToolStripMenuItem_Click);
            // 
            // kullanıcıPaneliToolStripMenuItem
            // 
            this.kullanıcıPaneliToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.kullanıcıPaneliToolStripMenuItem.Image = global::otobus_otomasyon.Properties.Resources.myspace_icon;
            this.kullanıcıPaneliToolStripMenuItem.Name = "kullanıcıPaneliToolStripMenuItem";
            this.kullanıcıPaneliToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.kullanıcıPaneliToolStripMenuItem.Text = "Kullanıcı Paneli";
            this.kullanıcıPaneliToolStripMenuItem.Click += new System.EventHandler(this.kullanıcıPaneliToolStripMenuItem_Click);
            // 
            // biletİptalToolStripMenuItem
            // 
            this.biletİptalToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.biletİptalToolStripMenuItem.Image = global::otobus_otomasyon.Properties.Resources.Ticket_remove_icon;
            this.biletİptalToolStripMenuItem.Name = "biletİptalToolStripMenuItem";
            this.biletİptalToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.biletİptalToolStripMenuItem.Text = "Bilet İptal";
            this.biletİptalToolStripMenuItem.Click += new System.EventHandler(this.biletİptalToolStripMenuItem_Click);
            // 
            // biletListeleToolStripMenuItem
            // 
            this.biletListeleToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.biletListeleToolStripMenuItem.Image = global::otobus_otomasyon.Properties.Resources.Checklist_icon;
            this.biletListeleToolStripMenuItem.Name = "biletListeleToolStripMenuItem";
            this.biletListeleToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.biletListeleToolStripMenuItem.Text = "Bilet Listele";
            this.biletListeleToolStripMenuItem.Click += new System.EventHandler(this.biletListeleToolStripMenuItem_Click);
            // 
            // hakkındaToolStripMenuItem
            // 
            this.hakkındaToolStripMenuItem.Name = "hakkındaToolStripMenuItem";
            this.hakkındaToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.hakkındaToolStripMenuItem.Text = "Hakkında";
            this.hakkındaToolStripMenuItem.Click += new System.EventHandler(this.hakkındaToolStripMenuItem_Click);
            // 
            // oturumKapatToolStripMenuItem
            // 
            this.oturumKapatToolStripMenuItem.Name = "oturumKapatToolStripMenuItem";
            this.oturumKapatToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.oturumKapatToolStripMenuItem.Text = "Oturum Kapat";
            this.oturumKapatToolStripMenuItem.Click += new System.EventHandler(this.oturumKapatToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 313);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(220, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "AKÜ YAZILIM";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(421, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(421, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::otobus_otomasyon.Properties.Resources.giphy;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(642, 251);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // admin_panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(645, 386);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "admin_panel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.admin_panel_FormClosing);
            this.Load += new System.EventHandler(this.admin_panel_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem işlemlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem biletPaneliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıPaneliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oturumKapatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem biletİptalToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem hakkındaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem biletListeleToolStripMenuItem;
    }
}