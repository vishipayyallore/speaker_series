using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace SaveAndImportTextFile
{

    // Use this for saving files into XML https://www.newtonsoft.com/json/help/html/ConvertJsonToXml.htm
    public partial class Form1 : Form
    {
        private TubeData _tubeData;
        const string textFilePattern = "Text files (*.txt)|*.txt";
        const string xmlFilePattern = "Xml files (*.xml)|*.xml";

        public Form1()
        {
            InitializeComponent();
            _tubeData = new TubeData
            {
                Name = "No Name",
                TubeWall = 1,
                TubeOD = 1
            };
            tubeDataBindingSource.DataSource = _tubeData;
        }

        private void ShowFileSaveDialog(string filePattern, string title = "Save Tube Data as")
        {
            saveFileDialog1.Title = title;
            saveFileDialog1.Filter = filePattern;
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            saveFileDialog1.ShowDialog();
        }

        private void BtnSaveToText_Click(object sender, EventArgs e)
        {
            const string title = "Save Tube Data as Text File";

            ShowFileSaveDialog(textFilePattern, title);
        }

        private void BtnSaveToXml_Click(object sender, EventArgs e)
        {
            const string title = "Save Tube Data as Xml File";

            ShowFileSaveDialog(xmlFilePattern, title);
        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Get file name.
            string name = saveFileDialog1.FileName;

            var fileContent = JsonConvert.SerializeObject(_tubeData);

            if (saveFileDialog1.Filter.Contains("*.xml"))
            {
                XNode node = JsonConvert.DeserializeXNode(fileContent, "Root");
                fileContent = node.ToString();
            }

            // Write to the file name selected.
            File.WriteAllText(name, fileContent);
        }

        private string GetFileNameFromOpenDialog(string filePattern, string title = "Import Tube Data from")
        {
            string fileName = string.Empty;

            openFileDialog1.Filter = filePattern;
            openFileDialog1.Title = title;
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK) 
            {
                try
                {
                    fileName = openFileDialog1.FileName;
                }
                catch (IOException ioException)
                {
                    MessageBox.Show(ioException.Message);
                }
            }

            return fileName;
        }

        private void BtnImportFromText_Click(object sender, EventArgs e)
        {
            const string title = "Import Tube Data from Text File";
            string fileName = GetFileNameFromOpenDialog(textFilePattern, title);

            if(!string.IsNullOrWhiteSpace(fileName))
            {
                string text = File.ReadAllText(fileName);
                _tubeData = JsonConvert.DeserializeObject<TubeData>(text);
                tubeDataBindingSource.DataSource = _tubeData;
            }
        }

        private void BtnImportFromXml_Click(object sender, EventArgs e)
        {
            const string title = "Import Tube Data from Xml File";
            string fileName = GetFileNameFromOpenDialog(xmlFilePattern, title);

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                string fileContent = File.ReadAllText(fileName);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(fileContent);
                
                fileContent = JsonConvert.SerializeXmlNode(doc);
                JObject json = JObject.Parse(fileContent);
                _tubeData = JsonConvert.DeserializeObject<TubeData>(json.First.First.ToString());
                tubeDataBindingSource.DataSource = _tubeData;
            }
        }
    }

}
