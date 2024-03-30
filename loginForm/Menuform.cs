using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace loginForm
{
    public partial class Menuform : Form
    {
        SqlConnection conn2 = new SqlConnection(@"Data Source=ADMIN-PC\PROJECTMAYNHA;Initial Catalog=QLBH;Integrated Security=True;Encrypt=False");
        private SqlCommand mySqlCommand;

        public Menuform()
        {
            

            InitializeComponent();

            this.CenterToScreen();
            string query2 = "SELECT * FROM tblVATTU";
            conn2.Open();
         
            mySqlCommand = new SqlCommand(query2, conn2);            
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            
            DataTable dtCategory = new DataTable();
            dtCategory.Load(mySqlDataReader);
            mySqlDataReader.Close();
            //Hiển thị lên lưới
            dataGridViewSQL.DataSource = dtCategory;




        }

   

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
      

    }
}
