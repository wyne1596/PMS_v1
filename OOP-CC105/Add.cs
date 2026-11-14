using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using PMS_v1.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PMS_v1.OOP_CC105
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT into student values(@id, @name, @section)";

            int id = int.Parse(textBox1.Text);
            string name = textBox2.Text;
            string section = textBox3.Text;

            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@section", section);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0) MessageBox.Show("Added");
                else MessageBox.Show("Not Added");
            }

        }
    }
}
