using MySql.Data.MySqlClient;
using PMS_v1.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace PMS_v1.OOP_CC105
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            displayRecords();
        }

        public void displayRecords()
        {
            string sql = "select * from student";

            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchRecords(int.Parse(textBox1.Text));
        }

        public void searchRecords(int id)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "select * from student where ID='" + id + "'";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];

                    DataRow dr = ds.Tables[0].Rows[0];
                    textBox2.Text = dr["StudName"].ToString();
                    textBox3.Text = dr["Section"].ToString();
                }
            }
        }

        public void deleteRecord(int id)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "delete from student where ID='" + id + "'";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    dataGridView1.DataSource = ds.Tables;

                    displayRecords();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            displayRecords();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteRecord(int.Parse(textBox1.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateRecord(int.Parse(textBox1.Text));
        }

        public void updateRecord(int id) 
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "update student set StudName='"+textBox2.Text+"', Section='"+textBox3.Text+"' where ID='"+id+"'" ;

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    displayRecords();
     
                }
            }
        }

    }
}
