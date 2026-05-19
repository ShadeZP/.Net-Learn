using System;
using System.Windows.Forms;
using FileSystemVisitor.Core;

namespace FileSystemVisitor.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                    txtPath.Text = folderDialog.SelectedPath;
            }
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();
            lblStatus.Text = "Search started";

            string filterText = txtFilter.Text.Trim();

            var visitor = string.IsNullOrWhiteSpace(filterText)
                ? new FileSystemVisitor.Core.FileSystemVisitor(txtPath.Text)
                : new FileSystemVisitor.Core.FileSystemVisitor(txtPath.Text, path =>
                    path.Contains(filterText, StringComparison.OrdinalIgnoreCase));

            visitor.FilteredFileFound += (s, e) =>
            {
                var args = (FileSystemVisitor.Core.FileSystemVisitorEventArgs)e;
                if (args.Path.EndsWith(".docx", StringComparison.OrdinalIgnoreCase))
                {
                    args.Abort = true;
                    lblStatus.Invoke(new Action(() => {
                        lblStatus.Text = "Aborted: .docx found!";
                    }));
                }
            };

            visitor.FilteredDirectoryFound += (s, e) =>
            {
                var args = (FileSystemVisitorEventArgs)e;
                if (args.Path.Contains("node_modules", StringComparison.OrdinalIgnoreCase))
                    args.Exclude = true;
            };

            visitor.FilteredFileFound += (s, e) =>
            {
                var args = (FileSystemVisitorEventArgs)e;
                if (args.Path.Contains("node_modules", StringComparison.OrdinalIgnoreCase))
                    args.Exclude = true;
            };

            int batchSize = 100;
            List<string> batch = new List<string>(batchSize);
            int totalCount = 0;

            try
            {
                await Task.Run(() =>
                {
                    foreach (var entry in visitor.EnumerateFileSystem())
                    {
                        batch.Add(entry);
                        totalCount++;
                        if (batch.Count >= batchSize)
                        {
                            lstResults.Invoke(new Action(() =>
                            {
                                foreach (var item in batch)
                                    lstResults.Items.Add(item);

                                lblStatus.Text = $"Processed: {totalCount}";
                            }));
                            batch.Clear();
                        }
                    }

                    if (batch.Count > 0)
                    {
                        lstResults.Invoke(new Action(() =>
                        {
                            foreach (var item in batch)
                                lstResults.Items.Add(item);

                            lblStatus.Text = $"Processed: {totalCount}";
                        }));
                    }
                });

                lblStatus.Text = $"Search finished. Total: {totalCount}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error!";
                MessageBox.Show("An error occurred:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}