using task2;

namespace task1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly HelloService _service = new HelloService();

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Length > 0 ? textBox1.Text : "Guest";
            string message = _service.GetMessage(username);

            MessageBox.Show(message);
        }
    }
}
