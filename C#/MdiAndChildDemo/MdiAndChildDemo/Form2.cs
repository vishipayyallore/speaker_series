using System;
using System.Windows.Forms;

namespace MdiAndChildDemo
{
    public partial class Form2 : Form
    {

        Form3 form3;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form3 = new Form3();
            form3.MdiParent = this.MdiParent;
            form3.Show();

            this.Close();
            this.Dispose();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
