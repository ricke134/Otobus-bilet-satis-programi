using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace otobus_otomasyon
{
    public partial class biletal : Form
    {
        public biletal()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.; initial Catalog=otobus; Integrated Security=true");
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand komut;

        public static string tc = "";
        public static string ad = "";
        public static string soyad = "";
        public static string yas = "";
        public static string telefon = "";
        public static string cinsiyet = "";
        public static string sefernereden = "";
        public static string sefernereye = "";
        public static string adı = "";
        public static string sefersaat = "";
        public static string sefertarih = "";
        public static string arac = "";
        public static string arac_fiyat = "";
        public static string seferid = "";
        public static int son_sefer_id = 0;
        public static string bilet_nom = "";

        void griddoldur()
        {
            da = new SqlDataAdapter("SELECT id, sefer_id AS [Sefer No], arac_id, sefer_tarihi AS [Sefer Tarihi], sefer_saati AS [Kalkış Saati], sefer_nereden AS [Kalkış Şehri], sefer_nereye AS [Varış Şehri], arac_adi AS [Araç Türü] FROM sefer ORDER BY sefer_tarihi ASC", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "sefer");
            dataGridView1.DataSource = ds.Tables["sefer"];
            baglanti.Close();
            dataGridView1.Columns[0].Visible = false; //KOLON GİZLEME
            dataGridView1.Columns[2].Visible = false; //KOLON GİZLEME
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 11 || textBox2.Text.Length < 3 || textBox3.Text.Length < 3 || textBox4.Text.Length < 3)
            {
                MessageBox.Show("Girdiğiniz bilgileri kontrol ediniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    tc = textBox1.Text;

                    sefersaat = comboBox5.Text;
                    ad = textBox2.Text;
                    soyad = textBox3.Text;
                    yas = textBox6.Text;

                    if (radioErkek.Checked)
                    {
                        cinsiyet = "Erkek";
                    }
                    else
                    {
                        cinsiyet = "Kadın";
                    }

                    telefon = textBox4.Text;
                    sefernereden = comboBox3.Text.ToLower();
                    sefernereye = comboBox4.Text.ToLower();
                    sefertarih = textBox5.Text;
                    arac = comboBox6.Text;
                    son_sefer_id = Convert.ToInt32(lblsefer_id.Text);

                    koltuk_Sec koltuk = new koltuk_Sec();
                    koltuk.ShowDialog();
                    this.Close();

                    /* ESKİ YÖNTEM
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("select * from sefer where sefer_saati = '" + sefersaat + "'and sefer_tarihi = '" + sefertarih + "'and sefer_nereden = '" + sefernereden + "'and sefer_nereye = '" + sefernereye + "'and arac_adi='" + arac + "'", baglanti);
                    SqlDataReader oku = komut.ExecuteReader();
                    if (oku.Read())
                    {
                        seferid = oku[1].ToString();
                        koltuk_Sec koltuk = new koltuk_Sec();
                        koltuk.Show();
                    }
                    else
                    {
                        MessageBox.Show("Böyle bir sefer bulunmamaktadır  !");
                        button3.Enabled = true;
                    }
                    baglanti.Close();
                    */
                }
                catch (Exception hata)
                {
                    baglanti.Close();
                    MessageBox.Show("İşlem sırasında bir hata meydana geldi!\n\nHata Kodu :\n" + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "" || comboBox6.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Gerekli bilgiler eksik! Lütfen tüm alanları doldurun.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string aracid = "";
                    SqlCommand komut = new SqlCommand("SELECT * FROM arac WHERE arac_adi='" + comboBox6.Text + "'", baglanti);
                    SqlDataReader oku = komut.ExecuteReader();
                    if (oku.Read())
                    {
                        aracid = oku["id"].ToString();
                    }
                    oku.Close();
                    baglanti.Close();


                    baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("SELECT MAX(sefer_id) FROM sefer", baglanti);
                    SqlDataReader oku2 = komut.ExecuteReader();
                    if (oku2.Read())
                    {
                        son_sefer_id = Convert.ToInt32(oku2[0]); // Veritabanındaki en son eklenmiş sefere aşt sefer_id çekiliyor
                    }
                    son_sefer_id++; // sefer_id bir arttırılarak eklenecek yeni sefer için sefer_id bilgisi oluşturuluyor.
                    oku2.Close();
                    baglanti.Close();


                    arac = comboBox6.Text;
                    sefersaat = comboBox5.Text;
                    sefertarih = textBox5.Text;
                    sefernereden = comboBox3.Text;
                    sefernereye = comboBox4.Text;

                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO sefer(sefer_id,arac_id,arac_adi,sefer_saati,sefer_tarihi,sefer_nereden,sefer_nereye) VALUES('" + son_sefer_id + "', '" + aracid + "','" + arac + "','" + sefersaat + "','" + sefertarih + "','" + sefernereden + "','" + sefernereye + "')", baglanti);
                    cmd.ExecuteNonQuery();
                    baglanti.Close();
                    button3.Enabled = false;
                    griddoldur();
                    MessageBox.Show("İşlem Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception hata)
                {
                    baglanti.Close();
                    MessageBox.Show("İşlem sırasında bir hata meydana geldi!\n\nHata Kodu :\n" + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void biletal_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            griddoldur();

            // textBox6.Text = Login.k_adi;
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select * from City", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox3.Items.Add(oku["name"].ToString());
                comboBox4.Items.Add(oku["name"].ToString());
            }
            baglanti.Close();
            comboBox6.Items.Clear();
            baglanti.Open();
            SqlCommand komutt = new SqlCommand("Select * from arac", baglanti);
            SqlDataReader oku2 = komutt.ExecuteReader();
            while (oku2.Read())
            {
                comboBox6.Items.Add(oku2["arac_adi"].ToString());
            }
            baglanti.Close();
            comboBox6.SelectedIndex = 0;

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox5.Text = dateTimePicker2.Value.Date.ToString("dd/MM/yyyy");
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand komutt = new SqlCommand("Select * from arac where arac_adi='" + comboBox6.Text + "'", baglanti);
                SqlDataReader oku2 = komutt.ExecuteReader();
                while (oku2.Read())
                {
                    arac_fiyat = oku2["bilet_fiyat"].ToString();
                }
                baglanti.Close();
            }
            catch (Exception hata)
            {
                baglanti.Close();
                MessageBox.Show("Bilet Fiyatı Çekilirken Beklenmedik Bir Hata Meydana Geldi!\n\nHata : \n" + hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            
        }

        string sefer ="";
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Seçilen Sefer Silinecek\n\nEmin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }

                    SqlCommand komut = new SqlCommand("select * from sefer where arac_adi = '" + comboBox6.Text + "' AND sefer_nereden = '" + comboBox3.Text + "' AND sefer_nereye = '" + comboBox4.Text + "' AND sefer_saati = '" + comboBox5.Text + "' AND sefer_tarihi = '" + textBox5.Text + "'", baglanti);

                  
                    SqlDataReader okuyucu = komut.ExecuteReader();

                    if (okuyucu.HasRows)
                    {
                        okuyucu.Read();

                       sefer = (okuyucu.GetInt32(0)).ToString();

                        okuyucu.Close();

                        SqlCommand komut2 = new SqlCommand("DELETE FROM sefer WHERE id = '" + sefer + "'", baglanti);

                        komut2.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Sefer Kaydı Silindi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (baglanti.State == ConnectionState.Open)
                        {
                            baglanti.Close();
                        }
                        griddoldur();
                    }
                    else
                    {
                        baglanti.Close();
                        MessageBox.Show("Sefer silme işlemi sırasında bir hata meydana geldi!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                catch (Exception hata)
                {
                    baglanti.Close();
                    MessageBox.Show("Beklenmeyen Bir Hata Meydana Geldi!\n\nHata : \n" + hata.ToString());
                    this.Close();
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex];
                sefer = satir.Cells[0].Value.ToString();
                comboBox3.Text = satir.Cells[5].Value.ToString();     //nereden
                comboBox4.Text = satir.Cells[6].Value.ToString();     //nereye
                comboBox5.Text = satir.Cells[4].Value.ToString();     //sefer saati
                textBox5.Text = satir.Cells[3].Value.ToString();      //sefer tarihi
                comboBox6.Text = satir.Cells[7].Value.ToString();    //araç türü
                lblsefer_id.Text = satir.Cells[1].Value.ToString();  //sefer numarası
                button2.Enabled = true;
            }
        }

        private void sadeceSayiGirisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void sadeceYaziGirisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }
    }
}
