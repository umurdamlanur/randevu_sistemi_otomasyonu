using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace randevu_sistemi_5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        SqlDataReader dr;

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-4VOD4RV\SQLEXPRESS01;Initial Catalog=randevu_sistemi;Integrated Security = True");
        private object saat;


        private void btnekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            // Veritabanında aynı kaydın olup olmadığını kontrol etmek için sorgu
            SqlCommand kontrolKomutu = new SqlCommand("SELECT COUNT(*) FROM randevu WHERE ad=@p1 AND soyad=@p2 AND numara=@p3 AND tarih=@p4 AND saat=@p5 AND bolum=@p6", baglanti);
            kontrolKomutu.Parameters.AddWithValue("@p1", txtad.Text);
            kontrolKomutu.Parameters.AddWithValue("@p2", txtsoyad.Text);
            kontrolKomutu.Parameters.AddWithValue("@p3", txttelefon.Text);
            kontrolKomutu.Parameters.AddWithValue("@p4", DateTime.Parse(dttarih.Text));
            kontrolKomutu.Parameters.AddWithValue("@p5", TimeSpan.Parse(combosaat.Text));
            kontrolKomutu.Parameters.AddWithValue("@p6", combobolum.Text);
            int count = (int)kontrolKomutu.ExecuteScalar();

            if (count > 0)
            {
                // Değer mevcut
                MessageBox.Show("Bu randevunun tarih ve saati dolu. Lütfen başka bir tarih ve saat seçiniz.");
            }
            else
            {
                // Değer mevcut değil, kaydı ekle
                SqlCommand komut = new SqlCommand("INSERT INTO randevu (ad, soyad, numara, tarih, saat, bolum) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)", baglanti);
                komut.Parameters.AddWithValue("@p1", txtad.Text);
                komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
                komut.Parameters.AddWithValue("@p3", txttelefon.Text);
                komut.Parameters.AddWithValue("@p4", DateTime.Parse(dttarih.Text));
                komut.Parameters.AddWithValue("@p5", TimeSpan.Parse(combosaat.Text));
                komut.Parameters.AddWithValue("@p6", combobolum.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Randevu başarıyla eklendi.");
            }


            baglanti.Close();


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'randevu_sistemiDataSet1.randevu' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.randevuTableAdapter1.Fill(this.randevu_sistemiDataSet1.randevu);
            // TODO: Bu kod satırı 'randevu_sistemiDataSet.randevu' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.randevuTableAdapter.Fill(this.randevu_sistemiDataSet.randevu);

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update randevu set ad = @p1, tarih = @p2, saat = @p3, bolum = @p4", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", DateTime.Parse(dttarih.Text));
            komut.Parameters.AddWithValue("@p3", TimeSpan.Parse(combosaat.Text));
            komut.Parameters.AddWithValue("@p4", combobolum.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("randevu kaydınız güncellendi.");
            MessageBox.Show("sağlıklı günler dileriz.");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from randevu where ad=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("randevu kaydınız silindi.");
        }

        private void combosaat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combosaat.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir öğe seçin.");
            }
            else
            {
                string selectedValue = combosaat.SelectedItem.ToString();
                // seçilen değerle ilgili işlemler yapılabilir
            }


            if (combosaat.SelectedItem.ToString().EndsWith("(Dolu)"))
            {
                MessageBox.Show("seçilen tarih ve saat dolu olduğu için seçemezsiniz.", "hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                combosaat.SelectedIndex = -1;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
