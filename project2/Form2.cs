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
using System.Text.RegularExpressions;
using System.IO;
using System.Data.Common;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace project2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ALFA-BILGISAYAR;Initial Catalog=Personel_otomasyonu;Integrated Security=True;MultipleActiveResultSets=true");
        //MultipleActiveResultSets=true (Açılmış olan tek bir bağlantı üzerinden birden fazla komut göndermeye izin verir. 'Multiple' çoklu komut anlamındadır. )
        private void kullanicilar_goster()
        {
            try
            {
                baglanti.Open();
                SqlDataAdapter kullanicilari_listele = new SqlDataAdapter("Select* from Kullanicilar ", baglanti);
                DataSet dshafiza = new DataSet();
                kullanicilari_listele.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglanti.Close();
            }
            catch (Exception hatamj)
            {
                MessageBox.Show(hatamj.Message, "SKY Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();

            }
        }

        private void Personelleri_goster()
        {
            try
            {
                baglanti.Open();
                SqlDataAdapter Personelleri_listele = new SqlDataAdapter("Select* from Personeller ", baglanti);
                DataSet dshafiza = new DataSet();
                Personelleri_listele.Fill(dshafiza);
                dataGridView2.DataSource = dshafiza.Tables[0];
                baglanti.Close();
            }
            catch (Exception hatamj)
            {
                MessageBox.Show(hatamj.Message, "SKY Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();

            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //form2  ayarları
            pictureBox1.Height = 150;
            pictureBox1.Width = 150;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "//Kullanicilarresim\\" + Form1.tcno + ".jpg");
            }
            catch
            {

                pictureBox1.Image = Image.FromFile(Application.StartupPath + "//Kullanicilarresim\\resimyook.jpg");
            }
            //kullanıcı işlemleri
            this.Text = "Yönetici İşlemleri";
            label12.ForeColor = Color.DarkRed;
            label12.Text = Form1.adi + "" + Form1.soyadi;
            textBox1.MaxLength = 11;
            textBox4.MaxLength = 8;
            toolTip1.SetToolTip(this.textBox1, "Tc Kimlik No 11 karakter olmalı!");
            radioButton1.Checked = true;
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox3.CharacterCasing = CharacterCasing.Upper;
            textBox5.MaxLength = 10;
            textBox6.MaxLength = 10;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            kullanicilar_goster();

            //personel işlemleri
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Width = 100; pictureBox2.Height = 100;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            maskedTextBox1.Mask = "00000000000";
            maskedTextBox2.Mask = "LL????????????????????";
            maskedTextBox2.Mask = "LL????????????????????";
            maskedTextBox3.Mask = "LL????????????????????";
            maskedTextBox4.Mask = "0000";
            maskedTextBox2.Text.ToUpper();
            maskedTextBox3.Text.ToUpper();


            comboBox1.Items.Add("ilköğretim"); comboBox1.Items.Add("Ortaöğretim");
            comboBox1.Items.Add("Lise"); comboBox1.Items.Add("Üniversite");

            comboBox2.Items.Add("Yönetici"); comboBox2.Items.Add("Memur"); comboBox2.Items.Add("Söfür"); comboBox2.Items.Add("Isci");
            comboBox2.Items.Add("Bilgi İslem");
            comboBox2.Items.Add("Muasebe");
            comboBox2.Items.Add("Üretim");
            comboBox2.Items.Add("Paketleme");
            comboBox2.Items.Add("Nakliye");
            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));
            dateTimePicker1.MinDate = new DateTime(1960, 1, 1);
            dateTimePicker1.MaxDate = new DateTime(yil - 18, ay, gun);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            radioButton3.Checked = true;
            Personelleri_goster();

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 11)

                errorProvider1.SetError(textBox1, "tc kimlik no 11 karekter olmalı");
            else
                errorProvider1.Clear();


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length != 8)
                errorProvider1.SetError(textBox4, "kullanıcı adı 8 karekter olmalı");
            else
                errorProvider1.Clear();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsDigit(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }
        int parola_skoru = 0;
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string parola_seviyesi = "";
            int kucuk_harf_skoru = 0, buyuk_harf_skoru = 0, rakam_skoru = 0, sembol_skoru = 0;
            string sifre = textBox5.Text;
            string duzeltilmis_sifre = "";
            duzeltilmis_sifre = sifre;
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('İ', 'I');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ı', 'i');

            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ç', 'C');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ç', 'c');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ş', 'S');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ş', 's');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ğ', 'G');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ğ', 'g');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ü', 'U');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ü', 'u');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ö', 'O');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ö', 'o');
            if (sifre != duzeltilmis_sifre)
            {
                sifre = duzeltilmis_sifre;
                textBox5.Text = sifre;
                MessageBox.Show("Paroladaki Türkce karakterler İngilizce karekterlere dönüştürülmüştür!");

            }
            int az_karekter_sayisi = sifre.Length - Regex.Replace(sifre, "[a-z]", "").Length;
            kucuk_harf_skoru = Math.Min(2, az_karekter_sayisi) * 10;


            int AZ_karekter_sayisi = sifre.Length - Regex.Replace(sifre, "[A-Z]", "").Length;
            buyuk_harf_skoru = Math.Min(2, AZ_karekter_sayisi) * 10;



            int rakam_sayisi = sifre.Length - Regex.Replace(sifre, "[0-9]", "").Length;
            rakam_skoru = Math.Min(2, rakam_sayisi) * 10;




            int sembol_sayisi = sifre.Length - az_karekter_sayisi - AZ_karekter_sayisi - rakam_sayisi;
            sembol_skoru = Math.Min(2, sembol_sayisi) * 10;

            parola_skoru = kucuk_harf_skoru + buyuk_harf_skoru + rakam_skoru + sembol_skoru;
            if (sifre.Length == 9)
                parola_skoru += 10;
            else if (sifre.Length == 10)
                parola_skoru += 20;
            if (kucuk_harf_skoru == 0 || buyuk_harf_skoru == 0 || rakam_skoru == 0 || sembol_skoru == 0)
                label10.Text = "Büyük harf,Küçük harf,Rakam ve sembol mutlaka kuullanmalısın!";
            if (kucuk_harf_skoru != 0 && buyuk_harf_skoru != 0 && rakam_skoru != 0 && sembol_skoru != 0)
                label10.Text = "";
            if (parola_skoru < 70)
                parola_seviyesi = "Kabul edilemez";
            else if (parola_skoru == 70 || parola_skoru == 80)
                parola_seviyesi = "Güclü";
            else if (parola_skoru == 90 || parola_skoru == 100)
                parola_seviyesi = " Çok Güclü";
            lblskor.Text = "%" + Convert.ToString(parola_skoru);
            lblseviye.Text = parola_seviyesi;
            progressBar1.Value = parola_skoru;

        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != textBox5.Text)
                errorProvider1.SetError(textBox6, "Parola tekrarı eşleşmiyor");
            else
                errorProvider1.Clear();

        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void topPage1_temizle()
        {
            textBox1.Clear(
                ); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
        }
        private void topPage2_temizle()
        {
            pictureBox2.Image = null; maskedTextBox1.Clear(); maskedTextBox2.Clear(); maskedTextBox3.Clear(); maskedTextBox4.Clear(); comboBox1.SelectedIndex = -1; comboBox2.SelectedIndex = -1; comboBox3.SelectedIndex = -1;
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            string yetki = "";
            bool kayitkontrol = false;
            baglanti.Open();
            SqlCommand selectsorgu = new SqlCommand("select * from Kullanicilar where tcno='" + textBox1.Text + "' ", baglanti);
            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();
            while (kayitokuma.Read())
            {
                kayitkontrol = true;
                break;
            }
            baglanti.Close();
            if (kayitkontrol == false)
            {
                if (textBox1.Text.Length < 11 || textBox1.Text == "")
                    lbltckimlikno.ForeColor = Color.Red;
                else
                    lbltckimlikno.ForeColor = Color.Black;

                if (textBox2.Text.Length < 2 || textBox2.Text == "")
                    lbladi.ForeColor = Color.Red;
                else
                    lbladi.ForeColor = Color.Black;



                if (textBox3.Text.Length < 2 || textBox3.Text == "")
                    lblsoyadi.ForeColor = Color.Red;
                else
                    lblsoyadi.ForeColor = Color.Black;



                if (textBox4.Text.Length < 8 || textBox4.Text == "")
                    lblkullaniciadi.ForeColor = Color.Red;
                else
                    lblkullaniciadi.ForeColor = Color.Black;


                if (textBox5.Text == "" || parola_skoru < 70)
                    lblparola.ForeColor = Color.Red;
                else
                    lblparola.ForeColor = Color.Black;




                if (textBox6.Text == "" || textBox5.Text != textBox6.Text)
                    lblparolatekrar.ForeColor = Color.Red;
                else
                    lblparolatekrar.ForeColor = Color.Black;

                if (textBox1.Text.Length == 11 && textBox1.Text != "" && textBox2.Text != "" && textBox2.Text.Length > 1 && textBox3.Text != "" && textBox3.Text.Length > 1 && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox5.Text == textBox6.Text && parola_skoru >= 70)
                {
                    if (radioButton1.Checked == true)
                        yetki = "yönetici";
                    else if (radioButton2.Checked == true)
                        yetki = "kullanici";

                    //"','" + textBox6.Text +  (Hata ! Parola doğrulama alanı fazla.)

                    try
                    {
                        baglanti.Open();
                        SqlCommand eklekomutu = new SqlCommand("insert into Kullanicilar values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + yetki + "','" + textBox4.Text + "','" + textBox5.Text + "')", baglanti);
                        eklekomutu.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Yeni Kullanıcı kaydı oluşturuldu", "SKY Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        topPage1_temizle();
                    }
                    catch (Exception hatamsj)
                    {

                        MessageBox.Show(hatamsj.Message);
                        baglanti.Close();
                    }

                }
                else
                {
                    MessageBox.Show("yazı rengi kırmızı olan alanları yeniden gözden gecirin!", "SKY Pesrsonel Takip Programı ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }







            }
            else
            {
                MessageBox.Show("Girilen TC kimlik numarası daha önce kayıtlıdır", "SKYPesrsonel Takip Programı ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;
            if (textBox1.Text.Length == 11)
            {
                baglanti.Open();
                SqlCommand selectsorgu = new SqlCommand("select * from Kullanicilar where tcno='" + textBox1.Text + "'", baglanti);
                SqlDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    textBox2.Text = kayitokuma.GetValue(1).ToString();
                    textBox3.Text = kayitokuma.GetValue(2).ToString();
                    if (kayitokuma.GetValue(3).ToString() == "yönetici")
                        radioButton1.Checked = true;
                    else
                        radioButton2.Checked = true;
                    textBox4.Text = kayitokuma.GetValue(4).ToString();
                    textBox5.Text = kayitokuma.GetValue(5).ToString();
                    textBox6.Text = kayitokuma.GetValue(5).ToString();
                    break;


                }
                if (kayit_arama_durumu == false)

                    MessageBox.Show("aranan kayıt bullunamadı", "sky personel takip programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                baglanti.Close();
            }
            else
            {

                MessageBox.Show("lütfen 11 haneli bir tc kimlik no giriniz!", "sky personel takip programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }



        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            string yetki = "";

            if (textBox1.Text.Length < 11 || textBox1.Text == "")
                lbltckimlikno.ForeColor = Color.Red;
            else
                lbltckimlikno.ForeColor = Color.Black;

            if (textBox2.Text.Length < 2 || textBox2.Text == "")
                lbladi.ForeColor = Color.Red;
            else
                lbladi.ForeColor = Color.Black;



            if (textBox3.Text.Length < 2 || textBox3.Text == "")
                lblsoyadi.ForeColor = Color.Red;
            else
                lblsoyadi.ForeColor = Color.Black;



            if (textBox4.Text.Length < 8 || textBox4.Text == "")
                lblkullaniciadi.ForeColor = Color.Red;
            else
                lblkullaniciadi.ForeColor = Color.Black;


            if (textBox5.Text == "" || parola_skoru < 70)
                lblparola.ForeColor = Color.Red;
            else
                lblparola.ForeColor = Color.Black;




            if (textBox6.Text == "" || textBox5.Text != textBox6.Text)
                lblparolatekrar.ForeColor = Color.Red;
            else
                lblparolatekrar.ForeColor = Color.Black;

            if (textBox1.Text.Length == 11 && textBox1.Text != "" && textBox2.Text != "" && textBox2.Text.Length > 1 && textBox3.Text != "" && textBox3.Text.Length > 1 && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox5.Text == textBox6.Text && parola_skoru >= 70)
            {
                if (radioButton1.Checked == true)
                    yetki = "yönetici";
                else if (radioButton2.Checked == true)
                    yetki = "kullanici";

                try
                {
                    baglanti.Open();
                    SqlCommand guncellekomutu = new SqlCommand("update Kullanicilar set ad='" + textBox2.Text + "',soyad='" + textBox3.Text + "', yetki='" + yetki + "',kullaniciadi='" + textBox4.Text + "',parola='" + textBox5.Text + "' where tcno='" + textBox1.Text + "'", baglanti);
                    guncellekomutu.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kullanıcı bilgileri güncelledi!", "SKY Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kullanicilar_goster();
                }
                catch (Exception hatamsj)
                {

                    MessageBox.Show(hatamsj.Message, "SKY Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    baglanti.Close();
                }

            }
            else
            {
                MessageBox.Show("yazı rengi kırmızı olan alanları yeniden gözden gecirin!", "SKY Pesrsonel Takip Programı ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 11)
            {
                bool kayit_arama_durumu = false;
                baglanti.Open();
                SqlCommand selectsorgu = new SqlCommand("select * from Kullanicilar where tcno='" + textBox1.Text + "' ", baglanti);

                SqlDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    baglanti.Close();
                    break;
                }
                if (kayit_arama_durumu == true)
                {
                    baglanti.Open();
                    SqlCommand deletesorgu = new SqlCommand("delete from Kullanicilar where tcno='" + textBox1.Text + "'", baglanti);
                    deletesorgu.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı kaydı silindi!", "SKY Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    baglanti.Close();
                    kullanicilar_goster();
                    topPage1_temizle();
                    baglanti.Close();


                }
                else
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı!", "SKY Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }




            }
            else
                MessageBox.Show("lütfen 11 karekterden olusan bir tc kımlık no gırınız!", "SKY Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnformtemizle_Click(object sender, EventArgs e)
        {
            topPage1_temizle();
        }



        private void btngozat_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog resimsec = new OpenFileDialog();
            resimsec.Title = "Personel resmi seciniz";
            resimsec.Filter = "Jpg Dosyalar(*.jpg)| *.jpg";
            if (resimsec.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox2.Image = new Bitmap(resimsec.OpenFile());
            }
        }

        private void btnkaydet2_Click(object sender, EventArgs e)
        {
            string cinsiyet = "";
            bool kayitkontrol = false;
            baglanti.Open();
            SqlCommand selectsorgu = new SqlCommand("select * from  Personeller where tcno='" + maskedTextBox1.Text + "'", baglanti);
            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();
            while (kayitokuma.Read())
            {
                kayitkontrol = true;
                break;
            }
            baglanti.Close();
            if (kayitkontrol == false)
            {
                if (pictureBox2.Image == null)
                    btngozat.ForeColor = Color.Red;
                else
                    btngozat.ForeColor = Color.Black;
                if (maskedTextBox1.MaskCompleted == false)

                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                if (maskedTextBox2.MaskCompleted == false)

                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;

                if (maskedTextBox3.MaskCompleted == false)

                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;
                if (comboBox1.Text == "")
                    label5.ForeColor = Color.Red;
                else
                    label5.ForeColor = Color.Black;
                if (comboBox2.Text == "")
                    label7.ForeColor = Color.Red;
                else
                    label7.ForeColor = Color.Black;
                if (comboBox3.Text == "")
                    label8.ForeColor = Color.Red;
                else
                    label8.ForeColor = Color.Black;
                if (maskedTextBox4.MaskCompleted == false)

                    label9.ForeColor = Color.Red;
                else
                    label9.ForeColor = Color.Black;
                if (pictureBox2.Image != null && maskedTextBox1.MaskCompleted != false && maskedTextBox2.MaskCompleted != false && maskedTextBox3.MaskCompleted != false && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && maskedTextBox4.MaskCompleted != false)
                {
                    if (radioButton4.Checked == true)
                        cinsiyet = "bay";
                    else if (radioButton5.Checked == true)
                        cinsiyet = "bayan";
                    try
                    {
                        baglanti.Open();
                        SqlCommand eklekomutu = new SqlCommand("insert into personeller values('" + maskedTextBox1.Text + "','" + maskedTextBox2.Text + "','" + maskedTextBox3.Text + "','" + cinsiyet + "','" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox1.Text + "''" + comboBox1.Text + "''" + maskedTextBox4.Text + "')", baglanti);
                        eklekomutu.ExecuteNonQuery();
                        baglanti.Close();

                        if (!Directory.Exists(Application.StartupPath + "\\Personellerresimler\\"))
                            Directory.CreateDirectory(Application.StartupPath + "\\Personellerresimler");
                        //

                        pictureBox2.Image.Save(Application.StartupPath+ "\\Personellerresimler\\" + maskedTextBox1.Text + ".jpg");
                        MessageBox.Show("Yeni personel kaydı olusturuldu", "Sky personel takip programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Personelleri_goster();
                        topPage1_temizle();

                    }
                    catch (Exception hatamsj)
                    {
                        MessageBox.Show(hatamsj.Message, "Sky personel takip programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglanti.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Yazı alanları kırmızı olan alanları yeniden gözden geciriniz", "SKY Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("girilen tc no daha once kayıtlıdır", "SKY Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void btnara2_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;
            if (maskedTextBox1.Text.Length==11)
            {
                baglanti.Open();
                SqlCommand selectsorgu = new SqlCommand("select * from personeller where tcno='" + maskedTextBox1.Text + "'", baglanti);
                SqlDataReader kayitokuma = selectsorgu.ExecuteReader();
                while(kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                   try
                   {
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\Personellerresimler\\" + kayitokuma.GetValue(0).ToString() + ".jpg");
                   }
                   catch 
                    {
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\Personellerresim\\resimyok.jpg");

                    }
                    maskedTextBox2.Text = kayitokuma.GetValue(1).ToString();
                    maskedTextBox3.Text = kayitokuma.GetValue(2).ToString();
                    if (kayitokuma.GetValue(3).ToString() == "bay")
                        radioButton4.Checked = true;
                    else
                        radioButton5.Checked = true;
                    comboBox1.Text = kayitokuma.GetValue(4).ToString();
                    dateTimePicker1.Text = kayitokuma.GetValue(5).ToString();
                    comboBox2.Text = kayitokuma.GetValue(6).ToString();
                    comboBox3.Text = kayitokuma.GetValue(7).ToString();
                    maskedTextBox4.Text = kayitokuma.GetValue(8).ToString();
                    break;


                }
                if (kayit_arama_durumu == false)
                    MessageBox.Show("aranan kayıt bulunamadı", "sky personel takip programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("11 haneli tc no giriniz", "sky personel takip programı", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btngüncelle2_Click(object sender, EventArgs e)
        {
            string cinsiyet = "";
            
                if (pictureBox2.Image == null)
                    btngozat.ForeColor = Color.Red;
                else
                    btngozat.ForeColor = Color.Black;
                if (maskedTextBox1.MaskCompleted == false)

                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                if (maskedTextBox2.MaskCompleted == false)

                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;

                if (maskedTextBox3.MaskCompleted == false)

                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;
                if (comboBox1.Text == "")
                    label5.ForeColor = Color.Red;
                else
                    label5.ForeColor = Color.Black;
                if (comboBox2.Text == "")
                    label7.ForeColor = Color.Red;
                else
                    label7.ForeColor = Color.Black;
                if (comboBox3.Text == "")
                    label8.ForeColor = Color.Red;
                else
                    label8.ForeColor = Color.Black;
                if (maskedTextBox4.MaskCompleted == false)

                    label9.ForeColor = Color.Red;
                else
                    label9.ForeColor = Color.Black;
                if (pictureBox2.Image != null && maskedTextBox1.MaskCompleted != false && maskedTextBox2.MaskCompleted != false && maskedTextBox3.MaskCompleted != false && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && maskedTextBox4.MaskCompleted != false)
                {
                    if (radioButton4.Checked == true)
                        cinsiyet = "bay";
                    else if (radioButton5.Checked == true)
                        cinsiyet = "bayan";
                    try
                    {
                    baglanti.Open();
                    SqlCommand guncellekomutu = new SqlCommand("update  personeller set Ad='" + maskedTextBox2.Text + "',Soyad='" + maskedTextBox3.Text + "',Cinsiyet='" + cinsiyet + "',Mezuniyet='" + comboBox1.Text + "',Dogum_tarihi='" + dateTimePicker1.Text + "',Görevi='" + comboBox2.Text + "',Görev_yeri='" + comboBox3.Text + "',Maasi='" + maskedTextBox4.Text + "' where  tcno='" + maskedTextBox1.Text + "'", baglanti);
                    guncellekomutu.ExecuteNonQuery();
                    baglanti.Close();
                    Personelleri_goster();
                    topPage2_temizle();
                    maskedTextBox4.Text = "0";

                   
                    }
                    catch (Exception hatamsj)
                    {
                        MessageBox.Show(hatamsj.Message, "Sky personel takip programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglanti.Close();
                    }

                }
               
            }
            
        
                
        

        private void btnsil2_Click(object sender, EventArgs e)
        {
            if(maskedTextBox1.MaskCompleted==true)
            {
                bool kayit_arama_durumu = false;
                baglanti.Open();
                SqlCommand arama_sorgusu = new SqlCommand("select *from personeller where tcno='" + maskedTextBox1.Text + "'", baglanti);
                SqlDataReader kayitokuma = arama_sorgusu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;

                    SqlCommand deletesorgu = new SqlCommand("delete from personeller where tcno='" + maskedTextBox1.Text + "'", baglanti);
                    deletesorgu.ExecuteNonQuery();
                    break;
                }
                if (kayit_arama_durumu==false)
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı!", "SKY personel takip programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                baglanti.Close();
                Personelleri_goster();
                topPage2_temizle();
                maskedTextBox4.Text = "0";
            }
            else
            {
                MessageBox.Show("lütfen 11 karaterde oluşan bir tc kimlik no giriniz!", "SKY personel takip programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                topPage2_temizle();
                maskedTextBox4.Text = "0";
            }
        }

        private void btntemizle2_Click(object sender, EventArgs e)
        {
            topPage2_temizle();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    





