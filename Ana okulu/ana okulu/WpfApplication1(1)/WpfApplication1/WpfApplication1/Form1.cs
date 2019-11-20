using Excel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfApplication1
{
    public partial class Form1 : Form
    {
        DataSet ds;
        OracleConnection con = null;
        OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521/orcl;USER ID=harun;PASSWORD=harun");
        public Form1()
        {
            this.setConnection();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvDersKonusu.TabPages.Remove(tabPage8);

            OgrenciDataGrid();
            OgretmenDataGrid();
            SinifDataGrid();
            VeliDataGrid();
            DersDataGrid();
            OdemeDataGrid();
            //IletisimDataGrid();
            KullaniciDataGrid();

            btnOgrenciEkle.Visible = false;
            btnOgrenciGuncelle.Visible = false;
            btnOgrenciSil.Visible = false;


            conn.Close();
            conn.Open();
            MainWindow mw = new MainWindow();
            
            string sqlSelect = "SELECT * from USER_PRIVILIGES where USER_ID = " + Sitatikler.kullanici_id /*txtKullaniciId.Text*/;
            OracleCommand cmd1 = new OracleCommand(sqlSelect, conn);
            List<string> Isimler = new List<string>();

            OracleDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                Isimler.Add(reader1["PRIVILIGES_ID"].ToString());

                foreach (string element in Isimler)
                {

                    if (element == "1")
                    {
                        
                    }
                    else if (element == "2")
                    {
                        btnOgrenciEkle.Visible = true;
                        btnOgretmenEkle.Visible = true;
                        btnSınıfEkle.Visible = true;
                        btnVeliEkle.Visible = true;
                        btnDersEkle.Visible = true;
                        btnOdemeEkle.Visible = true;
                        //btnIletisimEkle.Visible = true;
                       
                    }
                    else if (element == "3")
                    {
                        btnOgrenciGuncelle.Visible = true;
                        btnOgretmenGuncelle.Visible = true;
                        btnSınıfGuncelle.Visible = true;
                        btnVeliGuncelle.Visible = true;
                        btnDersGuncelle.Visible = true;
                        btnOdemeGuncelle.Visible = true;
                        //btnIletisimGuncelle.Visible = true;
                    }
                    else if (element == "4")
                    {
                        btnOgrenciSil.Visible = true;
                        btnOgretmenSil.Visible = true;
                        btnSınıfSil.Visible = true;
                        btnVeliSil.Visible = true;
                        btnDersSil.Visible = true;
                        btnOdemeSil.Visible = true;
                        //btnIletisimSil.Visible = true;
                    }


                }

            }


            string sql_iletisim = "SELECT * from K_USER where USER_ID = " + Sitatikler.kullanici_id /*txtKullaniciId.Text*/;
            OracleCommand cmd_admin = new OracleCommand(sql_iletisim, conn);

            string priviliges="";
            OracleDataReader readercmd_admin = cmd_admin.ExecuteReader();
            while (readercmd_admin.Read())
            {
                priviliges = readercmd_admin["PRIVILIGESID"].ToString();
            }
            if (priviliges == "admin")
            {
                     dgvDersKonusu.TabPages.Add(tabPage8);
            }
    
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
        private void OgrenciDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM STUDENT";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvOgrenci.DataSource = dt;

            DataTable dt2 = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter("select * from PARENT ",conn);
            da.Fill(dt2);
            cmbOgrenciVeli.ValueMember = "PARENT_ID";
            cmbOgrenciVeli.DisplayMember = "NAME";
            cmbOgrenciVeli.DataSource = dt2;


            DataTable dt3 = new DataTable();
            OracleDataAdapter da3 = new OracleDataAdapter("select * from CLASS ", conn);
            da3.Fill(dt3);
            cmbOgrenciSinif.ValueMember = "CLASS_ID";
            cmbOgrenciSinif.DisplayMember = "CLASS_NAME";
            cmbOgrenciSinif.DataSource = dt3;




            dr.Close();
        }
        private void OgretmenDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM TEACHER";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvOgretmen.DataSource = dt;


          



            dr.Close();
        }
        private void SinifDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM CLASS";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvSinif.DataSource = dt;

            
            DataTable dt2 = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter("select * from TEACHER", conn);
            da.Fill(dt2);
            cmbSinifOgretmen.ValueMember = "TEACHER_ID";
            cmbSinifOgretmen.DisplayMember = "NAME";
            cmbSinifOgretmen.DataSource = dt2;

            DataTable dt3 = new DataTable();
            OracleDataAdapter da3 = new OracleDataAdapter("select * from SUBJECT", conn);
            da3.Fill(dt3);
            cmbSinifDers.ValueMember = "SUBJECT_ID";
            cmbSinifDers.DisplayMember = "SUBJECT_NAME";
            cmbSinifDers.DataSource = dt3;


            dr.Close();
        }
        private void VeliDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM PARENT";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvVeli.DataSource = dt;
            dr.Close();
        }

        private void DersDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM SUBJECT";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvDers.DataSource = dt;
            dr.Close();
        }
        private void OdemeDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM PAYMENT";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvOdeme.DataSource = dt;

            DataTable dt2 = new DataTable();
            OracleDataAdapter da2 = new OracleDataAdapter("select * from STUDENT ", conn);
            da2.Fill(dt2);
            cmbOdemeOgrenci.ValueMember = "STD_ID";
            cmbOdemeOgrenci.DisplayMember = "NAME";
            cmbOdemeOgrenci.DataSource = dt2;


            dr.Close();
        }

        

        private void KullaniciDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM K_USER";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvKullanici.DataSource = dt;
            dr.Close();
        }




        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtOgrenciAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOgrenciSoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOgrenciYas_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnOgrenciEkle_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO STUDENT(NAME, SURNAME, AGE, CLASS_ID, PARENT_ID) " +
                                     "VALUES(:NAME, :SURNAME, :AGE, :CLASS_ID, :PARENT_ID)";
            this.AUDOgrenci(sql, 0);
            btnOgrenciEkle.Enabled = false;
            btnOgrenciGuncelle.Enabled = true;
            btnOgrenciSil.Enabled = true;
        }

        private void btnOgrenciGuncelle_Click(object sender, EventArgs e)
        {
            String sql = "UPDATE STUDENT SET NAME = :NAME," +
               "SURNAME=:SURNAME, AGE=:AGE, CLASS_ID=:CLASS_ID, PARENT_ID=:PARENT_ID " +
               "WHERE STD_ID = :STD_ID";
            this.AUDOgrenci(sql, 1);
        }

        private void btnOgrenciSil_Click(object sender, EventArgs e)
        {
            String sql = "DELETE FROM STUDENT " +
                "WHERE STD_ID = :STD_ID";
            this.AUDOgrenci(sql, 2);
            this.resetAll();
        }
        private void resetAll()
        {
            txtOgrenciId.Text = "";
            txtOgrenciAd.Text = "";
            txtOgrenciSoyad.Text = "";
            txtOgrenciYas.Text = "";
           
            //cmbOgrenciSinif.Text = null;

            btnOgrenciEkle.Enabled = true;
            btnOgrenciGuncelle.Enabled = false;
            btnOgrenciSil.Enabled = false;
        }

        private void btnOgrenciReset_Click(object sender, EventArgs e)
        {
            this.resetAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dgvOgrenci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dgvOgrenci.Rows[ind];
            txtOgrenciId.Text = selectedRows.Cells[0].Value.ToString();
            txtOgrenciAd.Text = selectedRows.Cells[1].Value.ToString();
            txtOgrenciSoyad.Text = selectedRows.Cells[2].Value.ToString();
            txtOgrenciYas.Text = selectedRows.Cells[3].Value.ToString();


            btnOgrenciEkle.Enabled = false;
            btnOgrenciGuncelle.Enabled = true;
            btnOgrenciSil.Enabled = true;
        }


        private void AUDOgrenci(String sql_stmt, int state)
        {
            String msg = "";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;
            

            switch (state)
            {
                case 0:
                    msg = "Ekleme Başarılı";

                    cmd.Parameters.Add("NAME", OracleDbType.Varchar2, 35).Value = txtOgrenciAd.Text;
                    cmd.Parameters.Add("SURNAME", OracleDbType.Varchar2, 35).Value = txtOgrenciSoyad.Text;
                    cmd.Parameters.Add("AGE", OracleDbType.Varchar2, 20).Value = txtOgrenciYas.Text;
                    cmd.Parameters.Add("CLASS_ID", OracleDbType.Int32).Value = cmbOgrenciSinif.SelectedValue;
                    cmd.Parameters.Add("PARENT_ID", OracleDbType.Int32).Value = cmbOgrenciVeli.SelectedValue;
 
                    break;
                case 1:
                    msg = "Güncelleme Başarılı";
                    cmd.Parameters.Add("NAME", OracleDbType.Varchar2, 35).Value = txtOgrenciAd.Text;
                    cmd.Parameters.Add("SURNAME", OracleDbType.Varchar2, 35).Value = txtOgrenciSoyad.Text;
                    cmd.Parameters.Add("AGE", OracleDbType.Varchar2, 20).Value = txtOgrenciYas.Text;
                    cmd.Parameters.Add("CLASS_ID", OracleDbType.Int32).Value = cmbOgrenciSinif.SelectedValue;
                    cmd.Parameters.Add("PARENT_ID", OracleDbType.Int32).Value = cmbOgrenciVeli.SelectedValue;
                    cmd.Parameters.Add("STD_ID", OracleDbType.Int32, 6).Value = Int32.Parse(txtOgrenciId.Text);

                    break;
                case 2:
                    msg = "Öğrenci Başarı ile Silindi!";

                    cmd.Parameters.Add("STD_ID", OracleDbType.Int32).Value = Int32.Parse(txtOgrenciId.Text);

                    break;
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.OgrenciDataGrid();
                }
            }
            catch (Exception expe) { }
        }




        private void AUDOgretmen(String sql_stmt, int state)
        {
            String msg = "";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;

            switch (state)
            {
                case 0:
                    string oradb = "DATA SOURCE=localhost:1521/orcl;USER ID=harun;PASSWORD=harun";
                    OracleConnection conn = new OracleConnection(oradb); // C#
                    conn.Close();
                    conn.Open();

                    string sql = "SELECT MAX(CONTACT_ID) as max from CONTACT ";
                    OracleCommand cmdMAX = new OracleCommand(sql, conn);

                    int BuyukId = 0;
                    OracleDataReader readercmdMAX = cmdMAX.ExecuteReader();
                    while (readercmdMAX.Read())
                    {
                        BuyukId = Int32.Parse(readercmdMAX["max"].ToString());
                    }

                    msg = "Ekleme Başarılı";
                    cmd.Parameters.Add("NAME", OracleDbType.Varchar2, 20).Value = txtOgretmenAd.Text;
                    cmd.Parameters.Add("SURNAME", OracleDbType.Varchar2, 20).Value = txtOgretmenSoyad.Text;
                    cmd.Parameters.Add("AGE", OracleDbType.Varchar2, 10).Value = txtOgretmenYas.Text;
                    cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32, 38).Value = BuyukId;


                    

                    break;
                case 1:
                    msg = "Güncelleme Başarılı";
                    cmd.Parameters.Add("NAME", OracleDbType.Varchar2, 20).Value = txtOgretmenAd.Text;
                    cmd.Parameters.Add("SURNAME", OracleDbType.Varchar2, 20).Value = txtOgretmenSoyad.Text;
                    cmd.Parameters.Add("AGE", OracleDbType.Varchar2, 10).Value = txtOgretmenYas.Text;
                    cmd.Parameters.Add("TEACHER_ID", OracleDbType.Int32, 6).Value = Int32.Parse(txtOgretmenId.Text);

                    break;
                case 2:
                    msg = "Silme Başaılı";

                    cmd.Parameters.Add("TEACHER_ID", OracleDbType.Int32).Value = Int32.Parse(txtOgretmenId.Text);

                    break;
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.OgretmenDataGrid();
                }
            }
            catch (Exception expe) { }
        }
        private void AUDSinif(String sql_stmt, int state)
        {
            String msg = "";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;

            switch (state)
            {
                case 0:
                    msg = "Ekleme Başarılı";
                    cmd.Parameters.Add("CLASS_NAME", OracleDbType.Varchar2, 20).Value = txtSinifAd.Text;
                    cmd.Parameters.Add("SUBJECT_ID", OracleDbType.Int32, 38).Value = cmbSinifDers.SelectedValue;
                    cmd.Parameters.Add("TEACHER_ID", OracleDbType.Int32, 38).Value = cmbSinifOgretmen.SelectedValue;



                    break;
                case 1:
                    msg = "Güncelleme Başarılı";
                    cmd.Parameters.Add("CLASS_NAME", OracleDbType.Varchar2, 20).Value = txtSinifAd.Text;
                    cmd.Parameters.Add("SUBJECT_ID", OracleDbType.Int32, 38).Value = cmbSinifDers.SelectedValue;
                    cmd.Parameters.Add("TEACHER_ID", OracleDbType.Int32,38).Value = cmbSinifOgretmen.SelectedValue;
                    cmd.Parameters.Add("CLASS_ID", OracleDbType.Int32, 38).Value = Int32.Parse(txtSinifId.Text);

                    break;
                case 2:
                    msg = "Başarı ile Silindi!";

                    cmd.Parameters.Add("CLASS_ID", OracleDbType.Int32).Value = Int32.Parse(txtSinifId.Text);

                    break;
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.SinifDataGrid();
                }
            }
            catch (Exception expe) { }
        }
        private void AUDVeli(String sql_stmt, int state)
        {
            String msg = "";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;

            switch (state)
            {
                case 0:
                    string oradb = "DATA SOURCE=localhost:1521/orcl;USER ID=harun;PASSWORD=harun";
                    OracleConnection conn = new OracleConnection(oradb); // C#
                    conn.Close();
                    conn.Open();

                    string sql = "SELECT MAX(CONTACT_ID) as max from CONTACT ";
                    OracleCommand cmdMAX = new OracleCommand(sql, conn);

                    int BuyukId = 0;
                    OracleDataReader readercmdMAX = cmdMAX.ExecuteReader();
                    while (readercmdMAX.Read())
                    {
                        BuyukId = Int32.Parse(readercmdMAX["max"].ToString());
                    }
                    msg = "Ekleme Başarılı";
                    cmd.Parameters.Add("NAME", OracleDbType.Varchar2, 20).Value = txtVeliAd.Text;
                    cmd.Parameters.Add("SURNAME", OracleDbType.Varchar2, 20).Value = txtVeliSoyad.Text;
                    cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32, 38).Value = BuyukId;



                    break;
                case 1:
                    msg = "Güncelleme Başarılı";
                    cmd.Parameters.Add("NAME", OracleDbType.Varchar2, 20).Value = txtVeliAd.Text;
                    cmd.Parameters.Add("SURNAME", OracleDbType.Varchar2, 20).Value = txtVeliSoyad.Text;
                    cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32,38).Value = Convert.ToInt32(txtVeliContactId.Text);
                    cmd.Parameters.Add("PARENT_ID", OracleDbType.Int32, 38).Value = Int32.Parse(txtVeliId.Text);

                    break;
                case 2:
                    msg = "Silme Başaılı";

                    cmd.Parameters.Add("PARENT_ID", OracleDbType.Int32,38).Value = Int32.Parse(txtVeliId.Text);

                    break;
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.VeliDataGrid();
                }
            }
            catch (Exception expe) { }
        }
        private void AUDDersler(String sql_stmt, int state)
        {
            String msg = "";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;

            switch (state)
            {
                case 0:
                    msg = "Ekleme Başarılı";
                    cmd.Parameters.Add("SUBJECT_NAME", OracleDbType.Varchar2, 20).Value = txtDersAd.Text;
                    break;
                case 1:
                    msg = "Güncelleme Başarılı";
                    cmd.Parameters.Add("SUBJECT_NAME", OracleDbType.Varchar2, 20).Value = txtDersAd.Text;
                    cmd.Parameters.Add("SUBJECT_ID", OracleDbType.Int32, 38).Value = Int32.Parse(txtDersId.Text);

                    break;
                case 2:
                    msg = "Ders Başarı ile Silindi!";

                    cmd.Parameters.Add("SUBJECT_ID", OracleDbType.Int32, 38).Value = Int32.Parse(txtDersId.Text);

                    break;
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.DersDataGrid();
                }
            }
            catch (Exception expe) { }
        }
        private void AUDOdeme(String sql_stmt, int state)
        {
            String msg = "";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;

            switch (state)
            {
                case 0:
                    msg = "Ekleme Başarılı";
                    cmd.Parameters.Add("STUDENT_ID", OracleDbType.Int32).Value = cmbOdemeOgrenci.SelectedValue;
                    cmd.Parameters.Add("AMOUNT", OracleDbType.Varchar2, 40).Value = txtOdemeMiktar.Text;
                    string theDate = dtpOdeme.Value.ToShortDateString();
                    cmd.Parameters.Add("FROMDATE", OracleDbType.Varchar2, 20).Value = theDate;



                    break;
                case 1:
                    msg = "Güncelleme Başarılı";
                
                    cmd.Parameters.Add("STUDENT_ID", OracleDbType.Int32).Value = cmbOdemeOgrenci.SelectedValue;
                    cmd.Parameters.Add("AMOUNT", OracleDbType.Varchar2, 40).Value = txtOdemeMiktar.Text;
                    cmd.Parameters.Add("FROMDATE", OracleDbType.Varchar2, 20).Value = dtpOdeme.Text;

                    cmd.Parameters.Add("PAYMENT_ID", OracleDbType.Int32, 38).Value = Convert.ToInt32(txtOdemeId.Text);


                    break;
                case 2:
                    msg = "Silme Başaılı";

                    cmd.Parameters.Add("PAYMENT_ID", OracleDbType.Int32,38).Value = Int32.Parse(txtOdemeId.Text);

                    break;
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.OdemeDataGrid();
                }
            }
            catch (Exception expe) { }
        }

        private void AUDIletisimOgretmen(String sql_stmt, int state)
        {
            String msg = "";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;

            //string oradb = "DATA SOURCE=localhost:1521/orcl;USER ID=harun;PASSWORD=harun";
            //OracleConnection conn = new OracleConnection(oradb); // C#
            //conn.Open();
            //string sql_iletisim = "SELECT CONTACT_ID from CONTACT WHERE TEL_NUMBER='" + txtOgretmenTelNo.Text.ToString() + "'";
            //OracleCommand cmd_iletisim = new OracleCommand(sql_iletisim, conn);

            //int iletisim_id = 0;
            //OracleDataReader readercmd_iletisim = cmd_iletisim.ExecuteReader();
            //while (readercmd_iletisim.Read())
            //{
            //    iletisim_id = Int32.Parse(readercmd_iletisim["CONTACT_ID"].ToString());
            //}

            switch (state)
            {
                case 0:
                    msg = "Ekleme Başarılı";
                    //cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32, 38).Value = Convert.ToInt32(txtIletisimId.Text);
                    cmd.Parameters.Add("STREET", OracleDbType.Varchar2, 20).Value = txtOgretmenCadde.Text;
                    cmd.Parameters.Add("VILLAGE", OracleDbType.Varchar2, 20).Value = txtOgretmenMahalle.Text;
                    cmd.Parameters.Add("CITY", OracleDbType.Varchar2, 20).Value = txtOgretmenSehir.Text;
                    cmd.Parameters.Add("TEL_NUMBER", OracleDbType.Varchar2, 20).Value = txtOgretmenTelNo.Text;


                    //cmd.Parameters.Add("CLASSID", OracleDbType.Int32).Value = cmbOgrenciSinif.SelectedIndex;


                    break;
                case 1:
                    msg = "Güncelleme Başarılı";

                    cmd.Parameters.Add("STREET", OracleDbType.Varchar2, 20).Value = txtOgretmenCadde.Text;
                    cmd.Parameters.Add("VILLAGE", OracleDbType.Varchar2, 20).Value  =txtOgretmenMahalle.Text;
                    cmd.Parameters.Add("CITY", OracleDbType.Varchar2, 20).Value = txtOgretmenSehir.Text;
                    cmd.Parameters.Add("TEL_NUMBER", OracleDbType.Varchar2, 20).Value = txtOgretmenTelNo.Text;
                    cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32, 38).Value = Convert.ToInt64(txtOgretmenContactId.Text);

                    break;
                case 2:
                    msg = "Silme Başaılı";

                  //  cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32, 38).Value = iletisim_id;

                    break;
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    //this.IletisimDataGrid();
                }
            }
            catch (Exception expe) { }
        }
        private void AUDIletisimVeli(String sql_stmt, int state)
        {
            String msg = "";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;

            //string oradb = "DATA SOURCE=localhost:1521/orcl;USER ID=harun;PASSWORD=harun";
            //OracleConnection conn = new OracleConnection(oradb); // C#
            //conn.Open();
            //string sql_iletisim = "SELECT CONTACT_ID from CONTACT WHERE TEL_NUMBER='" + txtVeliTelNo.Text.ToString() + "'";
            //OracleCommand cmd_iletisim = new OracleCommand(sql_iletisim, conn);

            //int iletisim_id = 0;
            //OracleDataReader readercmd_iletisim = cmd_iletisim.ExecuteReader();
            //while (readercmd_iletisim.Read())
            //{
            //    iletisim_id = Int32.Parse(readercmd_iletisim["CONTACT_ID"].ToString());
            //}

            switch (state)
            {
                case 0:
                    msg = "Ekleme Başarılı";
                    //cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32, 38).Value = Convert.ToInt32(txtIletisimId.Text);
                    cmd.Parameters.Add("STREET", OracleDbType.Varchar2, 20).Value = txtVeliCadde.Text;
                    cmd.Parameters.Add("VILLAGE", OracleDbType.Varchar2, 20).Value = txtVeliMahalle.Text;
                    cmd.Parameters.Add("CITY", OracleDbType.Varchar2, 20).Value = txtVeliSehir.Text;
                    cmd.Parameters.Add("TEL_NUMBER", OracleDbType.Varchar2, 20).Value = txtVeliTelNo.Text;


                    //cmd.Parameters.Add("CLASSID", OracleDbType.Int32).Value = cmbOgrenciSinif.SelectedIndex;


                    break;
                case 1:
                    msg = "Güncelleme Başarılı";

                    cmd.Parameters.Add("STREET", OracleDbType.Varchar2, 20).Value =  txtVeliCadde.Text;
                    cmd.Parameters.Add("VILLAGE", OracleDbType.Varchar2, 20).Value = txtVeliMahalle.Text;
                    cmd.Parameters.Add("CITY", OracleDbType.Varchar2, 20).Value = txtVeliSehir.Text;
                    cmd.Parameters.Add("TEL_NUMBER", OracleDbType.Varchar2, 20).Value = txtVeliTelNo.Text;
                    cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32, 38).Value = Convert.ToInt64(txtVeliContactId.Text);

                    break;
                case 2:
                    msg = "Silme Başaılı";

                    //cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32, 38).Value = iletisim_id;

                    break;
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                   MessageBox.Show(msg);
                    //this.IletisimDataGrid();
                }
            }
            catch (Exception expe) { }
        }
        private void AUDKullanici(String sql_stmt, int state)
        {
            String msg = "";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;

            switch (state)
            {
                case 0:
                    msg = "Ekleme Başarılı";
                    //cmd.Parameters.Add("USER_ID", OracleDbType.Int32, 6).Value = Int32.Parse(txtKullaniciId.Text);
                    cmd.Parameters.Add("USERNAME", OracleDbType.Varchar2, 35).Value = txtKullaniciAdi.Text;
                    cmd.Parameters.Add("PASSWORD", OracleDbType.Varchar2, 35).Value = txtKullaniciSifre.Text;
                    cmd.Parameters.Add("PRIVILIGESID", OracleDbType.Varchar2, 20).Value = txtKullaniciYetkiAdi.Text;
                    //cmd.Parameters.Add("CLASS_ID", OracleDbType.Int32).Value = Convert.ToInt32(txtOgrenciSinifId.Text);
                    //cmd.Parameters.Add("PARENT_ID", OracleDbType.Int32).Value = Convert.ToInt32(txtOgrenciVeliId.Text);

                    //cmd.Parameters.Add("CLASSID", OracleDbType.Int32).Value = cmbOgrenciSinif.SelectedIndex;


                    break;
                case 1:
                    msg = "Güncelleme Başarılı";
                    cmd.Parameters.Add("USERNAME", OracleDbType.Varchar2, 20).Value = txtKullaniciAdi.Text;
                    cmd.Parameters.Add("PASSWORD", OracleDbType.Varchar2, 20).Value = txtKullaniciSifre.Text;
                    cmd.Parameters.Add("PRIVILIGESID", OracleDbType.Varchar2,20).Value = txtKullaniciYetkiAdi.Text;
                    //cmd.Parameters.Add("PARENT_ID", OracleDbType.Int32).Value = Convert.ToInt32(txtOgrenciVeliId.Text);

                    cmd.Parameters.Add("USER_ID", OracleDbType.Int32).Value = Int32.Parse(txtKullaniciId.Text);

                    break;
                case 2:
                    msg = "Silme Başaılı";

                    cmd.Parameters.Add("USER_ID", OracleDbType.Int32).Value = Int32.Parse(txtKullaniciId.Text);

                    break;
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.KullaniciDataGrid();
                }
            }
            catch (Exception expe) { }
        }
        private void AUDYetki(String sql_stmt, int state,int yetki_id)
        {
            String msg = "";
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;

            switch (state)
            {
                
                case 0:
                    conn.Close();
                    conn.Open();
                    string sql = "SELECT max(USER_ID) as privili from K_USER ";
                    OracleCommand cmdMAX = new OracleCommand(sql, conn);

                    //cmd.CommandType = CommandType.Text;
                    //cmd.ExecuteNonQuery();
                    //cmd.CommandType = CommandType.Text;
                    //object val = cmd.ExecuteScalar();
                    int asd = 0;
                    OracleDataReader readercmdMAX = cmdMAX.ExecuteReader();
                    while (readercmdMAX.Read())
                    {
                        asd = Int32.Parse(readercmdMAX["privili"].ToString());

                    }
                    msg = "Ekleme Başarılı";
                    cmd.Parameters.Add("USER_ID", OracleDbType.Int32).Value = asd /*Int32.Parse(txtKullaniciId.Text)*/ ;
                    cmd.Parameters.Add("PRIVILIGES_ID", OracleDbType.Varchar2, 35).Value = yetki_id;
                    //cmd.Parameters.Add("SURNAME", OracleDbType.Varchar2, 35).Value = txtOgrenciSoyad.Text;
                    //cmd.Parameters.Add("AGE", OracleDbType.Varchar2, 20).Value = txtOgrenciYas.Text;
                    //cmd.Parameters.Add("CLASS_ID", OracleDbType.Int32).Value = Convert.ToInt32(txtOgrenciSinifId.Text);
                    //cmd.Parameters.Add("PARENT_ID", OracleDbType.Int32).Value = Convert.ToInt32(txtOgrenciVeliId.Text);

                    //cmd.Parameters.Add("CLASSID", OracleDbType.Int32).Value = cmbOgrenciSinif.SelectedIndex;


                    break;
                case 1:
                    msg = "Güncelleme Başarılı";
                    cmd.Parameters.Add("USER_ID", OracleDbType.Varchar2, 35).Value = txtOgrenciAd.Text;
                    cmd.Parameters.Add("PRIVILIGES_ID", OracleDbType.Varchar2, 35).Value = txtOgrenciSoyad.Text;
                    //cmd.Parameters.Add("AGE", OracleDbType.Varchar2, 20).Value = txtOgrenciYas.Text;
                    //cmd.Parameters.Add("CLASS_ID", OracleDbType.Int32).Value = Convert.ToInt32(txtOgrenciSinifId.Text);
                    //cmd.Parameters.Add("PARENT_ID", OracleDbType.Int32).Value = Convert.ToInt32(txtOgrenciVeliId.Text);
                    //cmd.Parameters.Add("STD_ID", OracleDbType.Int32, 6).Value = Int32.Parse(txtOgrenciId.Text);

                    break;
                case 2:
                    msg = "Silme Başaılı";

                    cmd.Parameters.Add("USER_ID", OracleDbType.Int32).Value = Int32.Parse(txtKullaniciId.Text);

                    break;
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                //if (n > 0)
                //{
                //    MessageBox.Show(msg);
                //    this.OgrenciDataGrid();
                //}
            }
            catch (Exception expe) { }
        }





























        private void btnOgretmenEkle_Click(object sender, EventArgs e)
        {
            String sql2 = "INSERT INTO CONTACT(STREET,  VILLAGE, CITY, TEL_NUMBER) " +
                                  "VALUES(:STREET, :VILLAGE, :CITY, :TEL_NUMBER)";
            this.AUDIletisimOgretmen(sql2, 0);

            String sql = "INSERT INTO TEACHER(NAME, SURNAME, AGE, CONTACT_ID) " +
                                     "VALUES(:NAME, :SURNAME, :AGE, :CONTACT_ID)";
            this.AUDOgretmen(sql, 0);
            btnOgretmenEkle.Enabled = false;
            btnOgretmenGuncelle.Enabled = true;
            btnOgretmenSil.Enabled = true;
        }

        private void btnOgretmenGuncelle_Click(object sender, EventArgs e)
        {
            String sql2 = "UPDATE CONTACT SET STREET = :STREET," +
               "VILLAGE=:VILLAGE, CITY=:CITY, TEL_NUMBER=:TEL_NUMBER " +
               "WHERE CONTACT_ID = :CONTACT_ID";
            this.AUDIletisimOgretmen(sql2, 1);

            String sql = "UPDATE TEACHER SET NAME = :NAME," +
               "SURNAME=:SURNAME, AGE=:AGE " +
               "WHERE TEACHER_ID = :TEACHER_ID";
            this.AUDOgretmen(sql, 1);
        }

        private void btnOgretmenSil_Click(object sender, EventArgs e)
        {
            String sql = "DELETE FROM TEACHER " +
                "WHERE TEACHER_ID = :TEACHER_ID";
            this.AUDOgretmen(sql, 2);
            this.resetAll();
        }


        private void btnOgretmenReset_Click(object sender, EventArgs e)
        {
            txtOgretmenAd.Text = "";
            txtOgretmenSoyad.Text = "";
            txtOgretmenYas.Text = "";
            txtOgretmenMahalle.Text = "";
            txtOgretmenSehir.Text = "";
            txtOgretmenCadde.Text = "";
            txtOgretmenTelNo.Text = "";
           

            btnOgretmenEkle.Enabled = true;
            btnOgretmenGuncelle.Enabled = false;
            btnOgretmenSil.Enabled = false;
        }
        private void dgvOgretmen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dgvOgretmen.Rows[ind];
            txtOgretmenId.Text = selectedRows.Cells[0].Value.ToString();

            txtOgretmenAd.Text = selectedRows.Cells[1].Value.ToString();
            txtOgretmenSoyad.Text = selectedRows.Cells[2].Value.ToString();
            txtOgretmenYas.Text = selectedRows.Cells[3].Value.ToString();
            txtOgretmenContactId.Text = selectedRows.Cells[4].Value.ToString();
            //txtOgretmenSinifi.Text = selectedRows.Cells[3].Value.ToString();
            //txtOgrenciVeliId.Text = selectedRows.Cells[4].Value.ToString();
            //txtOgrenciSinifId.Text = selectedRows.Cells[5].Value.ToString();
            //cmbOgrenciSinif.Text = selectedRows.Cells[4].Value.ToString();
            //txtorderquantity.Text = selectedRows.Cells[4].Value.ToString();

            btnOgretmenEkle.Enabled = false;
            btnOgretmenGuncelle.Enabled = true;
            btnOgretmenSil.Enabled = true;
        }



        private void btnSınıfEkle_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO CLASS (CLASS_NAME, SUBJECT_ID, TEACHER_ID) " +
                                     "VALUES(:CLASS_NAME, :SUBJECT_ID, :TEACHER_ID)";
            this.AUDSinif(sql, 0);
            btnSınıfEkle.Enabled = false;
            btnSınıfGuncelle.Enabled = true;
            btnSınıfSil.Enabled = true;
        }

        private void btnSınıfGuncelle_Click(object sender, EventArgs e)
        {
            String sql = "UPDATE CLASS SET CLASS_NAME = :CLASS_NAME," +
               "SUBJECT_ID=:SUBJECT_ID, TEACHER_ID=:TEACHER_ID " +
               "WHERE CLASS_ID = :CLASS_ID";
            this.AUDSinif(sql, 1);
        }

        private void btnSınıfSil_Click(object sender, EventArgs e)
        {
            String sql = "DELETE FROM CLASS " +
                "WHERE CLASS_ID = :CLASS_ID";
            this.AUDSinif(sql, 2);
            this.resetAll();
        }

        private void btnSınıfReset_Click(object sender, EventArgs e)
        {
            txtSinifId.Text = "";
            txtSinifAd.Text = "";
            //txtSinifDers.Text = "";
            txtSinifOgretmen.Text = "";
           // txtSinifOgrenci.Text = "";
            //cmbOgrenciSinif.Text = null;

            btnSınıfEkle.Enabled = true;
            btnSınıfGuncelle.Enabled = false;
            btnSınıfSil.Enabled = false;
        }

        private void dgvSinif_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dgvSinif.Rows[ind];
            txtSinifId.Text = selectedRows.Cells[0].Value.ToString();
            txtSinifAd.Text = selectedRows.Cells[1].Value.ToString();
            //txtSinifDers.Text = selectedRows.Cells[2].Value.ToString();
            txtSinifOgretmen.Text = selectedRows.Cells[3].Value.ToString();
            //txtSinifOgrenci.Text = selectedRows.Cells[4].Value.ToString();
            //txtOgretmenSinifi.Text = selectedRows.Cells[3].Value.ToString();
            //txtOgrenciVeliId.Text = selectedRows.Cells[4].Value.ToString();
            //txtOgrenciSinifId.Text = selectedRows.Cells[5].Value.ToString();
            //cmbOgrenciSinif.Text = selectedRows.Cells[4].Value.ToString();
            //txtorderquantity.Text = selectedRows.Cells[4].Value.ToString();

            btnSınıfEkle.Enabled = false;
            btnSınıfGuncelle.Enabled = true;
            btnSınıfSil.Enabled = true;
        }

        private void btnVeliEkle_Click(object sender, EventArgs e)
        {
            String sql2 = "INSERT INTO CONTACT(STREET,  VILLAGE, CITY, TEL_NUMBER) " +
                                  "VALUES(:STREET, :VILLAGE, :CITY, :TEL_NUMBER)";
            this.AUDIletisimVeli(sql2, 0);

            String sql = "INSERT INTO PARENT (NAME, SURNAME, CONTACT_ID) " +
                                    "VALUES(:NAME, :SURNAME, :CONTACT_ID)";
            this.AUDVeli(sql, 0);
            btnVeliEkle.Enabled = false;
            btnVeliGuncelle.Enabled = true;
            btnVeliSil.Enabled = true;
        }

        private void btnVeliGuncelle_Click(object sender, EventArgs e)
        {
            String sql2 = "UPDATE CONTACT SET STREET = :STREET," +
               "VILLAGE=:VILLAGE, CITY=:CITY, TEL_NUMBER=:TEL_NUMBER " +
               "WHERE CONTACT_ID = :CONTACT_ID";
            this.AUDIletisimVeli(sql2, 1);

            String sql = "UPDATE PARENT SET NAME = :NAME," +
               "SURNAME=:SURNAME, CONTACT_ID=:CONTACT_ID " +
               "WHERE PARENT_ID = :PARENT_ID";
            this.AUDVeli(sql, 1);
        }

        private void btnVeliSil_Click(object sender, EventArgs e)
        {
            String sql = "DELETE FROM PARENT " +
                "WHERE PARENT_ID = :PARENT_ID";
            this.AUDVeli(sql, 2);
            this.resetAll();
        }

        private void btnVeliReset_Click(object sender, EventArgs e)
        {
            txtVeliId.Text = "";
            txtVeliAd.Text = "";
            txtVeliSoyad.Text = "";
            txtVeliContactId.Text = "";
            //txtSinifOgrenci.Text = "";
            //cmbOgrenciSinif.Text = null;
            txtVeliCadde.Text = "";
            txtVeliMahalle.Text = "";
            txtVeliSehir.Text = "";
            txtVeliTelNo.Text = "";

            btnVeliEkle.Enabled = true;
            btnVeliGuncelle.Enabled = false;
            btnVeliSil.Enabled = false;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dgvVeli.Rows[ind];
            txtVeliId.Text = selectedRows.Cells[0].Value.ToString();
            txtVeliAd.Text = selectedRows.Cells[1].Value.ToString();
            txtVeliSoyad.Text = selectedRows.Cells[2].Value.ToString();
            txtVeliContactId.Text = selectedRows.Cells[3].Value.ToString();
            //xtSinifOgrenci.Text = selectedRows.Cells[4].Value.ToString();
            //txtOgretmenSinifi.Text = selectedRows.Cells[3].Value.ToString();
            //txtOgrenciVeliId.Text = selectedRows.Cells[4].Value.ToString();
            //txtOgrenciSinifId.Text = selectedRows.Cells[5].Value.ToString();
            //cmbOgrenciSinif.Text = selectedRows.Cells[4].Value.ToString();
            //txtorderquantity.Text = selectedRows.Cells[4].Value.ToString();

            btnVeliEkle.Enabled = false;
            btnVeliGuncelle.Enabled = true;
            btnVeliSil.Enabled = true;
        }

        private void btnDersEkle_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO SUBJECT (SUBJECT_NAME) " +
                                    "VALUES(:SUBJECT_NAME)";
            this.AUDDersler(sql, 0);
            btnDersEkle.Enabled = false;
            btnDersGuncelle.Enabled = true;
            btnDersSil.Enabled = true;
        }

        private void btnDersGuncelle_Click(object sender, EventArgs e)
        {
            String sql = "UPDATE SUBJECT SET SUBJECT_NAME = :SUBJECT_NAME "  +
               "WHERE SUBJECT_ID = :SUBJECT_ID";
            this.AUDDersler(sql, 1);
        }

        private void btnDersSil_Click(object sender, EventArgs e)
        {
            String sql = "DELETE FROM SUBJECT " +
               "WHERE SUBJECT_ID = :SUBJECT_ID";
            this.AUDDersler(sql, 2);
            this.resetAll();
        }

        private void btnDersReset_Click(object sender, EventArgs e)
        {
            txtDersId.Text = "";
            txtDersAd.Text = "";
        

            btnDersEkle.Enabled = true;
            btnDersGuncelle.Enabled = false;
            btnDersSil.Enabled = false;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvDers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dgvDers.Rows[ind];
            txtDersId.Text = selectedRows.Cells[0].Value.ToString();
            txtDersAd.Text = selectedRows.Cells[1].Value.ToString();
            //txtVeliSoyad.Text = selectedRows.Cells[2].Value.ToString();
            //txtVeliContactId.Text = selectedRows.Cells[3].Value.ToString();
            //xtSinifOgrenci.Text = selectedRows.Cells[4].Value.ToString();
            //txtOgretmenSinifi.Text = selectedRows.Cells[3].Value.ToString();
            //txtOgrenciVeliId.Text = selectedRows.Cells[4].Value.ToString();
            //txtOgrenciSinifId.Text = selectedRows.Cells[5].Value.ToString();
            //cmbOgrenciSinif.Text = selectedRows.Cells[4].Value.ToString();
            //txtorderquantity.Text = selectedRows.Cells[4].Value.ToString();

            btnDersEkle.Enabled = false;
            btnDersGuncelle.Enabled = true;
            btnDersSil.Enabled = true;
        }

        private void btnOdemeEkle_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO PAYMENT (STUDENT_ID,AMOUNT,FROMDATE) " +
                                    "VALUES(:STUDENT_ID, :AMOUNT,:FROMDATE)";
            this.AUDOdeme(sql, 0);
            btnOdemeEkle.Enabled = false;
            btnOdemeGuncelle.Enabled = true;
            btnOdemeSil.Enabled = true;
        }

        private void btnOdemeGuncelle_Click(object sender, EventArgs e)
        {
            String sql = "UPDATE PAYMENT SET STUDENT_ID=:STUDENT_ID, AMOUNT=:AMOUNT, FROMDATE=:FROMDATE " +
               "WHERE PAYMENT_ID = :PAYMENT_ID";
            this.AUDOdeme(sql, 1);
        }

        private void btnOdemeSil_Click(object sender, EventArgs e)
        {
            String sql = "DELETE FROM PAYMENT " +
              "WHERE PAYMENT_ID = :PAYMENT_ID";
            this.AUDOdeme(sql, 2);
            this.resetAll();
        }

        private void btnOdemeReset_Click(object sender, EventArgs e)
        {
            txtOdemeId.Text = "";
            txtOdemeOgrenci.Text = "";
            txtOdemeMiktar.Text = "";
           


            btnOdemeEkle.Enabled = true;
            btnOdemeGuncelle.Enabled = false;
            btnOdemeSil.Enabled = false;
        }

        private void dgvOdeme_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dgvOdeme.Rows[ind];
            txtOdemeId.Text = selectedRows.Cells[0].Value.ToString();
            txtOdemeOgrenci.Text = selectedRows.Cells[1].Value.ToString();
            txtOdemeMiktar.Text = selectedRows.Cells[2].Value.ToString();
            dtpOdeme.Text = selectedRows.Cells[3].Value.ToString();
            //xtSinifOgrenci.Text = selectedRows.Cells[4].Value.ToString();
            //txtOgretmenSinifi.Text = selectedRows.Cells[3].Value.ToString();
            //txtOgrenciVeliId.Text = selectedRows.Cells[4].Value.ToString();
            //txtOgrenciSinifId.Text = selectedRows.Cells[5].Value.ToString();
            //cmbOgrenciSinif.Text = selectedRows.Cells[4].Value.ToString();
            //txtorderquantity.Text = selectedRows.Cells[4].Value.ToString();

            btnOdemeEkle.Enabled = false;
            btnOdemeGuncelle.Enabled = true;
            btnOdemeSil.Enabled = true;
        }

        //private void btnIletisimEkle_Click(object sender, EventArgs e)
        //{
        //    String sql = "INSERT INTO CONTACT(STREET,  VILLAGE, CITY, TEL_NUMBER) " +
        //                            "VALUES(:STREET, :VILLAGE, :CITY, :TEL_NUMBER)";
        //    this.AUDIletisim(sql, 0);
        //    btnIletisimEkle.Enabled = false;
        //    btnIletisimGuncelle.Enabled = true;
        //    btnIletisimSil.Enabled = true;
        //}

        //private void btnIletisimGuncelle_Click(object sender, EventArgs e)
        //{
        //    String sql = "UPDATE CONTACT SET STREET = :STREET," +
        //       "VILLAGE=:VILLAGE, CITY=:CITY, TEL_NUMBER=:TEL_NUMBER " +
        //       "WHERE CONTACT_ID = :CONTACT_ID";
        //    this.AUDIletisim(sql, 1);
        //}

        //private void btnIletisimSil_Click(object sender, EventArgs e)
        //{
        //    String sql = "DELETE FROM CONTACT " +
        //       "WHERE CONTACT_ID = :CONTACT_ID";
        //    this.AUDIletisim(sql, 2);
        //    this.resetAll();
        //}

        //private void btnIletisimReset_Click(object sender, EventArgs e)
        //{
        //    txtIletisimId.Text = "";
        //    txtIletisimCadde.Text = "";
        //    txtIletisimMahalle.Text = "";
        //    txtIletisimSehir.Text = "";
        //    txtIletisimTel.Text = "";
           


        //    btnIletisimEkle.Enabled = true;
        //    btnIletisimGuncelle.Enabled = false;
        //    btnIletisimSil.Enabled = false;
        //}

        //private void dgvIletisim_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int ind = e.RowIndex;
        //    DataGridViewRow selectedRows = dgvIletisim.Rows[ind];
        //    txtIletisimId.Text = selectedRows.Cells[0].Value.ToString();
        //    txtIletisimCadde.Text = selectedRows.Cells[1].Value.ToString();
        //    txtIletisimMahalle.Text = selectedRows.Cells[2].Value.ToString();
        //    txtIletisimSehir.Text = selectedRows.Cells[3].Value.ToString();
        //    txtIletisimTel.Text = selectedRows.Cells[4].Value.ToString();


        //    btnIletisimEkle.Enabled = false;
        //    btnIletisimGuncelle.Enabled = true;
        //    btnIletisimSil.Enabled = true;
        //}

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO K_USER (USERNAME,  PASSWORD, PRIVILIGESID) " +
                                    "VALUES(:USERNAME, :PASSWORD, :PRIVILIGESID)";
            this.AUDKullanici(sql, 0);
            if (chkSelect.Checked)
            {
                int yetki_id =1;
                //int kullanici_id =Int32.Parse(txtKullaniciId.Text);

                String sql2 = "INSERT INTO USER_PRIVILIGES(USER_ID, PRIVILIGES_ID) " +
                                    "VALUES(:USER_ID, :PRIVILIGES_ID)";
                this.AUDYetki(sql2, 0,yetki_id);
            }
            if (chkInsert.Checked)
            {
                int yetki_id = 2;
                //int kullanici_id = Int32.Parse(txtKullaniciId.Text);

                String sql2 = "INSERT INTO USER_PRIVILIGES(USER_ID, PRIVILIGES_ID) " +
                                    "VALUES(:USER_ID, :PRIVILIGES_ID)";
                this.AUDYetki(sql2, 0, yetki_id);
            }
            if (chkpdate.Checked)
            {
                int yetki_id = 3;
                //int kullanici_id = Int32.Parse(txtKullaniciId.Text);

                String sql2 = "INSERT INTO USER_PRIVILIGES(USER_ID, PRIVILIGES_ID) " +
                                    "VALUES(:USER_ID, :PRIVILIGES_ID)";
                this.AUDYetki(sql2, 0, yetki_id);
            }
            if (chkDelete.Checked)
            {
                int yetki_id = 4;
                //int kullanici_id = Int32.Parse(txtKullaniciId.Text);

                String sql2 = "INSERT INTO USER_PRIVILIGES(USER_ID, PRIVILIGES_ID) " +
                                    "VALUES(:USER_ID, :PRIVILIGES_ID)";
                this.AUDYetki(sql2, 0, yetki_id);
            }




            btnKullaniciEkle.Enabled = false;
            btnKullaniciGuncelle.Enabled = true;
            btnKullaniciReset.Enabled = true;
        }

        private void btnKullaniciGuncelle_Click(object sender, EventArgs e)
        {
            String sql = "UPDATE K_USER SET USERNAME = :USERNAME," +
               "PASSWORD=:PASSWORD, PRIVILIGESID=:PRIVILIGESID " +
               "WHERE USER_ID = :USER_ID";
            this.AUDKullanici(sql, 1);

            String sqlYetkiSil = "DELETE USER_PRIVILIGES "+
               "WHERE USER_ID = :USER_ID";
            this.AUDYetki(sqlYetkiSil, 2, 0 );



            if (chkSelect.Checked)
            {
                int yetki_id = 1;
                //int kullanici_id =Int32.Parse(txtKullaniciId.Text);

                String sql2 = "INSERT INTO USER_PRIVILIGES(USER_ID, PRIVILIGES_ID) " +
                                    "VALUES(:USER_ID, :PRIVILIGES_ID)";
                this.AUDYetki(sql2, 0, yetki_id);
            }
            if (chkInsert.Checked)
            {
                int yetki_id = 2;
                int kullanici_id = Int32.Parse(txtKullaniciId.Text);

                String sql2 = "INSERT INTO USER_PRIVILIGES(USER_ID, PRIVILIGES_ID) " +
                                    "VALUES(:USER_ID, :PRIVILIGES_ID)";
                this.AUDYetki(sql2, 0, yetki_id);
            }
            if (chkpdate.Checked)
            {
                int yetki_id = 3;
                int kullanici_id = Int32.Parse(txtKullaniciId.Text);

                String sql2 = "INSERT INTO USER_PRIVILIGES(USER_ID, PRIVILIGES_ID) " +
                                    "VALUES(:USER_ID, :PRIVILIGES_ID)";
                this.AUDYetki(sql2, 0, yetki_id);
            }
            if (chkDelete.Checked)
            {
                int yetki_id = 4;
                int kullanici_id = Int32.Parse(txtKullaniciId.Text);

                String sql2 = "INSERT INTO USER_PRIVILIGES(USER_ID, PRIVILIGES_ID) " +
                                    "VALUES(:USER_ID, :PRIVILIGES_ID)";
                this.AUDYetki(sql2, 0, yetki_id);
            }

        }



        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            String sql = "DELETE FROM K_USER " +
               "WHERE USER_ID = :USER_ID";
            this.AUDKullanici(sql, 2);

            this.resetAll();
        }

        private void btnKullaniciReset_Click(object sender, EventArgs e)
        {
            txtKullaniciId.Text = "";
            txtKullaniciAdi.Text = "";
            txtKullaniciSifre.Text = "";
            txtKullaniciYetkiAdi.Text = "";
            chkDelete.Checked = false;
            chkInsert.Checked = false;
            chkpdate.Checked = false;
            chkSelect.Checked = false;
            //txtIletisimTel.Text = "";



            btnKullaniciEkle.Enabled = true;
            btnKullaniciGuncelle.Enabled = false;
            btnKullaniciReset.Enabled = false;
        }

        private void dgvKullanici_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            chkSelect.Checked = false;
            chkInsert.Checked = false;
            chkpdate.Checked = false;
            chkDelete.Checked = false;



            conn.Close();
            conn.Open();
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dgvKullanici.Rows[ind];
            txtKullaniciId.Text = selectedRows.Cells[0].Value.ToString();
            txtKullaniciAdi.Text = selectedRows.Cells[1].Value.ToString();
            txtKullaniciSifre.Text = selectedRows.Cells[2].Value.ToString();
            txtKullaniciYetkiAdi.Text = selectedRows.Cells[3].Value.ToString();
            string sqlSelect = "SELECT * from USER_PRIVILIGES where USER_ID = " + txtKullaniciId.Text;
            OracleCommand cmd1 = new OracleCommand(sqlSelect, conn);
        
            
            
            List<string> Isimler = new List<string>();
  

            OracleDataReader reader1 = cmd1.ExecuteReader();


            while (reader1.Read())
            {
                Isimler.Add(reader1["PRIVILIGES_ID"].ToString());
                foreach (string element in Isimler)
                {

                    if (element == "1")
                    {
                        chkSelect.Checked = true;
                    }
                    else if (element =="2" )
                    {
                        chkInsert.Checked = true;
                    }
                    else if (element =="3")
                    {
                        chkpdate.Checked = true;
                    }
                    else chkDelete.Checked = true;


                }

            }





            btnKullaniciEkle.Enabled = false;
            btnKullaniciGuncelle.Enabled = true;
            btnKullaniciSil.Enabled = true;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel|*.xls", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                    IExcelDataReader okuyucu = ExcelReaderFactory.CreateBinaryReader(fs);
                    okuyucu.IsFirstRowAsColumnNames = true;
                    ds = okuyucu.AsDataSet();
                    foreach (DataTable dt in ds.Tables)
                    {
                        dgvOgrenci.DataSource = ds.Tables[dt.TableName];
                    }
                    okuyucu.Close();
                }
            }



            string oradb = "DATA SOURCE=localhost:1521/orcl;USER ID=harun;PASSWORD=harun";
            OracleConnection conn = new OracleConnection(oradb); // C#
            conn.Close();
            conn.Open();

            string sql = "SELECT MAX(STD_ID) as max from STUDENT ";
            OracleCommand cmdMAX = new OracleCommand(sql, conn);

            int BuyukId = 0;
            OracleDataReader readercmdMAX = cmdMAX.ExecuteReader();
            while (readercmdMAX.Read())
            {
                BuyukId = Int32.Parse(readercmdMAX["max"].ToString());
            }



            for (int index = 0; index < dgvOgrenci.RowCount - 1; index++)
            {


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO STUDENT(STD_ID, NAME, SURNAME, AGE, PARENT_ID, CLASS_ID) " + "VALUES(:STD_ID, :NAME, :SURNAME, :AGE, :PARENT_ID, :CLASS_ID)";
                cmd.Parameters.Add("STD_ID", OracleDbType.Int32, 38).Value = BuyukId + 1 + index;
                cmd.Parameters.Add("NAME", OracleDbType.Varchar2, 35).Value = Convert.ToString(dgvOgrenci.Rows[index].Cells[1].Value.ToString());
                cmd.Parameters.Add("SURNAME", OracleDbType.Varchar2, 35).Value = dgvOgrenci.Rows[index].Cells[2].Value.ToString();
                cmd.Parameters.Add("AGE", OracleDbType.Varchar2, 20).Value = dgvOgrenci.Rows[index].Cells[3].Value.ToString();
                cmd.Parameters.Add("PARENT_ID", OracleDbType.Int32, 38).Value = Convert.ToInt32(dgvOgrenci.Rows[index].Cells[4].Value.ToString());
                cmd.Parameters.Add("CLASS_ID", OracleDbType.Int32, 38).Value = Convert.ToInt32(dgvOgrenci.Rows[index].Cells[5].Value.ToString());

                cmd.ExecuteNonQuery();
             
           

            }


            this.OgrenciDataGrid();
        }




        private void btnWordExport_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            MudurPanel m = new MudurPanel();
            this.Hide();
            m.Show();
        }

        private void btnYedekle_Click(object sender, EventArgs e)
        {
            //## Settings
            //Path to store the oracle dump
            string path = @"C:\backup";
            string backupFileName = "mybackup.dmp";
            //your ORACLE_HOME enviroment variable must be setted or you need to set the path here:
            string oracleHome = Environment.GetEnvironmentVariable("C:\app\app\\product\\12.2.0\\dbhome_1");
            string oracleUser = "harun";
            string oraclePassword = "harun";
            string oracleSID = "orcl";
            //###

            ProcessStartInfo psi = new ProcessStartInfo();

            //Exp is the tool used to export data.
            //this tool is inside $ORACLE_HOME\bin directory
            psi.FileName = Path.Combine(oracleHome, "bin", "exp");
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;
            string dumpFile = Path.Combine(path, backupFileName);
            //The command line is: exp user/password@database file=backupname.dmp [OPTIONS....]
            psi.Arguments = string.Format(oracleUser + "/" + oraclePassword + "@" + oracleSID + " FULL=y FILE=" + dumpFile);
            psi.UseShellExecute = false;

            Process process = Process.Start(psi);
            process.WaitForExit();
            process.Close();
            MessageBox.Show("Database Backup Completed Successfully");
            this.Close();
        }

        private void btnOgrenciRapor_Click(object sender, EventArgs e)
        {
           
            Raporlar admin = new Raporlar();
            admin.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            MainWindow mn = new MainWindow();
            this.Hide();
           
            mn.Show();
        }
    }
}
