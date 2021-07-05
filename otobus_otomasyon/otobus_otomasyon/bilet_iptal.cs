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
    public partial class bilet_iptal : Form
    {
        public bilet_iptal()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.; initial Catalog=otobus; Integrated Security=true");
        DataSet dset = new DataSet();

        public void doldur()
        {
            baglanti.Open();
            dset.Clear();

            SqlDataAdapter adtr2 = new SqlDataAdapter("SELECT id, arac_id, sefer_id AS [Sefer No], sefer_tarihi AS [Sefer Tarihi], sefer_saati AS [Kalkış Saati], tc AS [T.C No], satis_Adi AS [Müşteri Adı], satis_Soyadi AS [Müşteri Soyadı], koltuk_No AS [Koltuk No], ucret AS [Bilet Ücreti], telefon as Telefon, yas AS Yaş, cinsiyet AS Cinsiyet FROM satis ORDER BY id DESC", baglanti);

            adtr2.Fill(dset, "kullanici");
            dataGridView1.DataSource = dset.Tables["kullanici"];
            adtr2.Dispose();
            dataGridView1.RowHeadersVisible = false; //En Baştaki Boş Kolonun Gizlenmesini sağlar 
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            //bazı gereksiz kısımları görünmez yaptık görüntü güzelleştirmek açısından "id şifre gibi."

            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.ToString() != null)
            {
                try
                {
                    baglanti.Open();

                    SqlCommand komut = new SqlCommand("delete from satis where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Silme İşleme Başarıyla Tamamlandı");
                    baglanti.Close();
                    doldur();
                    button1.Enabled = false;
                }
                catch (Exception hata)
                {
                    baglanti.Close();
                    MessageBox.Show("Beklenmeyen bir hata meydana geldi!\n\nHata :\n" + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
          
        }

        private void bilet_iptal_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            doldur();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                button1.Enabled = true;
            }
        }
    }
}
