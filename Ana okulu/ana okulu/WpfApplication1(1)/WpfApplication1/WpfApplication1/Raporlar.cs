using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfApplication1
{
    public partial class Raporlar : Form
    {
        OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;USER ID=harun;PASSWORD=harun");
        string ogrenci_ad = "";
        string ogrenci_soyad = "";
        string veli_ad = "";
        string veli_soyad = "";
        string ogretmen_ad = "";
        string ogretmen_soyad = "";
        string odeme_ad = "";
        string odeme_soyad = "";
        string tarih = "";
        string sinif;

        public Raporlar()
        {
            this.setConnection();
            InitializeComponent();
        }
        private void setConnection()
        {
            String connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            con = new OracleConnection(connectionString);
            try
            {
                con.Open();
            }
            catch (Exception exp) { }
        }

        private void btnOgrenciAra_Click(object sender, EventArgs e)
        {
        }

        private void txtOgrenciAd_TextChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from OGRENCI_SINIF_LISTESI where OGRENCI_AD='" + txtOgrenciAd.Text.ToString() + "' or OGRENCI_SOYAD='"+ txtOgrenciSoyad.Text.ToString() + "'"; //"' or AGE='" + txtOgrenciYas.Text + "' OR CLASS_ID=" + txtOgrenciSinifId.Text + " OR PARENT_ID=" + txtOgrenciVeliId;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvOgrenci.DataSource = dt;
            dr.Close();
            ogrenci_ad = txtOgrenciAd.Text;
        }

        private void txtOgrenciSoyad_TextChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from OGRENCI_SINIF_LISTESI where OGRENCI_AD='" + txtOgrenciAd.Text.ToString() + "' or OGRENCI_SOYAD='" + txtOgrenciSoyad.Text.ToString() + "'"; //"' or AGE='" + txtOgrenciYas.Text + "' OR CLASS_ID=" + txtOgrenciSinifId.Text + " OR PARENT_ID=" + txtOgrenciVeliId;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvOgrenci.DataSource = dt;
            dr.Close();
            ogrenci_soyad = txtOgrenciSoyad.Text;
        }

        private void txtVeliAd_TextChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from VELI_ILETISIM_LISTESI where NAME='" + txtVeliAd.Text.ToString() + "' or SURNAME='" + txtVeliSoyad.Text.ToString() + "'"; //"' or AGE='" + txtOgrenciYas.Text + "' OR CLASS_ID=" + txtOgrenciSinifId.Text + " OR PARENT_ID=" + txtOgrenciVeliId;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvVeli.DataSource = dt;
            dr.Close();
            veli_ad = txtVeliAd.Text;
        }

        private void txtVeliSoyad_TextChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from VELI_ILETISIM_LISTESI where NAME='" + txtVeliAd.Text.ToString() + "' or SURNAME='" + txtVeliSoyad.Text.ToString() + "'"; //"' or AGE='" + txtOgrenciYas.Text + "' OR CLASS_ID=" + txtOgrenciSinifId.Text + " OR PARENT_ID=" + txtOgrenciVeliId;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvVeli.DataSource = dt;
            dr.Close();
            veli_soyad = txtVeliSoyad.Text;
        }

        private void txtOgretmenAd_TextChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from OGRETMEN_ILETISIM_LISTESI where NAME='" + txtOgretmenAd.Text.ToString() + "' or SURNAME='" + txtOgretmenSoyad.Text.ToString() + "'"; //"' or AGE='" + txtOgrenciYas.Text + "' OR CLASS_ID=" + txtOgrenciSinifId.Text + " OR PARENT_ID=" + txtOgrenciVeliId;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvOgretmen.DataSource = dt;
            dr.Close();
            ogretmen_ad = txtOgretmenAd.Text;
        }

        private void txtOgretmenSoyad_TextChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from OGRETMEN_ILETISIM_LISTESI where NAME='" + txtOgretmenAd.Text.ToString() + "' or SURNAME='" + txtOgretmenSoyad.Text.ToString() + "'"; //"' or AGE='" + txtOgrenciYas.Text + "' OR CLASS_ID=" + txtOgrenciSinifId.Text + " OR PARENT_ID=" + txtOgrenciVeliId;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvOgretmen.DataSource = dt;
            dr.Close();
            ogretmen_soyad = txtOgretmenSoyad.Text;
        }

        private void txtOgrenciOdemeAd_TextChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from FATURA_ODEME_LISTESI where NAME='" + txtOgrenciOdemeAd.Text.ToString() + "' or TUTAR='" + txtOgrenciOdemeSoyad.Text.ToString() + "'"; //"' or AGE='" + txtOgrenciYas.Text + "' OR CLASS_ID=" + txtOgrenciSinifId.Text + " OR PARENT_ID=" + txtOgrenciVeliId;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvOdeme.DataSource = dt;
            dr.Close();
            odeme_ad = txtOgrenciOdemeAd.Text;
        }

        private void txtOgrenciOdemeSoyad_TextChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from FATURA_ODEME_LISTESI where NAME='" + txtOgrenciOdemeAd.Text.ToString() + "' or TUTAR='" + txtOgrenciOdemeSoyad.Text.ToString() + "'"; //"' or AGE='" + txtOgrenciYas.Text + "' OR CLASS_ID=" + txtOgrenciSinifId.Text + " OR PARENT_ID=" + txtOgrenciVeliId;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvOdeme.DataSource = dt;
            dr.Close();
            odeme_soyad = txtOgrenciOdemeSoyad.Text;
        }

        

        private void btnOgrRaporExport_Click(object sender, EventArgs e)
        {
            String Baslik = "Öğrenci Bilgileri";

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "export.docx";


            if (sfd.ShowDialog() == DialogResult.OK)
            {


                Export.Export_Data_To_Word(dgvOgrenci, sfd.FileName, Baslik);
            }
        }

        private void btnOGRTMNRaporExport_Click(object sender, EventArgs e)
        {

            String Baslik = "Öğretmen Bilgileri";

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "export.docx";


            if (sfd.ShowDialog() == DialogResult.OK)
            {


                Export.Export_Data_To_Word(dgvOgretmen, sfd.FileName, Baslik);
            }
        }

        private void btnSinifRaporExport_Click(object sender, EventArgs e)
        {
            String Baslik = "Sınıf Bilgileri";

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "export.docx";


            if (sfd.ShowDialog() == DialogResult.OK)
            {


                Export.Export_Data_To_Word(dgvSinif, sfd.FileName, Baslik);
            }
        }

        private void btnVeliRaporExport_Click(object sender, EventArgs e)
        {
            String Baslik = "Veli Bilgileri";

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "export.docx";


            if (sfd.ShowDialog() == DialogResult.OK)
            {


                Export.Export_Data_To_Word(dgvVeli, sfd.FileName, Baslik);
            }
        }

        private void btnOdemeRaporExport_Click(object sender, EventArgs e)
        {
            String Baslik = "Hesap  Bilgileri";

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "export.docx";


            if (sfd.ShowDialog() == DialogResult.OK)
            {


                Export.Export_Data_To_Word(dgvOdeme, sfd.FileName, Baslik);
            }
        }

        private void txtSinifAd_TextChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from CLASS where CLASS_NAME='" + txtSinifAd.Text.ToString()+"'";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvSinif.DataSource = dt;
            dr.Close();
            sinif = txtSinifAd.Text;
        }
    }
}
