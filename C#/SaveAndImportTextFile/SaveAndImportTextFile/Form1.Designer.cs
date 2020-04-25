namespace SaveAndImportTextFile
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveToText = new System.Windows.Forms.Button();
            this.btnImportFromText = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tubeDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtTubeOD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTubeWall = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnImportFromXml = new System.Windows.Forms.Button();
            this.btnSaveToXml = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tubeDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 16);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // btnSaveToText
            // 
            this.btnSaveToText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveToText.ForeColor = System.Drawing.Color.Blue;
            this.btnSaveToText.Location = new System.Drawing.Point(35, 114);
            this.btnSaveToText.Name = "btnSaveToText";
            this.btnSaveToText.Size = new System.Drawing.Size(137, 39);
            this.btnSaveToText.TabIndex = 1;
            this.btnSaveToText.Text = "Save To Text";
            this.btnSaveToText.UseVisualStyleBackColor = true;
            this.btnSaveToText.Click += new System.EventHandler(this.btnSaveToText_Click);
            // 
            // btnImportFromText
            // 
            this.btnImportFromText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportFromText.ForeColor = System.Drawing.Color.Blue;
            this.btnImportFromText.Location = new System.Drawing.Point(181, 114);
            this.btnImportFromText.Name = "btnImportFromText";
            this.btnImportFromText.Size = new System.Drawing.Size(156, 39);
            this.btnImportFromText.TabIndex = 2;
            this.btnImportFromText.Text = "Import from Text";
            this.btnImportFromText.UseVisualStyleBackColor = true;
            this.btnImportFromText.Click += new System.EventHandler(this.btnImportFromText_Click);
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tubeDataBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "No Name"));
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(148, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(202, 23);
            this.txtName.TabIndex = 3;
            this.txtName.Text = "Sample Name";
            // 
            // tubeDataBindingSource
            // 
            this.tubeDataBindingSource.DataSource = typeof(SaveAndImportTextFile.TubeData);
            // 
            // txtTubeOD
            // 
            this.txtTubeOD.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tubeDataBindingSource, "TubeOD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0"));
            this.txtTubeOD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTubeOD.Location = new System.Drawing.Point(148, 42);
            this.txtTubeOD.Name = "txtTubeOD";
            this.txtTubeOD.Size = new System.Drawing.Size(202, 23);
            this.txtTubeOD.TabIndex = 5;
            this.txtTubeOD.Text = "4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 44);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Inner Tube OD:";
            // 
            // txtTubeWall
            // 
            this.txtTubeWall.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tubeDataBindingSource, "TubeWall", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0"));
            this.txtTubeWall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTubeWall.Location = new System.Drawing.Point(148, 71);
            this.txtTubeWall.Name = "txtTubeWall";
            this.txtTubeWall.Size = new System.Drawing.Size(202, 23);
            this.txtTubeWall.TabIndex = 7;
            this.txtTubeWall.Text = "12";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 73);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(128, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Inner Tube Wall:";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnImportFromXml
            // 
            this.btnImportFromXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportFromXml.ForeColor = System.Drawing.Color.Blue;
            this.btnImportFromXml.Location = new System.Drawing.Point(181, 169);
            this.btnImportFromXml.Name = "btnImportFromXml";
            this.btnImportFromXml.Size = new System.Drawing.Size(156, 39);
            this.btnImportFromXml.TabIndex = 9;
            this.btnImportFromXml.Text = "Import from Xml";
            this.btnImportFromXml.UseVisualStyleBackColor = true;
            this.btnImportFromXml.Click += new System.EventHandler(this.btnImportFromXml_Click);
            // 
            // btnSaveToXml
            // 
            this.btnSaveToXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveToXml.ForeColor = System.Drawing.Color.Blue;
            this.btnSaveToXml.Location = new System.Drawing.Point(35, 169);
            this.btnSaveToXml.Name = "btnSaveToXml";
            this.btnSaveToXml.Size = new System.Drawing.Size(137, 39);
            this.btnSaveToXml.TabIndex = 8;
            this.btnSaveToXml.Text = "Save To Xml";
            this.btnSaveToXml.UseVisualStyleBackColor = true;
            this.btnSaveToXml.Click += new System.EventHandler(this.btnSaveToXml_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 227);
            this.Controls.Add(this.btnImportFromXml);
            this.Controls.Add(this.btnSaveToXml);
            this.Controls.Add(this.txtTubeWall);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTubeOD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnImportFromText);
            this.Controls.Add(this.btnSaveToText);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Tube Data";
            ((System.ComponentModel.ISupportInitialize)(this.tubeDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveToText;
        private System.Windows.Forms.Button btnImportFromText;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtTubeOD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTubeWall;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.BindingSource tubeDataBindingSource;
        private System.Windows.Forms.Button btnImportFromXml;
        private System.Windows.Forms.Button btnSaveToXml;
    }
}

