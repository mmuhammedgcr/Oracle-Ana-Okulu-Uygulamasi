using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfApplication1
{
    public partial class Giris : Form
    {
        OracleConnection con = null;
        OleDbConnection conn = new OleDbConnection("DATA SOURCE=localhost:1521/orcl;USER ID=kindergartenDB;PASSWORD=harun");
        public Giris()
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

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullanici_adi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            //OracleCommand cmd = con.CreateCommand();
            //cmd.CommandText = "SELECT EMPLOYEE_ID, LAST_NAME, JOB_ID, HIRE_DATE, EMAIL FROM EMPLOYEES";

            string sql = "SELECT PRIVILIGESID from K_USER where USERNAME =" + kullanici_adi + " AND PASSWORD=" + sifre;
            OracleCommand cmd = new OracleCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            object val = cmd.ExecuteScalar();



            if (val.ToString() == "mudur")
            {
                this.Hide();
                MudurPanel mudur = new MudurPanel();
                mudur.Show();
            }
        }
    }
}
