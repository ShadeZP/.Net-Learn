using SharedService;
using SharedServiceUtils;

namespace task1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly HelloService _helloService = new HelloService();
        private readonly NameService _nameService = new();

        private void button1_Click(object sender, EventArgs e)
        {
            string username = _nameService.GetName(textBox1.Text);
            string message = _helloService.GetMessage(username);

            MessageBox.Show(message);
        }
    }
}
