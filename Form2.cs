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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          EmployeeDBDataContext dc=new EmployeeDBDataContext();
            if (textBox1.ReadOnly == false)
            { 
             Employee obj=new Employee();
            obj.Id=int.Parse(textBox1.Text);
            obj.Name=textBox2.Text;
            obj.Job=textBox3.Text;
            obj.Salary=int.Parse(textBox4.Text);
            dc.Employees.InsertOnSubmit(obj);
            dc.SubmitChanges();
            MessageBox.Show("Record inserted to the table.");
            }
            else
            {
                Employee obj=dc.Employees.SingleOrDefault(E=>E.Id==int.Parse(textBox1.Text));
                obj.Name =textBox2.Text;
                obj.Job=textBox3.Text;
                obj.Salary =int.Parse(textBox1.Text);
                dc.SubmitChanges();
                MessageBox.Show("Record Updated Successfully!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(Control ctrl in this.Controls)
            {
                if(ctrl is TextBox)
                {
                    TextBox tb = ctrl as TextBox;
                    tb.Clear();
                }
            }
            textBox1.Focus();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
