using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data.OleDb;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OracleConnection con = null;
        OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521/orcl;USER ID=harun;PASSWORD=harun");
        
        public MainWindow()
        {

            //Form1 f = new Form1();
            //this.Hide();
            //f.Show();


            this.setConnection();
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            con.Close();
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

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            con = new OracleConnection(connectionString);
            try
            {
                con.Open();
            }
            catch (Exception exp) { }

            string yetki = "";
            string kullanici_adi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;


            string sql = "SELECT * from K_USER where USERNAME ='" + kullanici_adi + "' AND PASSWORD='" + sifre+"'";
           
            OracleCommand cmd = new OracleCommand(sql, con);
            OracleDataReader reader = cmd.ExecuteReader();
            OracleDataAdapter da = new OracleDataAdapter(cmd);

            
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                while (reader.Read())
                {
                    yetki = (string)reader["PRIVILIGESID"];
                    Sitatikler.kullanici_id = Int32.Parse(reader["USER_ID"].ToString());
                }

                if (yetki == "mudur")
                {
                    this.Hide();
                    MudurPanel mudur = new MudurPanel();
                    mudur.Show();
                }

                else if (yetki == "admin")
                {
                    this.Hide();
                    Form1 admin = new Form1();
                    admin.Show();
                }

                else
                {
                    this.Hide();
                    Form1 admin = new Form1();
                    admin.Show();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifrenizi Yanlış Girdiniz!");
                txtKullaniciAdi.Text = "";
                txtSifre.Text = "";
            }
            con.Close();
           
        }
        
    }
}
