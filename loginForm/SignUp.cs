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

namespace loginForm
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();



            //make the form center
            this.CenterToScreen();
            //make the form not resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            //foucs on username
            txt_usernamesignup.Focus();
        }


        SqlConnection conn = new SqlConnection(@"Data Source=ADMIN-PC\PROJECTMAYNHA;Initial Catalog=helloworld;Integrated Security=True;Encrypt=False");



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            string username = txt_usernamesignup.Text;
            string useremail = txt_useremail.Text;
            string userphone = txt_userSDT.Text;
            string userpassword = txt_userpasswordsignup.Text;
            string userconfirmpassword = txt_userpasswordconfirm.Text;
          
            try
            {


                if (userpassword == userconfirmpassword)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO LoginDataBase (UserName,Email,SDT,PassWord) VALUES ('" + username + "','" + useremail + "','" + userphone + "','" + userpassword + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Sign Up Successfull");
                    Form1 login = new Form1();
                    login.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Password and Confirm Password must be same");
                }

            }
            catch
            {
                if (username == "" || useremail == "" || userphone == "" || userpassword == "" || userconfirmpassword == "")
                {
                    MessageBox.Show("Please fill all the information");
                    return;
                }
            }
            finally
            {

            }
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }
    }
}
