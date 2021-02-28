using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDemo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpened = checkFormOpened("Form1");
            if (!isOpened)
            {
                Form1 f1 = new Form1();
                f1.MdiParent = this;
                f1.Show();
            }
        }
        private bool checkFormOpened(String formName) {
            for(int i=0;i<this.MdiChildren.Length;i++) {
                if (this.MdiChildren[i].GetType().Name == formName) {
                    MessageBox.Show("The form is already opened", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.MdiChildren[i].Activate();
                    return true; 
                }
            }
            return false; 
        }
        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpened = checkFormOpened("Form2");
            if (!isOpened)
            {
                Form2 f2 = new Form2();
                f2.MdiParent = this;
                f2.Show();
            }
        }
    }
}
