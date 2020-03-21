using System;
using System.Windows.Forms;

namespace MdiAndChildDemo
{
    public partial class Form1 : Form
    {
        Form2 form2;
        Form3 form3;

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.MdiParent = this;
            form2.Show();
        }

        private void form3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form3 = new Form3();
            form3.MdiParent = this;
            form3.Show();
        }
    }
}
