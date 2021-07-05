using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace otobus_otomasyon
{
    public partial class admin_panel : Form
    {
        public admin_panel()
        {
            InitializeComponent();
        }
       

        private void admin_panel_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

       

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void kullanıcıPaneliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin ad = new admin();
            ad.ShowDialog();
           
        }

        private void oturumKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void biletPaneliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            biletal al = new biletal();
            al.ShowDialog();
        }

        private void biletİptalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bilet_iptal bip = new bilet_iptal();
            bip.ShowDialog();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hakkinda hfrm = new Hakkinda();
            hfrm.ShowDialog();
        }

        private void işlemlerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void biletListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bilet_Listele bil = new Bilet_Listele();
            bil.ShowDialog();
            
        }

        private void admin_panel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
