using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayıtOtomasyonu
{
    public partial class frmAna : Form
    {
        public frmAna()
        {
            InitializeComponent();
        }

        private void frmAna_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonuDBDataSet1.Ogrenci' table. You can move, or remove it, as needed.
            this.ogrenciTableAdapter.Fill(this.yurtOtomasyonuDBDataSet1.Ogrenci);

            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToShortTimeString();
        }

        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("MsPaint.exe");
        }

        private void öğrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOgrKayıt frm = new frmOgrKayıt();
            frm.Show();
            
        }

        private void öğrenciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOgrenciListe frm = new frmOgrenciListe();
            frm.Show();
        }

        private void bölümlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBolumler frm = new frmBolumler();
            frm.Show();
        }

        private void ödemelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOdemeler frm = new frmOdemeler();
            frm.Show();
        }

        private void giderEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGiderler frm = new frmGiderler();
            frm.Show();
        }

        private void giderListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGiderListesi frm = new frmGiderListesi();
            frm.Show();
        }


        private void şifreİşlemiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSifreYenileme frm = new frmSifreYenileme();
            frm.Show();
        }

        private void personelDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonel frm = new frmPersonel();
            frm.Show();
        }

        private void öğrenciSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOgrenciListe frm = new frmOgrenciListe();
            frm.Show();
        }

        private void gelirİstatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGelirİstatistikleri frm = new frmGelirİstatistikleri();
            frm.Show();
        }

        private void notEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotEkle frm = new frmNotEkle();
            frm.Show();
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu program Fatih Çetin tarafından yapılmıştır");
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
