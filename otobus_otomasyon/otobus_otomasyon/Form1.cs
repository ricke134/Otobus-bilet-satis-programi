using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;//sql kütüphanemizi ekledik
namespace otobus_otomasyon
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.; initial Catalog=otobus; Integrated Security=true");
        
       

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlCommand komut = new SqlCommand("SELECT * FROM admin WHERE k_adi=\'" + KullaniciAdiTx.Text + "\'AND sifre=\'" + KullaniciSifreTx.Text + "\';", baglanti);

                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();

                if (okuyucu.HasRows)
                {
                    okuyucu.Read();

                    string kullaniciAdi = okuyucu.GetString(1);
                    
                    baglanti.Close();
                    MessageBox.Show("Admin olarak giriş yapılyor", "Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KullaniciAdiTx.Clear();
                    KullaniciSifreTx.Clear();
                    admin_panel frm = new admin_panel();
                    this.Hide();
                    frm.ShowDialog();
                }
                else
                {
                    baglanti.Close();
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    KullaniciAdiTx.Focus();
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata meydana geldi\n" + hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
