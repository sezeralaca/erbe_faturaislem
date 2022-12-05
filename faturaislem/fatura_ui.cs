using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace faturaislem
{
    public partial class fatura_ui : Form
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
        // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
        string username;
        string password;
        public class Donem
        {
            public int id { get; set; }
            public bool Select { get; set; }
            public string BinaAdi { get; set; }
            public string paylasimDonemAdi { get; set; }
            public int suBirimFiyati { get; set; }
            public int yakitBirimFiyati { get; set; }
            public int altIsilDegeri { get; set; }
            public int suSicakligi { get; set; }
            public int isitmaGideri { get; set; }
            public int sogutmaGideri { get; set; }
            public DateTime faturaTarihi { get; set; }
            public DateTime sonOdemeTarihi { get; set; }
            public int suIsitmaBrimFiyati { get; set; }
            public double isinmaBrimFiyati { get; set; }
            public double ortakKullanimBrimFiyati { get; set; }
            public double sicakSuIsıtmaBedeli { get; set; }
            public double sicakSuSebekeBedeli { get; set; }
            public double toplamIsinmaBedeli { get; set; }
            public double ortakKullanimBedeli { get; set; }
            public int toplamEnerjiTuketimi { get; set; }
            public double ortalamaEnerjiTuketimi { get; set; }
            public int toplamKapaliAlan { get; set; }
            public string enerjiBirimi { get; set; }
            public double toplamSicakSuTuketimi { get; set; }
            public DateTime ilkOkumaTarihi { get; set; }
            public DateTime sonOkumaTarihi { get; set; }
            public object suBirimi { get; set; }
            public int manuplasyonOrani { get; set; }
        }
        

        List<Donem> donem = new List<Donem>();
        // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
        public class FaturaDetay
        {
            public string sayacNo { get; set; }
            public int ilkEndeks { get; set; }
            public int sonEndeks { get; set; }
            public double tuketimTutari { get; set; }
            public string aciklama { get; set; }
            public double birimFiyat { get; set; }
            public int sayacTipi { get; set; }
        }


        public class Root
        {
            public int id { get; set; }
            public bool Select { get; set; }
            public double faturaTutari { get; set; }
            public string aboneAdi { get; set; }
            public double ortakKullanimGideri { get; set; }
            public double yakitfatura { get; set; }
            public double suIsitmaGideri { get; set; }
            public double sicakSuSebekeBedeli { get; set; }
            public int sogukSuSebekeBedeli { get; set; }
            public int hizmetBedeli { get; set; }
            public int digerGiderToplami { get; set; }
            public int manipulasyonFarki { get; set; }
            public int manipulasyonTutari { get; set; }
            public string enerjiBirimi { get; set; }
            public int daireAlani { get; set; }
            public string daireNo { get; set; }
            public int aboneNo { get; set; }
            public object blok { get; set; }
            public string suBirimi { get; set; }
            public int enerjiTuketimi { get; set; }
            public object qrCodePath { get; set; }
            public List<FaturaDetay> faturaDetay { get; set; }
            public List<object> notlar { get; set; }
        }

        List<Root> root = new List<Root>();
        
        
        public fatura_ui()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 1000);
            printPreviewDialog1.ShowDialog();
        }
        int kayit = 0;
        
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Arial Narow", 7, FontStyle.Bold);
            SolidBrush firca = new SolidBrush(Color.Black);
            Pen kalem = new Pen(Color.Black);
            e.Graphics.DrawString("ISI GİDERLERİ", font, firca, 110, 120);
            e.Graphics.DrawString("PAYLAŞIM BİLDİRİMİ ", font, firca, 95, 130);
            System.Drawing.Image img = System.Drawing.Image.FromFile("C:/Users/erbes/OneDrive/Masaüstü/ALL IN ONE/Logo/Fatura.jpg");
            Point loc = new Point(40, 30);
            e.Graphics.DrawImage(img, loc);
            /* LETS BEGİN*/
            int y = 145;/*Oynama yapılırken burada ki değerleri değiştireceksiniz.*/
            int y2 = 265;
            int x = 7;
            int x2 = 265;
            int yd = 235;/*Oynama yapılırken burada ki değerleri değiştireceksiniz.*/
            e.Graphics.DrawRectangle(kalem, x, y, x2, y2);
            for (int j = 1; j <= 6; j++)
            {
                e.Graphics.DrawLine(kalem, 85, yd, 272, yd);
                yd = yd + 30;
            }
            for (int i = 1; i <= 3; i++)
            {
                e.Graphics.DrawLine(kalem, x, y, x, y + 265);
                x = x + 79;
            }
            for (int i = 1; i <= 3; i++)/*Küçük bölgeler için (1x)*/
            {
                e.Graphics.DrawLine(kalem, 7, y, 272, y);
                y = y + 30;
            }
            for (int i = 1; i <= 3; i++)
            {
                e.Graphics.DrawLine(kalem, 7, y, 272, y);/*Büyük bölgeler için (2x)*/
                y = y + 60;
            }
            /*------------------------------------------------------------------------------------------------*/
            /*------------------------------------------------------------------------------------------------*/
            /*------------------------------------------------------------------------------------------------*/
            //.Substring(0, 6)

            Font fontyazi = new Font("Oswald", 8, FontStyle.Bold);
            int yazix = 15;
            int yaziy = 155;
            e.Graphics.DrawString("Abone No", fontyazi, firca, yazix, yaziy);
            e.Graphics.DrawString(root[kayit].aboneNo.ToString(), font, firca, yazix, yaziy+30);
            e.Graphics.DrawString("Daire", fontyazi, firca, yazix + 94, yaziy);
            e.Graphics.DrawString(root[kayit].daireNo, font, firca, yazix + 94, yaziy + 30);
            e.Graphics.DrawString("Ad / Soyad", fontyazi, firca, yazix + 176, yaziy);
            e.Graphics.DrawString(root[kayit].aboneAdi, font, firca, yazix + 176, yaziy + 30);
            e.Graphics.DrawString("Diğer Giderler", fontyazi, firca, yazix - 8, yaziy + 60);
            e.Graphics.DrawString("Lisans Bedeli", fontyazi, firca, yazix +80, yaziy + 60);
            e.Graphics.DrawString(root[kayit].digerGiderToplami.ToString(), font, firca, yazix+176, yaziy+60);
            e.Graphics.DrawString("Sıcaksu", fontyazi, firca, yazix - 8, yaziy + 95);
            e.Graphics.DrawString("Giderleri", fontyazi, firca, yazix - 8, yaziy + 110);
            e.Graphics.DrawString("Toplam Tüketim", fontyazi, firca, yazix +76, yaziy + 90);
            e.Graphics.DrawString("0"/*değişebilir.*/, font, firca, yazix + 176, yaziy + 90);
            e.Graphics.DrawString("Birim Fiyat", fontyazi, firca, yazix + 80, yaziy + 120);
            e.Graphics.DrawString(root[kayit].sicakSuSebekeBedeli.ToString(), font, firca, yazix+176, yaziy+120);
            e.Graphics.DrawString("Soğuksu", fontyazi, firca, yazix - 8, yaziy + 155);
            e.Graphics.DrawString("Giderleri", fontyazi, firca, yazix - 8, yaziy + 170);
            e.Graphics.DrawString("Toplam Tüketim", fontyazi, firca, yazix + 76, yaziy + 150);
            e.Graphics.DrawString("0"/*değişebilir.*/, font, firca, yazix + 176, yaziy + 150);
            e.Graphics.DrawString("Birim Fiyat", fontyazi, firca, yazix + 80, yaziy + 180);
            e.Graphics.DrawString(root[kayit].sogukSuSebekeBedeli.ToString(), font, firca, yazix +176, yaziy+180);
            e.Graphics.DrawString("Ortak", fontyazi, firca, yazix - 8, yaziy + 215);
            e.Graphics.DrawString("Kullanım", fontyazi, firca, yazix - 8, yaziy + 230);
            e.Graphics.DrawString("Mesken Alanı", fontyazi, firca, yazix + 80, yaziy + 210);
            e.Graphics.DrawString(root[kayit].daireAlani.ToString(), font, firca, yazix + 176, yaziy + 210);
            e.Graphics.DrawString("Birim Fiyat", fontyazi, firca, yazix + 80, yaziy + 235);
            e.Graphics.DrawString(root[kayit].ortakKullanimGideri.ToString().Substring(0, 5), font, firca, yazix+176, yaziy+235);
            /*---------------------------------------------------------------------*/
            e.Graphics.DrawString("Dönem", fontyazi, firca, yazix - 7, yaziy + 290);
            e.Graphics.DrawString(donem[0].paylasimDonemAdi.ToString(), font, firca, yazix + 60 ,yaziy + 290);
            e.Graphics.DrawString("İlk Okuma", fontyazi, firca, yazix - 7, yaziy + 320);
            e.Graphics.DrawString(donem[0].ilkOkumaTarihi.ToString("MM, dd, yyyy"), font, firca, yazix + 60, yaziy + 320);
            e.Graphics.DrawString("Fatura T.", fontyazi, firca, yazix - 7, yaziy + 350);
            e.Graphics.DrawString(donem[0].faturaTarihi.ToString("MM, dd, yyyy"), font, firca, yazix + 60, yaziy + 350);
            e.Graphics.DrawString("Kapalı Alan", fontyazi, firca, yazix - 7, yaziy + 380);
            e.Graphics.DrawString(donem[0].toplamKapaliAlan.ToString(), font, firca, yazix + 60, yaziy + 380);
            e.Graphics.DrawString("Bölge(A.T.K.)", fontyazi, firca, yazix - 7, yaziy + 410);
            e.Graphics.DrawString(donem[0].manuplasyonOrani.ToString(), font, firca, yazix + 60, yaziy + 410);
            e.Graphics.DrawString("Ort.Tüketim", fontyazi, firca, yazix - 7, yaziy + 440);
            e.Graphics.DrawString(donem[0].ortalamaEnerjiTuketimi.ToString().Substring(0, 6), font, firca, yazix + 60, yaziy + 440);
            /*---------------------------------------------------------------------*/
            e.Graphics.DrawString("Son Ödeme", fontyazi, firca, yazix + 130, yaziy + 290);
            e.Graphics.DrawString(donem[0].sonOdemeTarihi.ToString("MM, dd, yyyy"), font, firca, yazix + 195, yaziy + 290);
            e.Graphics.DrawString("Son Okuma", fontyazi, firca, yazix + 130, yaziy + 320);
            e.Graphics.DrawString(donem[0].sonOkumaTarihi.ToString("MM, dd, yyyy"), font, firca, yazix + 195, yaziy + 320);
            e.Graphics.DrawString("Yak.Fatura", fontyazi, firca, yazix + 130, yaziy + 350);
            e.Graphics.DrawString(donem[0].isitmaGideri.ToString(), font, firca, yazix + 195, yaziy + 350);
            e.Graphics.DrawString("Ort.Kullanım", fontyazi, firca, yazix + 130, yaziy + 380);
            e.Graphics.DrawString(donem[0].ortakKullanimBedeli.ToString().Substring(0, 6), font, firca, yazix + 195, yaziy + 380);
            e.Graphics.DrawString("Toplam T.", fontyazi, firca, yazix + 130, yaziy + 410);
            e.Graphics.DrawString(root[0].yakitfatura.ToString(), font, firca, yazix + 195, yaziy + 410);
            e.Graphics.DrawString("En Yüksek T.", fontyazi, firca, yazix + 130, yaziy + 440);
            e.Graphics.DrawString(donem[0].toplamEnerjiTuketimi.ToString(), font, firca, yazix + 195, yaziy + 440);
            
            /*---------------------------------------------------------------------*/

            /*------------------------------------------------------------------------------------------------*/
            /*------------------------------------------------------------------------------------------------*/
            x = 7;
            x2 = 265;
            e.Graphics.DrawString("Dönem Bilgileri", font, firca, 110, y);
            y = y + 20;
            e.Graphics.DrawRectangle(kalem, x, y, x2, y2 - 85);//y2-85 yeri bizim kare alanımızın boyutunu belirler değerlerle oynarken dikkatli olunuz.
            for (int i = 1; i <= 6; i++)//Küçük bölgeler için (1x)
            {
                e.Graphics.DrawLine(kalem, x, y, x2 + 5, y);
                y = y + 30;
            }
            for (int i = 1; i <= 4; i++)
            {
                e.Graphics.DrawLine(kalem, x, y, x, y2 + 170);
                x = x + 67;
            }
            /*------------------------------------------------------------------------------------------------*/
            /*------------------------------------------------------------------------------------------------*/
            /*------------------------------------------------------------------------------------------------*/
            x = 7;
            x2 = 265;
            e.Graphics.DrawString("Sayaçlar", font, firca, 110, y + 5);
            int sayacsayısı = root[kayit].faturaDetay.Count;//varsayılan değer 1, değişkenlik gösterebilir.
            y = y + 20;
            int sayacsutunuzunluk = 30;
            if (sayacsayısı > 1)
            {
                for (int i = 1; i <= sayacsayısı; i++)
                {
                    e.Graphics.DrawRectangle(kalem, x, y, x2, sayacsutunuzunluk);
                    sayacsutunuzunluk = sayacsutunuzunluk + 30;
                }
            }
            e.Graphics.DrawRectangle(kalem, 7, y, 265, sayacsutunuzunluk);
            for (int i = 1; i <= sayacsayısı; i++)//Küçük bölgeler için (1x)
            {
                e.Graphics.DrawLine(kalem, 7, y, 272, y);
                y = y + 30;
            }
            for (int i = 1; i <= 4; i++)
            {
                e.Graphics.DrawLine(kalem, x, y, x, y2 + 370);
                x = x + 67;
            }
        }
        DateTime tarih = DateTime.Today.AddDays(-30);
       
        
        private void fatura_ui_Load(object sender, EventArgs e)
        {
            this.Size = new Size(200,100);
            Location = new Point(570,320);
            
            /*
            while (true)
            {
                form1.ShowDialog();
                bool ret = GetBinaList(form1.maskedTextBox1.Text, form1.maskedTextBox2.Text);
                if (ret == true) break;
            }*/
        }
        int i = 0;
        private void button2_Click(object sender, EventArgs e)
        {

            
            do
            {
                printDocument1.Print();
                kayit++;
                i++;
            }
            while (i < root.Count);
            i = 0;
            
            
        }
         
        private  void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            donemBindingSource.Clear();
            tarih = dateTimePicker1.Value;
            
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                username = maskedTextBox1.Text;
                password = maskedTextBox2.Text;
                string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                               .GetBytes(username + ":" + password));
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + encoded);
                string donemId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                using (HttpResponseMessage response = await httpClient.GetAsync("http://api.faturapaylasim.net/print/faturalist?donemId=" + donemId))
                using (HttpContent content = response.Content)
                {

                    string result = await content.ReadAsStringAsync();
                    root = JsonConvert.DeserializeObject<List<Root>>(result);
                    
                    //donemBindingSource.DataSource = donem;
                }
            }
        }

        private void donemBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            donemBindingSource.Clear();
            
            using (var httpClient = new HttpClient())
            {
                username = maskedTextBox1.Text;
                password = maskedTextBox2.Text;
                string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                               .GetBytes(username + ":" + password));
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + encoded);
                tarih = dateTimePicker1.Value.Date;
                using (HttpResponseMessage response = await httpClient.GetAsync("http://api.faturapaylasim.net/print/donemlist?startDate=" + tarih))
                using (HttpContent content = response.Content)
                {

                    string result = await content.ReadAsStringAsync();
                    donem = JsonConvert.DeserializeObject<List<Donem>>(result);

                    //donemBindingSource.DataSource = donem;
                }
            }
            foreach (var item in donem)//Filtreleme
            {
                if (tarih <= item.faturaTarihi)
                {
                    donemBindingSource.Add(item);
                }
            }
        }

        private  void fatura_ui_Shown(object sender, EventArgs e)
        {

        }
        private async void button4_Click(object sender, EventArgs e)
        {

            
                using (var httpClient = new HttpClient())
                {

                username = maskedTextBox1.Text;
                password = maskedTextBox2.Text;
                string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                                   .GetBytes(username+":"+password));
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + encoded);
                    tarih = dateTimePicker1.Value.Date;
                    using (HttpResponseMessage response = await httpClient.GetAsync("http://api.faturapaylasim.net/print/donemlist?startDate=" + tarih))
                    using (HttpContent content = response.Content)
                    {
                        string result = await content.ReadAsStringAsync();
                        donem = JsonConvert.DeserializeObject<List<Donem>>(result);
                        
                        //donemBindingSource.DataSource = donem;
                    }
                }
                if (donem==null) { MessageBox.Show("Acces Denied."); }
            else
            {
                this.Size = new Size(561, 397);
                Location = new Point(450, 220);
                dataGridView1.Visible = true;
                dateTimePicker1.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                //-------------------------------
                maskedTextBox1.Visible = false;
                maskedTextBox2.Visible = false;
                button4.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fatura_ui_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.Red;
        }

        private void fatura_ui_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.LightGray;
        }
    }
}
