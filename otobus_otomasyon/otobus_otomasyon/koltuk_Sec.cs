using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.Data.SqlClient;
namespace otobus_otomasyon
{
    public partial class koltuk_Sec : Form
    {
        public koltuk_Sec()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=.; initial Catalog=otobus; Integrated Security=true");
        public string tarih = biletal.sefertarih;
        public string tarih_saat = biletal.sefersaat;
        string adısoyadi = biletal.ad + " " + biletal.soyad;
        string arac_adi = biletal.arac;
        int tutar;
        int bilet_fiyat = int.Parse(biletal.arac_fiyat.ToString());
        string ucret = biletal.arac_fiyat;
        ArrayList koltuklar = new ArrayList();
        ArrayList iptalKoltuk = new ArrayList();
        int sefer_id = biletal.son_sefer_id;
        void koltukYazdir()
        {
            string koltuk = "";
            for (int i = 0; i < koltuklar.Count; i++)
            {
                koltuk += koltuklar[i].ToString() + ",";
            }
            if (koltuklar.Count >= 1)
            {
                koltuk = koltuk.Remove(koltuk.Length - 1, 1);
            }
            txtKoltukNo.Text = koltuk;
        }

        /*
        string araGetir(string sql)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand(sql, baglanti);
            SqlDataReader oku = cmd.ExecuteReader();
            oku.Read();
            string deger = oku[0].ToString();
            baglanti.Close();
            return deger;
        }
        */

        void LogAl()
        {
            baglanti.Open();
            //string sql = "SELECT * FROM satis WHERE arac_id=" + arac_id + " AND sefer_id=" + sefer_id + " AND sefer_tarihi=" + tarih + "AND sefer_saati='"+ tarih_saat +"'";
            SqlCommand cmd = new SqlCommand("select * from satis where sefer_id='" + sefer_id + "'and sefer_tarihi='" + tarih + "'and sefer_saati='" + tarih_saat + "'", baglanti);
            SqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                string koltuk_No = oku[5].ToString();
                this.Controls.Find("btn" + koltuk_No, true)[0].BackColor = Color.Red;
                this.Controls.Find("btn" + koltuk_No, true)[0].Enabled = false;
            }
            baglanti.Close();
        }
        void biletAyir()
        {
            try
            {
                baglanti.Open();

                for (int i = 0; i < koltuklar.Count; i++)
                {
                    // string sql = "INSERT INTO bilet_tablosu (tc,ad,soyad,k_adi,yas,telefon,cinsiyet,nerden,nereye,saat,biletadeti,fiyat,tarih,bilet_no ) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + comboBox6.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "','" + textBox8.Text + "')";

                    // string sql = "INSERT INTO satis(arac_id,sefer_id,sefer_tarihi,sefer_saati,koltuk_No,ucret,satis_Adi,satis_Soyadi) VALUES (" + arac_id + "," + sefer_id + ",'" +tarih + "','" + tarih_saat + "','" + Convert.ToInt32(koltuklar[i]).ToString() + "','" + ucret + "'," + biletal.ad + ",'" + biletal.soyad + "')";
                    SqlCommand cmd = new SqlCommand("INSERT INTO satis(sefer_id,sefer_tarihi,sefer_saati,koltuk_No,ucret,satis_Adi,satis_Soyadi,tc,yas,telefon,cinsiyet ) VALUES('" + sefer_id + "','" + tarih + "','" + tarih_saat + "','" + Convert.ToInt32(koltuklar[i]).ToString() + "','" + ucret + "','" + biletal.ad + "','" + biletal.soyad + "','" + biletal.tc + "','" + biletal.yas + "','" + biletal.telefon + "','" + biletal.cinsiyet + "')", baglanti);
                    cmd.ExecuteNonQuery();
                    this.Controls.Find("btn" + koltuklar[i].ToString(), true)[0].BackColor = Color.Red;
                }
                baglanti.Close();
            }
            catch (Exception hata)
            {
                baglanti.Close();
                MessageBox.Show("Bilet ayırma işlemi sırasında beklenmeyen bir hata meydana geldi! Lütfen işlemi baştan başlatın.\n\nHata Kodu :\n" + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            saat_lbl.Text = DateTime.Now.ToLongTimeString();
            tarih_lbl.Text = DateTime.Now.ToShortDateString();
        }

        private void btnBiletAyir_Click(object sender, EventArgs e)
        {
            if (txtKoltukNo.Text != "")
            {
                biletAyir();
                MessageBox.Show(biletal.ad + " " + biletal.soyad + " bilgili kişinin " + txtKoltukNo.Text + " no'lu koltukları ayrılmıştır");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Koltuk numarasını seçmediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnKoltuk_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.Chartreuse) // yeşil
            {
                ((Button)sender).BackColor = Color.Orange;
                if (!koltuklar.Contains(((Button)sender).Text))
                {
                    koltuklar.Add(((Button)sender).Text);
                }
                tutar = tutar + bilet_fiyat;
                label3.Text = tutar.ToString() + " TL";
                koltukYazdir();
            }
            else if (((Button)sender).BackColor == Color.Orange) // turuncu
            {
                ((Button)sender).BackColor = Color.Chartreuse;
                if (koltuklar.Contains(((Button)sender).Text))
                {
                    koltuklar.Remove(((Button)sender).Text);
                    tutar = tutar - bilet_fiyat;
                    label3.Text = tutar.ToString() + " TL";
                }
            }
            else // kırmızı
            {
                if (!iptalKoltuk.Contains(((Button)sender).Text))
                {
                    iptalKoltuk.Add(((Button)sender).Text);
                }
                else
                {
                    iptalKoltuk.Remove(((Button)sender).Text);
                    tutar = tutar - bilet_fiyat;
                    label3.Text = tutar.ToString() + " TL";
                }

                string koltuk = "";
                for (int i = 0; i < iptalKoltuk.Count; i++)
                {
                    koltuk += iptalKoltuk[i].ToString() + ",";
                }
                if (iptalKoltuk.Count >= 1)
                {
                    koltuk = koltuk.Remove(koltuk.Length - 1, 1);
                }
            }
        }
        
        DataSet dset = new DataSet();
        public void doldur()
        {
            DataGridView dataGridView1 = new DataGridView();
            baglanti.Open();
            dset.Clear();

            SqlDataAdapter adtr2 = new SqlDataAdapter("select koltuk_No From  satis ORDER BY id DESC", baglanti);

            adtr2.Fill(dset, "kullanici");
            dataGridView1.DataSource = dset.Tables["kullanici"];

            adtr2.Dispose();
            baglanti.Close();
        }
        private void koltuk_Sec_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            // İPTAL sefer_id = Convert.ToInt32(araGetir("SELECT * FROM arac WHERE arac_adi='" + arac_adi + "'"));
            sefer_id = biletal.son_sefer_id;

            LogAl();
            adısoyadi = biletal.ad;
        }

        private void koltuk_Sec_Load_1(object sender, EventArgs e)
        {
            timer1.Start();
            doldur();
            tarih_lbl.Text = DateTime.Now.ToLongDateString();
            saat_lbl.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            tarih_lbl.Text = DateTime.Now.ToLongDateString();
            saat_lbl.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
