using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
