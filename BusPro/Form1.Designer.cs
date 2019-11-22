namespace BusPro
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FileNameBox = new System.Windows.Forms.TextBox();
            this.BrowseFile = new System.Windows.Forms.Button();
            this.SignaturePathBox = new System.Windows.Forms.TextBox();
            this.BrowseSignature = new System.Windows.Forms.Button();
            this.BrowseKey = new System.Windows.Forms.Button();
            this.KeyFilePath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FileNameBox
            // 
            this.FileNameBox.Location = new System.Drawing.Point(13, 418);
            this.FileNameBox.Name = "FileNameBox";
            this.FileNameBox.ReadOnly = true;
            this.FileNameBox.Size = new System.Drawing.Size(679, 20);
            this.FileNameBox.TabIndex = 0;
            // 
            // BrowseFile
            // 
            this.BrowseFile.Location = new System.Drawing.Point(698, 418);
            this.BrowseFile.Name = "BrowseFile";
            this.BrowseFile.Size = new System.Drawing.Size(89, 22);
            this.BrowseFile.TabIndex = 1;
            this.BrowseFile.Text = "Znajdź plik";
            this.BrowseFile.UseVisualStyleBackColor = true;
            this.BrowseFile.Click += new System.EventHandler(this.BrowseFile_Click);
            // 
            // SignaturePathBox
            // 
            this.SignaturePathBox.Location = new System.Drawing.Point(14, 389);
            this.SignaturePathBox.Name = "SignaturePathBox";
            this.SignaturePathBox.ReadOnly = true;
            this.SignaturePathBox.Size = new System.Drawing.Size(678, 20);
            this.SignaturePathBox.TabIndex = 2;
            // 
            // BrowseSignature
            // 
            this.BrowseSignature.Location = new System.Drawing.Point(699, 389);
            this.BrowseSignature.Name = "BrowseSignature";
            this.BrowseSignature.Size = new System.Drawing.Size(89, 22);
            this.BrowseSignature.TabIndex = 3;
            this.BrowseSignature.Text = "Znajdź podpis";
            this.BrowseSignature.UseVisualStyleBackColor = true;
            this.BrowseSignature.Click += new System.EventHandler(this.BrowseSignature_Click);
            // 
            // BrowseKey
            // 
            this.BrowseKey.Location = new System.Drawing.Point(698, 360);
            this.BrowseKey.Name = "BrowseKey";
            this.BrowseKey.Size = new System.Drawing.Size(89, 22);
            this.BrowseKey.TabIndex = 5;
            this.BrowseKey.Text = "Znajdź klucz";
            this.BrowseKey.UseVisualStyleBackColor = true;
            this.BrowseKey.Click += new System.EventHandler(this.BrowseKey_Click);
            // 
            // KeyFilePath
            // 
            this.KeyFilePath.Location = new System.Drawing.Point(14, 360);
            this.KeyFilePath.Name = "KeyFilePath";
            this.KeyFilePath.ReadOnly = true;
            this.KeyFilePath.Size = new System.Drawing.Size(678, 20);
            this.KeyFilePath.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 148);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(441, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(258, 142);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BrowseKey);
            this.Controls.Add(this.KeyFilePath);
            this.Controls.Add(this.BrowseSignature);
            this.Controls.Add(this.SignaturePathBox);
            this.Controls.Add(this.BrowseFile);
            this.Controls.Add(this.FileNameBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox FileNameBox;
        private System.Windows.Forms.Button BrowseFile;
        private System.Windows.Forms.TextBox SignaturePathBox;
        private System.Windows.Forms.Button BrowseSignature;
        private System.Windows.Forms.Button BrowseKey;
        private System.Windows.Forms.TextBox KeyFilePath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}

