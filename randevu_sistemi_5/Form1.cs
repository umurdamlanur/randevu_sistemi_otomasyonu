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

namespace randevu_sistemi_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-4VOD4RV\SQLEXPRESS01;Initial Catalog=guvenlikk;Integrated Security = True");
        SqlCommand komut;
        SqlDataReader dr;

        private void btngiris_Click(object sender, EventArgs e)
        {
            string ad = txtkullaniciadi.Text;
            string sifre = txtsifre.Text;
            komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "select * from parola1 where ad='" + ad + "' and sıfre='" + sifre + "'";
            dr= komut.ExecuteReader();
            if(dr.Read())
            {
                Form2 f2 = new Form2();
                f2.Show();
            }
            else
            {
                MessageBox.Show("hatalı giriş");
            }
            baglanti.Close();
        }
    }
}
