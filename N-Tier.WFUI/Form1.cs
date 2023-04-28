using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using N_Tier.ORM;
using N_Tier.ORM.Facade;

namespace N_Tier.WFUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvListe.DataSource = Kategoriler.Select();
        }

        public void KategoriListele()
        {
            dgvListe.DataSource = Kategoriler.Select();
            dgvListe.Columns[0].Visible = false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Kategori ktg = new Kategori();
            ktg.KategoriAdi = txtAd.Text;
            ktg.Tanimi = txtTanim.Text;
            bool sonuc = Kategoriler.Insert(ktg);
            if (sonuc)
            {
                MessageBox.Show("Başarılı Oldu.");
                KategoriListele();
            }
            else 
            {
                MessageBox.Show("Başarısız");
            }
            txtAd.Text = string.Empty;
            txtTanim.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Kategori ktg = new Kategori();
            ktg.KategoriID= (int)(dgvListe.CurrentRow.Cells["KategoriID"].Value);
            ktg.KategoriAdi = txtAd.Text;
            ktg.Tanimi = txtTanim.Text;
            bool sonuc = Kategoriler.Update(ktg);
            if (sonuc)
            {
                MessageBox.Show("Başarılı Oldu.");
                KategoriListele();
            }
            else
            {
                MessageBox.Show("Başarısız");
            }
            txtAd.Text = string.Empty;
            txtTanim.Text = string.Empty;
        }

        private void dgvListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAd.Text = dgvListe.CurrentRow.Cells[1].Value.ToString();
            txtTanim.Text = dgvListe.CurrentRow.Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kategori ktg = new Kategori();
            ktg.KategoriID = (int)(dgvListe.CurrentRow.Cells["KategoriID"].Value);
            bool sonuc = Kategoriler.Delete(ktg);
            if (sonuc)
            {
                MessageBox.Show("Başarılı Oldu.");
                KategoriListele();
            }
            else
            {
                MessageBox.Show("Başarısız");
            }
            txtAd.Text = string.Empty;
            txtTanim.Text = string.Empty;
        }
    }
}
