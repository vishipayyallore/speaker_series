using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveAndImportTextFile
{
    public partial class Form1 : Form
    {
        public TubeData _tubeData;

        public Form1()
        {
            InitializeComponent();
            _tubeData = new TubeData
            {
                Name= "No Name", TubeWall = 1, TubeOD = 1
            };
            tubeDataBindingSource.DataSource = _tubeData;
        }

        private void btnSaveToText_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Get file name.
            string name = saveFileDialog1.FileName;

            // Write to the file name selected.
            File.WriteAllText(name, JsonConvert.SerializeObject(_tubeData));
        }

        private void btnImportFromText_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    string text = File.ReadAllText(openFileDialog1.FileName);
                    _tubeData = JsonConvert.DeserializeObject<TubeData>(text);
                    tubeDataBindingSource.DataSource = _tubeData;
                }
                catch (IOException ioException)
                {
                    MessageBox.Show(ioException.Message);
                }
            }
        }
    }

}
