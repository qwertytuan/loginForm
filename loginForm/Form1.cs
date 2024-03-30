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
using System.Timers;

namespace loginForm
{

    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();


        }
        SqlConnection conn = new SqlConnection(@"Data Source=ADMIN-PC\PROJECTMAYNHA;Initial Catalog=helloworld;Integrated Security=True;Encrypt=False");
       
        private SqlCommand mySqlCommand;



        private void Form1_Load(object sender, EventArgs e)
        {

            //make the form center
            this.CenterToScreen();
            //make the form not resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //foucs on username
            txt_useremailorphone.Focus();

            //disable full screen
            this.MaximizeBox = false;
            this.MaximizeBox = false;
            txt_userpassword.UseSystemPasswordChar = true;


        }
 

        private void button1_Click(object sender, EventArgs e)
        {
          conn.Open();
            string useremailorphone = txt_useremailorphone.Text;
            string password = txt_userpassword.Text;
            string query = "SELECT * FROM LoginDataBase WHERE (Email = '" + useremailorphone + "' OR SDT='"+useremailorphone+"') AND PassWord = '" + password + "'";
            mySqlCommand = new SqlCommand(query, conn);
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            //kiểm tra UserName và Mật khẩu có đúng không
            if (mySqlDataReader.HasRows == false)
            {
                MessageBox.Show("Không đúng tài khoản hoặc mật khẩu đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mySqlDataReader.Close();
                txt_useremailorphone.Focus();
                return;
            }
           conn.Close();
          Menuform f = new Menuform();
            f.Show();
            this.Hide();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_useremailorphone.Clear();
            txt_userpassword.Clear();
            DialogResult dialogResult = MessageBox.Show("Do you want to exit?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                txt_useremailorphone.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SignUp signup = new SignUp();
            signup.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(check_show_hide_pass.Checked)
            {
                txt_userpassword.UseSystemPasswordChar = false;
            }
            else
            {
                txt_userpassword.UseSystemPasswordChar = true;
            }
        }
    }
}

