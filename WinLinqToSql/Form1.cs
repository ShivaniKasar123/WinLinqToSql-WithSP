using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinLinqToSql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void DisplayDetails() 
        {
            var dd = dc.sp_tblEmployee();
            dataGridView1.DataSource = dd; 
        }

        empDataClassDataContext dc = new empDataClassDataContext();
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayDetails();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var iD = dc.sp_InsertEmp(textBoxName.Text,double.Parse(textBoxSal.Text));
            dc.SubmitChanges();
            MessageBox.Show("Data Inserted successfully");
            DisplayDetails();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var uD = dc.sp_UpdateEmp(int.Parse(textBoxId.Text), textBoxName.Text, Convert.ToSingle(textBoxSal.Text));
            dc.SubmitChanges();
            MessageBox.Show("Data Updated successfully");
            DisplayDetails();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var dD = dc.sp_DeleteEmp(int.Parse(textBoxId.Text));
            dc.SubmitChanges();
            MessageBox.Show("Data Deleted successfully");
            DisplayDetails();
        }
    }
}
