using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeCrudOperationLinq
{
    public partial class Form1 : Form
    {
        EmployeeDBDataContext dc;
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadData()
        {
            dc = new EmployeeDBDataContext();
            dataGridView1.DataSource = dc.Employees;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f=new Form2();
            f.ShowDialog();
            LoadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0)
            {
            Form2 f=new Form2();
            f.textBox1.ReadOnly = true;
                f.button2.Enabled = false;
                f.button1.Text = "Update";
            f.textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            f.textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            f.textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            f.textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            f.ShowDialog();
                LoadData();
            }
            else
            {
                MessageBox.Show("Please Select Record for updation!!","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if(MessageBox.Show("Are youy sure of deleting the selected record?", "Confiramation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int eno = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    Employee obj = dc.Employees.SingleOrDefault(E => E.Id == eno);
                    dc.Employees.DeleteOnSubmit(obj);
                    dc.SubmitChanges();
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please Select Record for deletion!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
