using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDemo
{
    public partial class Form2 : Form
    {
        private BindingSource bindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private DataSet ds = new DataSet();
        private String connectionString =
                           "Integrated Security=SSPI;" +
                           "Initial Catalog=students;Data Source=localhost";
        private void BindingDataToComboBox()
        {
            try
            {
                string cmd = "Select *from Faculty";
                dataAdapter = new SqlDataAdapter(cmd, connectionString);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(ds, "Faculty");
                comboBox1.DataSource = ds.Tables["Faculty"];
                comboBox1.ValueMember = "ID";
                comboBox1.DisplayMember = "Name";
                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
                else
                    MessageBox.Show("There is no value in Faculty", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception se) {
                MessageBox.Show(se.Message);
            }
        }
        private void ComboBoxChange() { 
        
            if (comboBox1.Items.Count > 0)
            {
                try
                {
                    int cbValue = int.Parse(comboBox1.SelectedValue.ToString());
                    BindingDataToDataGridView(cbValue);
                }
                catch (Exception se) {
                }
            }
        }
        private void BindingDataToDataGridView(int facultyID)
        {
            try
            {
                if(ds.Tables.Count > 1)
                    ds.Tables["Students"].Clear();
                string cmd = "Select *from Students where FacultyID = '" + facultyID.ToString()
                    + "'";
                dataAdapter = new SqlDataAdapter(cmd, connectionString);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(ds, "Students");
                bindingSource.DataSource = ds.Tables["Students"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception se) {
                MessageBox.Show(se.Message);
            }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource;
            BindingDataToComboBox();
            ComboBoxChange();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxChange();
        }
    }
}
