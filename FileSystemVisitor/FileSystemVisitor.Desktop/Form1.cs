namespace FileSystemVisitor.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();

            if (string.IsNullOrWhiteSpace(txtPath.Text))
            {
                MessageBox.Show("Please select a folder first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filterText = txtFilter.Text.Trim();

            FileSystemVisitor.Core.FileSystemVisitor visitor;

            if (string.IsNullOrWhiteSpace(filterText))
            {
                visitor = new FileSystemVisitor.Core.FileSystemVisitor(txtPath.Text);
            }
            else
            {
                visitor = new FileSystemVisitor.Core.FileSystemVisitor(
                    txtPath.Text,
                    path => path.Contains(filterText, StringComparison.OrdinalIgnoreCase)
                );
            }

            foreach (var entry in visitor.EnumerateFileSystem())
            {
                lstResults.Items.Add(entry);
            }
        }
    }
}
