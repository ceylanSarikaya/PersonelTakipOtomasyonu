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
using System.Data.Sql;

namespace project2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ALFA-BILGISAYAR;Initial Catalog=Personel_otomasyonu;Integrated Security=True;MultipleActiveResultSets=true");
        private void personelleri_göster()
        {
            try
            {
                baglanti.Open();
                SqlDataAdapter personellleri_listele = new SqlDataAdapter("select tcno AS[Tc kimlik no],ad AS[Adi],soyad AS[Soyad],cinsiyet as[Cinsiyeti],mezuniyet as[Mezuniyeti],dogum_tarihi as[DOGUMTARİHİ],görevi as[Görevi],görev_yeri as[Görevyeri],maasi as[Maasi] from personeller Order By ad ASC", baglanti);
                DataSet dshafiza = new DataSet();
                personellleri_listele.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglanti.Close();

            }
            catch (Exception hatamsj)
            {

                MessageBox.Show(hatamsj.Message, "SKY personel takip programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            personelleri_göster();
            this.Text = " Kullanici islemleri";
            label19.Text = Form1.adi + "" + Form1.soyadi;
            pictureBox1.Height = 150;pictureBox1.Width = 150;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.Height = 150; pictureBox1.Width = 150;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            try
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\Kullanicilarresim\\" + Form1.tcno + ".jpg");
            }
            catch 
            {

                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\Kullanicilarresim\\ resimyook.jpg");
            }
            maskedTextBox1.Mask = "00000000000";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;
            if (maskedTextBox1.Text.Length==11)
            {
                baglanti.Open();
                SqlCommand selectsorgu = new SqlCommand("select * from personeller where tcno='" + maskedTextBox1.Text + "'", baglanti);
                SqlDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    try
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Personellerresimler\\ " + kayitokuma.GetValue(0) + ".jpg");
                    }
                    catch
                    {
                        //  pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\Personellerresimler\\ resimyook.jpg");

                    }
                    label10.Text = kayitokuma.GetValue(1).ToString();
                    label11.Text = kayitokuma.GetValue(2).ToString();
                    if (kayitokuma.GetValue(3).ToString() == "bay")
                        label12.Text = "bay";
                    else
                        label12.Text = "bayan";
                    label13.Text = kayitokuma.GetValue(4).ToString();
                    label14.Text = kayitokuma.GetValue(5).ToString();
                    label15.Text = kayitokuma.GetValue(6).ToString();
                    label16.Text = kayitokuma.GetValue(7).ToString();
                    label17.Text = kayitokuma.GetValue(8).ToString();
                    break;

                }

                if (kayit_arama_durumu == false)
                    MessageBox.Show("Aranan kayit bulunamadı");
                baglanti.Close();
            }
            else
                MessageBox.Show("11 haneli bit tc kimlik no giriniz");


        }
    }
}
