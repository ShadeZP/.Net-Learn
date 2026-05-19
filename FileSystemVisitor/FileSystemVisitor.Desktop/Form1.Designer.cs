namespace FileSystemVisitor.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPath = new Label();
            txtPath = new TextBox();
            btnBrowse = new Button();
            btnSearch = new Button();
            lstResults = new ListBox();
            lblFilter = new Label();
            txtFilter = new TextBox();
            SuspendLayout();
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Location = new Point(40, 20);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(86, 20);
            lblPath.TabIndex = 0;
            lblPath.Text = "Folder Path:";
            // 
            // txtPath
            // 
            txtPath.Location = new Point(132, 17);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(522, 27);
            txtPath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(660, 17);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(94, 29);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += BtnBrowse_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(309, 140);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(181, 29);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Start Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += BtnSearch_Click;
            // 
            // lstResults
            // 
            lstResults.FormattingEnabled = true;
            lstResults.Location = new Point(40, 209);
            lstResults.Name = "lstResults";
            lstResults.Size = new Size(714, 204);
            lstResults.TabIndex = 4;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(40, 67);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(45, 20);
            lblFilter.TabIndex = 5;
            lblFilter.Text = "Filter:";
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(132, 64);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(522, 27);
            txtFilter.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtFilter);
            Controls.Add(lblFilter);
            Controls.Add(lstResults);
            Controls.Add(btnSearch);
            Controls.Add(btnBrowse);
            Controls.Add(txtPath);
            Controls.Add(lblPath);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPath;
        private TextBox txtPath;
        private Button btnBrowse;
        private Button btnSearch;
        private ListBox lstResults;
        private Label lblFilter;
        private TextBox txtFilter;
    }
}
