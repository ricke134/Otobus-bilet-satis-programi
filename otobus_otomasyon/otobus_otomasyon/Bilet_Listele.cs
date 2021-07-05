using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace otobus_otomasyon
{
    public partial class Bilet_Listele : Form
    {
        public Bilet_Listele()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=.; initial Catalog=otobus; Integrated Security=true");
        DataSet dset = new DataSet();
        public void doldur()
        {
            baglanti.Open();
            dset.Clear();

            SqlDataAdapter adtr2 = new SqlDataAdapter("SELECT satis.tc AS [T.C No], satis.satis_Adi AS [Ad], satis.satis_Soyadi AS [Soyad], satis.sefer_tarihi AS [Sefer Tarihi], satis.sefer_saati AS [Kalkış Saati], sefer.sefer_nereden AS [Kalkış Şehri], sefer.sefer_nereye AS [Varış Şehri], satis.koltuk_No AS [Koltuk No], sefer.arac_adi AS [Bilet Türü], satis.ucret AS [Bilet Ücreti] FROM satis, sefer WHERE sefer.sefer_id = satis.sefer_id ORDER BY satis.sefer_tarihi ASC", baglanti);
            
            adtr2.Fill(dset, "kullanici");
            dataGridView1.DataSource = dset.Tables["kullanici"];
            adtr2.Dispose();
            baglanti.Close();
        }
        private void Bilet_Listele_Load(object sender, EventArgs e)
        {
            koltuklar.Enabled = false;
            button1.Enabled = false;
            doldur();
        }
        string yazdirilacakMetin = "";

        private void sayfa(object sender, PrintPageEventArgs e)
        {
            Font fontTipi = new Font("Calibri", 14);
            SolidBrush fontRengi = new SolidBrush(Color.Black);
            e.Graphics.DrawString(yazdirilacakMetin, fontTipi, fontRengi, 40, 30);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cbKoltuk.Checked && koltuklar.Text == "")
            {
                MessageBox.Show("Lütfen bilette görünmesini istediğiniz koltuk numaralarını girin.\n\nYa da koltuk numaralarını elle gir seçeneğini kapatıp yalnızca seçili olan bilet kaydındaki koltuk numarasının bilette görünmesini sağlayabilirsiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                yazdirilacakMetin = "--------------------------------------"
                + "\n         BİLET BİLGİLERİNİZ"
                + "\n\nBilet Sahibi Bilgileri"
                + "\nT.C No : " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString()
                + "\nAd Soyad : " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + " " + dataGridView1.SelectedRows[0].Cells[2].Value.ToString()

                + "\n\nSefer Bilgileri"
                + "\nSefer Tarihi : " + dataGridView1.SelectedRows[0].Cells[3].Value.ToString()
                + "\nKalkış Saati : " + dataGridView1.SelectedRows[0].Cells[4].Value.ToString()
                + "\nKalkış Şehri : " + dataGridView1.SelectedRows[0].Cells[5].Value.ToString()
                + "\nVarış Şehri : " + dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

                if (cbKoltuk.Checked)
                {
                    if (koltuklar.Text == "")
                    {
                        MessageBox.Show("Lütfen bilette görünmesini istediğiniz koltuk numaralarını girin.\n\nYa da koltuk numaralarını elle gir seçeneğini kapatıp yalnızca seçili olan bilet kaydındaki koltuk numarasının bilette görünmesini sağlayabilirsiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        yazdirilacakMetin += "\nKoltuk No : " + koltuklar.Text;
                    }
                }
                else
                {
                    yazdirilacakMetin += "\nKoltuk No : " + dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                }

                yazdirilacakMetin +=
                "\nBilet Türü : " + dataGridView1.SelectedRows[0].Cells[8].Value.ToString()
                + "\nBilet Ücreti : " + dataGridView1.SelectedRows[0].Cells[9].Value.ToString()
                + "\n--------------------------------------";

                DialogResult onizleme = new DialogResult();
                onizleme = MessageBox.Show("Biletiniz aşağıdaki gibi görünecektir. Devam etmek istiyor musunuz?\n\n" + yazdirilacakMetin.ToString(), "ÖNİZLEME", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (onizleme == DialogResult.Yes)
                {
                    PrintDialog yazdirmaSecenekleriPenceresi = new PrintDialog();
                    DialogResult printDialog;
                    printDialog = yazdirmaSecenekleriPenceresi.ShowDialog();
                    PrintDocument belge = new PrintDocument();
                    belge.PrintPage += sayfa;

                    if (printDialog == DialogResult.OK)
                    {
                        belge.Print();
                    }
                }
            }
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                button1.Enabled = true;
            }
        }

        private void cbKoltuk_CheckedChanged(object sender, EventArgs e)
        {
            if (cbKoltuk.Checked)
            {
                koltuklar.Enabled = true;
            }
            else
            {
                koltuklar.Enabled = false;
            }
        }

        private void koltuklar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (koltuklar.Text == "" && (int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }
    }
}
