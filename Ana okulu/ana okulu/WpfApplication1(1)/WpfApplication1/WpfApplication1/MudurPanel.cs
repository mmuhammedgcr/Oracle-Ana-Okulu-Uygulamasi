using Excel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfApplication1
{
    public partial class MudurPanel : Form
    {
        DataSet ds;
        OracleConnection con = null;
        public MudurPanel()
        {
            this.setConnection();
            InitializeComponent();
        }


        private void MudurPanel_Load(object sender, EventArgs e)
        {
            StudentDataGrid();
            TeacherDataGrid();
            VeliDataGrid();
            odemeDataGrid();


            cmbIletisimIdd();
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



        private void StudentDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM STUDENT";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvOgrenci.DataSource = dt;

            DataTable dt2 = new DataTable();
            OracleDataAdapter da2 = new OracleDataAdapter("select * from CLASS ", con);
            da2.Fill(dt2);
            cmbOgrenciClassId.ValueMember = "CLASS_ID";
            cmbOgrenciClassId.DisplayMember = "CLASS_NAME";
            cmbOgrenciClassId.DataSource = dt2;

            DataTable dt3 = new DataTable();
            OracleDataAdapter da3 = new OracleDataAdapter("select * from PARENT ", con);
            da3.Fill(dt3);
            cmbOgrenciParentId.ValueMember = "PARENT_ID";
            cmbOgrenciParentId.DisplayMember = "NAME";
            cmbOgrenciParentId.DataSource = dt3;

            dr.Close();
        }

        private void TeacherDataGrid()
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
        public void odemeDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM PAYMENT";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvOdeme.DataSource = dt;
            dr.Close();
        }
       
        private void VeliDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM VELI_ILETISIM_LISTESI";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvVeli.DataSource = dt;
            dr.Close();
        }
        

        private void cmbIletisimIdd()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT CONTACT_ID FROM CONTACT";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
           

        }


        private void resetOgrenciAll()
        {
            txtOgrenciId.Text = "";
            txtOgrenciAd.Text = "";
            txtOgrenciSoyad.Text = "";
            txtOgrenciYas.Text = "";

            cmbOgrenciParentId.Text = "";
            cmbOgrenciClassId.Text = "";


            btnOgrenciEkle.Enabled = true;
            btnOgrenciGuncelle.Enabled = false;
            btnOgrenciSil.Enabled = false;
        }
        private void resetOgretmenAll()
        {
            txtOgretmenId.Text = "";
            txtOgretmenAd.Text = "";
            txtOgretmenSoyad.Text = "";
            txtOgretmenCinsiyet.Text = "";
            txtOgretmenCadde.Text = "";
            txtOgretmenMahalle.Text = "";
            txtOgretmenSehir.Text = "";
            txtOgretmenTel.Text = "";

            btnOgretmenEkle.Enabled = true;
            btnOgretmenSil.Enabled = false;
            btnOgretmenGuncelle.Enabled = false;
        }


        private void AUDIletisimVeli(String sql_stmt, int state)
        {
            String msg = "";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;
            string oradb = "DATA SOURCE=localhost:1521/orcl;USER ID=harun;PASSWORD=harun";
            OracleConnection conn = new OracleConnection(oradb); // C#
            conn.Open();
            string sql_iletisim = "SELECT CONTACT_ID from CONTACT WHERE TEL_NUMBER='" + txtVeliTel.Text.ToString() + "'";
            OracleCommand cmd_iletisim = new OracleCommand(sql_iletisim, conn);

            int iletisim_id=0;
            OracleDataReader readercmd_iletisim = cmd_iletisim.ExecuteReader();
            while (readercmd_iletisim.Read())
            {
                iletisim_id = Int32.Parse(readercmd_iletisim["CONTACT_ID"].ToString());
            }

            switch (state)
            {
                case 0:
                    msg = "Ekleme Başarılı";
                    //d.Parameters.Add("CONTACT_ID", OracleDbType.Int32, 38).Value = Convert.ToInt32(txtIletisimId.Text);
                    cmd.Parameters.Add("STREET", OracleDbType.Varchar2, 20).Value = txtVeliCadde.Text;
                    cmd.Parameters.Add("VILLAGE", OracleDbType.Varchar2, 20).Value = txtVeliMahalle.Text;
                    cmd.Parameters.Add("CITY", OracleDbType.Varchar2, 20).Value = txtVeliSehir.Text;
                    cmd.Parameters.Add("TEL_NUMBER", OracleDbType.Varchar2, 20).Value = txtVeliTel.Text;


                    //cmd.Parameters.Add("CLASSID", OracleDbType.Int32).Value = cmbOgrenciSinif.SelectedIndex;


                    break;
                case 1:
                    msg = "Güncelleme Başarılı";

                    cmd.Parameters.Add("STREET", OracleDbType.Varchar2, 20).Value = txtVeliCadde.Text;
                    cmd.Parameters.Add("VILLAGE", OracleDbType.Varchar2, 20).Value = txtVeliMahalle.Text;
                    cmd.Parameters.Add("CITY", OracleDbType.Varchar2, 20).Value = txtVeliSehir.Text;
                    cmd.Parameters.Add("TEL_NUMBER", OracleDbType.Varchar2, 20).Value = txtVeliTel.Text;
                    cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32, 38).Value = iletisim_id;

                    break;
                case 2:
                    msg = "Row Deleted Successfully!";

                    //cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32, 38).Value = Int32.Parse(txtIletisimId.Text);

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
        private void AUDIletisimOgretmen(String sql_stmt, int state)
        {
            String msg = "";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;
            string oradb = "DATA SOURCE=localhost:1521/orcl;USER ID=harun;PASSWORD=harun";
            OracleConnection conn = new OracleConnection(oradb); // C#
            conn.Open();
            string sql_iletisim = "SELECT CONTACT_ID from CONTACT WHERE TEL_NUMBER='" + txtVeliTel.Text.ToString() + "'";
            OracleCommand cmd_iletisim = new OracleCommand(sql_iletisim, conn);

            int iletisim_id = 0;
            OracleDataReader readercmd_iletisim = cmd_iletisim.ExecuteReader();
            while (readercmd_iletisim.Read())
            {
                iletisim_id = Int32.Parse(readercmd_iletisim["CONTACT_ID"].ToString());
            }

            switch (state)
            {
                case 0:
                    msg = "Ekleme Başarılı";
                    //d.Parameters.Add("CONTACT_ID", OracleDbType.Int32, 38).Value = Convert.ToInt32(txtIletisimId.Text);
                    cmd.Parameters.Add("STREET", OracleDbType.Varchar2, 20).Value = txtOgretmenCadde.Text;
                    cmd.Parameters.Add("VILLAGE", OracleDbType.Varchar2, 20).Value = txtOgretmenMahalle.Text;
                    cmd.Parameters.Add("CITY", OracleDbType.Varchar2, 20).Value = txtOgretmenSehir.Text;
                    cmd.Parameters.Add("TEL_NUMBER", OracleDbType.Varchar2, 20).Value = txtOgretmenTel.Text;


                    //cmd.Parameters.Add("CLASSID", OracleDbType.Int32).Value = cmbOgrenciSinif.SelectedIndex;


                    break;
                case 1:
                    msg = "Güncelleme Başarılı";

                    cmd.Parameters.Add("STREET", OracleDbType.Varchar2, 20).Value = txtOgretmenCadde.Text;
                    cmd.Parameters.Add("VILLAGE", OracleDbType.Varchar2, 20).Value = txtOgretmenMahalle.Text;
                    cmd.Parameters.Add("CITY", OracleDbType.Varchar2, 20).Value = txtOgretmenSehir.Text;
                    cmd.Parameters.Add("TEL_NUMBER", OracleDbType.Varchar2, 20).Value = txtOgretmenTel.Text;
                    cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32, 38).Value = txtOgretmenContactId.Text;

                    break;
                case 2:
                    msg = "Row Deleted Successfully!";

                    //cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32, 38).Value = Int32.Parse(txtIletisimId.Text);

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



        private void btnOgrenciEkle_Click(object sender, EventArgs e)
        {

          


            String sql = "INSERT INTO STUDENT(NAME, SURNAME, AGE, CLASS_ID, PARENT_ID) " +
                                     "VALUES(:NAME, :SURNAME, :AGE, :CLASS_ID, :PARENT_ID)";
            this.AUDOgrenci(sql, 0);
            btnOgrenciEkle.Enabled = false;
            btnOgrenciGuncelle.Enabled = true;
            btnOgrenciSil.Enabled = true;
        }
        private void btnOgrenciGuncelle_Click_1(object sender, EventArgs e)
        {

            String sql = "UPDATE STUDENT SET NAME = :NAME," +
               "SURNAME=:SURNAME, AGE=:AGE, CLASS_ID=:CLASS_ID, PARENT_ID=:PARENT_ID " +
               "WHERE STD_ID = :STD_ID";
            this.AUDOgrenci(sql, 1);
        }
        private void btnOgrenciSil_Click_1(object sender, EventArgs e)
        {
            String sql = "DELETE FROM STUDENT " +
                "WHERE STD_ID = :STD_ID";
            this.AUDOgrenci(sql, 2);
            this.resetOgrenciAll();
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
               "SURNAME=:SURNAME, AGE=:AGE, CONTACT_ID=:CONTACT_ID " +
               "WHERE TEACHER_ID = :TEACHER_ID";
            this.AUDOgretmen(sql, 1);
        }
        private void btnOgretmenSil_Click(object sender, EventArgs e)
        {
            String sql = "DELETE FROM TEACHER " +
               "WHERE TEACHER_ID = :TEACHER_ID";
            this.AUDOgretmen(sql, 2);
            this.resetOgretmenAll();
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
                    msg = "Katıt ekleme işlemimi başarılı bir şekilde gerçekleşti.";
                    //cmd.Parameters.Add("STD_ID", OracleDbType.Int32, 6).Value = Int32.Parse(txtOgrenciId.Text);
                    cmd.Parameters.Add("NAME", OracleDbType.Varchar2, 35).Value = txtOgrenciAd.Text;
                    cmd.Parameters.Add("SURNAME", OracleDbType.Varchar2, 35).Value = txtOgrenciSoyad.Text;
                    cmd.Parameters.Add("AGE", OracleDbType.Varchar2, 20).Value = txtOgrenciYas.Text;
                    cmd.Parameters.Add("CLASS_ID", OracleDbType.Int32).Value = cmbOgrenciClassId.SelectedValue;
                    cmd.Parameters.Add("PARENT_ID", OracleDbType.Int32).Value = cmbOgrenciParentId.SelectedValue;

                    //cmd.Parameters.Add("CLASSID", OracleDbType.Int32).Value = cmbOgrenciSinif.SelectedIndex;


                    break;
                case 1:
                    msg = "Güncelleme işlemimi başarılı bir şekilde gerçekleşti.";
                    cmd.Parameters.Add("NAME", OracleDbType.Varchar2, 35).Value = txtOgrenciAd.Text;
                    cmd.Parameters.Add("SURNAME", OracleDbType.Varchar2, 35).Value = txtOgrenciSoyad.Text;
                    cmd.Parameters.Add("AGE", OracleDbType.Varchar2, 20).Value = txtOgrenciYas.Text;
                    cmd.Parameters.Add("CLASS_ID", OracleDbType.Int32).Value = Convert.ToInt32(cmbOgrenciClassId.Text);
                    cmd.Parameters.Add("PARENT_ID", OracleDbType.Int32).Value = Convert.ToInt32(cmbOgrenciParentId.Text);
                    cmd.Parameters.Add("STD_ID", OracleDbType.Int32, 6).Value = Int32.Parse(txtOgrenciId.Text);

                    break;
                case 2:
                    msg = "Silme işlemimi başarılı bir şekilde gerçekleşti.";

                    cmd.Parameters.Add("STD_ID", OracleDbType.Int32).Value = Int32.Parse(txtOgrenciId.Text);

                    break;
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.StudentDataGrid();
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

                    msg = "Kayıt işlemi başarılı bir şekilde gerçekleşti.";
                    //cmd.Parameters.Add("TEACHER_ID", OracleDbType.Int32, 6).Value = Int32.Parse(txtOgretmenId.Text);
                    cmd.Parameters.Add("NAME", OracleDbType.Varchar2, 35).Value = txtOgretmenAd.Text;
                    cmd.Parameters.Add("SURNAME", OracleDbType.Varchar2, 35).Value = txtOgretmenSoyad.Text;
                    cmd.Parameters.Add("AGE", OracleDbType.Varchar2, 20).Value = txtOgretmenCinsiyet.Text;
                    cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32).Value = BuyukId;


                    //cmd.Parameters.Add("CLASSID", OracleDbType.Int32).Value = cmbOgrenciSinif.SelectedIndex;


                    break;
                case 1:
                    msg = "Güncelleme işlemi başarılı bir şekilde gerçekleşti.";
                    
                    cmd.Parameters.Add("NAME", OracleDbType.Varchar2, 35).Value = txtOgretmenAd.Text;
                    cmd.Parameters.Add("SURNAME", OracleDbType.Varchar2, 35).Value = txtOgretmenSoyad.Text;
                    cmd.Parameters.Add("AGE", OracleDbType.Varchar2, 20).Value = txtOgretmenCinsiyet.Text;
                    cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32).Value = txtOgretmenContactId.Text;
                    cmd.Parameters.Add("TEACHER_ID", OracleDbType.Int32, 6).Value = txtOgretmenId.Text;

                    break;
                case 2:
                    msg = "Silme işlemi başarılı bir şekilde gerçekleşti.";

                    cmd.Parameters.Add("TEACHER_ID", OracleDbType.Int32, 6).Value = Int32.Parse(txtOgretmenId.Text);

                    break;
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.TeacherDataGrid();
                }
            }
            catch (Exception expe) { }
        }



        private void dgvOgrenci_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dgvOgrenci.Rows[ind];
            txtOgrenciId.Text = selectedRows.Cells[0].Value.ToString();
            txtOgrenciAd.Text = selectedRows.Cells[1].Value.ToString();
            txtOgrenciSoyad.Text = selectedRows.Cells[2].Value.ToString();
            txtOgrenciYas.Text = selectedRows.Cells[3].Value.ToString();
            cmbOgrenciParentId.Text = selectedRows.Cells[4].Value.ToString();
            cmbOgrenciClassId.Text = selectedRows.Cells[5].Value.ToString();
            
            //cmbOgrenciSinif.Text = selectedRows.Cells[4].Value.ToString();
            //txtorderquantity.Text = selectedRows.Cells[4].Value.ToString();

            btnOgrenciEkle.Enabled = false;
            btnOgrenciGuncelle.Enabled = true;
            btnOgrenciSil.Enabled = true;

        }
        private void dgvOgretmen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dgvOgretmen.Rows[ind];
            txtOgretmenId.Text = selectedRows.Cells[0].Value.ToString();
            txtOgretmenAd.Text = selectedRows.Cells[1].Value.ToString();
            txtOgretmenSoyad.Text = selectedRows.Cells[2].Value.ToString();
            txtOgretmenCinsiyet.Text = selectedRows.Cells[3].Value.ToString();
            txtOgretmenContactId.Text = selectedRows.Cells[4].Value.ToString();

            btnOgretmenEkle.Enabled = false;
            btnOgretmenGuncelle.Enabled = true;
            btnOgretmenSil.Enabled = true;

        }



        private void btnOgrenciReset_Click(object sender, EventArgs e)
        {
            resetOgrenciAll();
        }
        private void btnOgretmenReset_Click(object sender, EventArgs e)
        {
            resetOgretmenAll();
        
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
                //con.Close();
               // con.Open();

           
            }
            this.StudentDataGrid();
            MessageBox.Show("İmport İşlemi Başarlı Bir Şekilde Gerçekleşti");

        }

        private void btnWord_Click(object sender, EventArgs e)
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

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

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
                    //cmd.Parameters.Add("PARENT_ID", OracleDbType.Int32, 38).Value = Int32.Parse(txtVeliId.Text);
                    cmd.Parameters.Add("NAME", OracleDbType.Varchar2, 20).Value = txtVeliAd.Text;
                    cmd.Parameters.Add("SURNAME", OracleDbType.Varchar2, 20).Value = txtVeliSoyad.Text;
                    cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32, 38).Value = BuyukId;
                    //cmd.Parameters.Add("AGE", OracleDbType.Varchar2, 20).Value = txtOgrenciYas.Text;
                    //cmd.Parameters.Add("CLASS_ID", OracleDbType.Int32).Value = Convert.ToInt32(txtOgrenciSinifId.Text);
                    //cmd.Parameters.Add("PARENT_ID", OracleDbType.Int32).Value = Convert.ToInt32(txtOgrenciVeliId.Text);
                    //cmd.Parameters.Add("CLASSID", OracleDbType.Int32).Value = cmbOgrenciSinif.SelectedIndex;


                    break;
                case 1:
                    msg = "Güncelleme Başarılı";
                    cmd.Parameters.Add("NAME", OracleDbType.Varchar2, 20).Value = txtVeliAd.Text;
                    cmd.Parameters.Add("SURNAME", OracleDbType.Varchar2, 20).Value = txtVeliSoyad.Text;
                    //cmd.Parameters.Add("CONTACT_ID", OracleDbType.Int32, 38).Value = Convert.ToInt32(txtVeliContactId.Text);
                    //cmd.Parameters.Add("AGE", OracleDbType.Varchar2, 20).Value = txtOgrenciYas.Text;
                    //cmd.Parameters.Add("CLASS_ID", OracleDbType.Int32).Value = Convert.ToInt32(txtOgrenciSinifId.Text);
                    //cmd.Parameters.Add("PARENT_ID", OracleDbType.Int32).Value = Convert.ToInt32(txtOgrenciVeliId.Text);
                    cmd.Parameters.Add("PARENT_ID", OracleDbType.Int32, 38).Value = Int32.Parse(txtVeliId.Text);

                    break;
                case 2:
                    msg = "Row Deleted Successfully!";

                    cmd.Parameters.Add("PARENT_ID", OracleDbType.Int32, 38).Value = Int32.Parse(txtVeliId.Text);

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
        private void btnVeliEkle_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO CONTACT(STREET,  VILLAGE, CITY, TEL_NUMBER) " +
                                  "VALUES(:STREET, :VILLAGE, :CITY, :TEL_NUMBER)";
            this.AUDIletisimVeli(sql, 0);

            String sql2 = "INSERT INTO PARENT (NAME, SURNAME, CONTACT_ID) " +
                                    "VALUES(:NAME, :SURNAME, :CONTACT_ID)";
            this.AUDVeli(sql2, 0);
            btnVeliEkle.Enabled = false;
            btnVeliGuncelle.Enabled = true;
            btnVeliSil.Enabled = true;
        }

        private void btnVeliReset_Click(object sender, EventArgs e)
        {
            txtVeliId.Text = "";
            txtVeliAd.Text = "";
            txtVeliSoyad.Text = "";
            txtVeliCadde.Text = "";
            txtVeliMahalle.Text = "";
            txtVeliCadde.Text = "";
            txtVeliCadde.Text = "";
            txtVeliTel.Text = "";
            txtVeliSehir.Text = "";


            btnVeliEkle.Enabled = true;
            btnVeliGuncelle.Enabled = false;
            btnVeliReset.Enabled = false;
        }

        private void btnVeliSil_Click(object sender, EventArgs e)
        {

        }

        private void dgvVeli_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dgvVeli.Rows[ind];
            txtVeliId.Text = selectedRows.Cells[0].Value.ToString();
            txtVeliAd.Text = selectedRows.Cells[1].Value.ToString();
            txtVeliSoyad.Text = selectedRows.Cells[2].Value.ToString();
            txtVeliCadde.Text = selectedRows.Cells[3].Value.ToString();
            txtVeliMahalle.Text = selectedRows.Cells[4].Value.ToString();
            txtVeliSehir.Text = selectedRows.Cells[5].Value.ToString();
            txtVeliTel.Text = selectedRows.Cells[6].Value.ToString();

            //cmbOgrenciSinif.Text = selectedRows.Cells[4].Value.ToString();
            //txtorderquantity.Text = selectedRows.Cells[4].Value.ToString();

            btnVeliEkle.Enabled = false;
            btnVeliGuncelle.Enabled = true;
            btnVeliSil.Enabled = true;
        }

        private void btnVeliGuncelle_Click(object sender, EventArgs e)
        {
            String sql = "UPDATE CONTACT SET STREET = :STREET," +
               "VILLAGE=:VILLAGE, CITY=:CITY, TEL_NUMBER=:TEL_NUMBER " +
               "WHERE CONTACT_ID = :CONTACT_ID";
            this.AUDIletisimVeli(sql, 1);

            String sql2 = "UPDATE PARENT SET NAME = :NAME," +
              "SURNAME=:SURNAME, CONTACT_ID=:CONTACT_ID " +
              "WHERE PARENT_ID = :PARENT_ID";
            this.AUDVeli(sql2, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Raporlar rp = new Raporlar();
            rp.Show();
        }

        private void dgvOdeme_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dgvOdeme.Rows[ind];
            txtOdemeId.Text = selectedRows.Cells[0].Value.ToString();
            txtOdemeOgrenci.Text = selectedRows.Cells[1].Value.ToString();
            txtOdemeMiktar.Text = selectedRows.Cells[2].Value.ToString();
            

            btnOdemeEkle.Enabled = false;
            btnOdemeGuncelle.Enabled = true;
            btnOdemeSil.Enabled = true;
        }
    }
}
