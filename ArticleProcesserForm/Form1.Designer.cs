namespace ArticleProcesserForm
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
            this.InputDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.OutputDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.InputDirectorySearchButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.OutputDirectorySearchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RunButton = new System.Windows.Forms.Button();
            this.CategoryListBox = new System.Windows.Forms.ListBox();
            this.KeyTermsListBox = new System.Windows.Forms.ListBox();
            this.OutputListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // InputDirectoryTextBox
            // 
            this.InputDirectoryTextBox.Location = new System.Drawing.Point(12, 35);
            this.InputDirectoryTextBox.Name = "InputDirectoryTextBox";
            this.InputDirectoryTextBox.Size = new System.Drawing.Size(300, 20);
            this.InputDirectoryTextBox.TabIndex = 0;
            // 
            // OutputDirectoryTextBox
            // 
            this.OutputDirectoryTextBox.Location = new System.Drawing.Point(13, 83);
            this.OutputDirectoryTextBox.Name = "OutputDirectoryTextBox";
            this.OutputDirectoryTextBox.Size = new System.Drawing.Size(300, 20);
            this.OutputDirectoryTextBox.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // InputDirectorySearchButton
            // 
            this.InputDirectorySearchButton.Location = new System.Drawing.Point(318, 33);
            this.InputDirectorySearchButton.Name = "InputDirectorySearchButton";
            this.InputDirectorySearchButton.Size = new System.Drawing.Size(154, 23);
            this.InputDirectorySearchButton.TabIndex = 3;
            this.InputDirectorySearchButton.Text = "Choose File";
            this.InputDirectorySearchButton.UseVisualStyleBackColor = true;
            this.InputDirectorySearchButton.Click += new System.EventHandler(this.InputDirectorySearchButton_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // OutputDirectorySearchButton
            // 
            this.OutputDirectorySearchButton.Location = new System.Drawing.Point(319, 81);
            this.OutputDirectorySearchButton.Name = "OutputDirectorySearchButton";
            this.OutputDirectorySearchButton.Size = new System.Drawing.Size(153, 23);
            this.OutputDirectorySearchButton.TabIndex = 4;
            this.OutputDirectorySearchButton.Text = "Choose Directory";
            this.OutputDirectorySearchButton.UseVisualStyleBackColor = true;
            this.OutputDirectorySearchButton.Click += new System.EventHandler(this.OutputDirectorySearchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Source File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Output Directory";
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(13, 123);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 7;
            this.RunButton.Text = "Run Search";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // CategoryListBox
            // 
            this.CategoryListBox.FormattingEnabled = true;
            this.CategoryListBox.Location = new System.Drawing.Point(13, 153);
            this.CategoryListBox.Name = "CategoryListBox";
            this.CategoryListBox.Size = new System.Drawing.Size(220, 199);
            this.CategoryListBox.TabIndex = 8;
            // 
            // KeyTermsListBox
            // 
            this.KeyTermsListBox.FormattingEnabled = true;
            this.KeyTermsListBox.Location = new System.Drawing.Point(252, 153);
            this.KeyTermsListBox.Name = "KeyTermsListBox";
            this.KeyTermsListBox.Size = new System.Drawing.Size(220, 199);
            this.KeyTermsListBox.TabIndex = 9;
            // 
            // OutputListBox
            // 
            this.OutputListBox.BackColor = System.Drawing.SystemColors.Menu;
            this.OutputListBox.ForeColor = System.Drawing.Color.Black;
            this.OutputListBox.FormattingEnabled = true;
            this.OutputListBox.HorizontalScrollbar = true;
            this.OutputListBox.Location = new System.Drawing.Point(487, 10);
            this.OutputListBox.Name = "OutputListBox";
            this.OutputListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.OutputListBox.Size = new System.Drawing.Size(485, 342);
            this.OutputListBox.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 361);
            this.Controls.Add(this.OutputListBox);
            this.Controls.Add(this.KeyTermsListBox);
            this.Controls.Add(this.CategoryListBox);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputDirectorySearchButton);
            this.Controls.Add(this.InputDirectorySearchButton);
            this.Controls.Add(this.OutputDirectoryTextBox);
            this.Controls.Add(this.InputDirectoryTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputDirectoryTextBox;
        private System.Windows.Forms.TextBox OutputDirectoryTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button InputDirectorySearchButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button OutputDirectorySearchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.ListBox CategoryListBox;
        private System.Windows.Forms.ListBox KeyTermsListBox;
        private System.Windows.Forms.ListBox OutputListBox;
    }
}

