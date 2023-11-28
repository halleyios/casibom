using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oyun2
{
    public partial class Form1 : Form
    {
        int sayac = 0;
        Oyuncu oyuncu1;
        public Form1()
        {
            InitializeComponent();
        }


        private void btnOlustur_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            string rId = random.Next(1000, 10000).ToString();

            //kurucu metotlar new anahtarı ile oluşturma aşamasında çalışır.
            oyuncu1 = new Oyuncu(rId, txtAd.Text, txtSoyad.Text ,txtPosta.Text ,100 ,DateTime.Now ,false);
           


        }

        private void btnGoster_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(  oyuncu1.BilgiYaz()  );

            lblBilgi.Text = oyuncu1.BilgiYaz();
        }

        private void btnVur_Click(object sender, EventArgs e)
        {
            sayac++;
            if(sayac < 6)
            {
                Vur(oyuncu1);
            }

            if(oyuncu1.Defans <= 0)
            {
                MessageBox.Show("Oyuncu Kaybetti");
                btnVur.Enabled = false;
            }

            if(oyuncu1.Defans > 0 && sayac == 6)
            {
                MessageBox.Show("Oyuncu Kazandı");
                btnVur.Enabled = false;
                
            }
            lblBilgi.Text = oyuncu1.BilgiYaz();
        }

        public void Vur(Oyuncu oyuncu)
        {
            Random r = new Random();
            oyuncu.Defans = oyuncu.Defans - r.Next(0,6);
        }
    }
}
