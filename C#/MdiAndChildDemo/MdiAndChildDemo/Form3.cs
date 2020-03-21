using System;
using System.Windows.Forms;

namespace MdiAndChildDemo
{
    public partial class Form3 : Form
    {
        Form2 form2;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.MdiParent = this.MdiParent;
            form2.Show();

            this.Close();
            this.Dispose();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
