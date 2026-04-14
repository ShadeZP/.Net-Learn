using SharedService;
using SharedServiceUtils;
using System.Windows;

namespace task1._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly HelloService _helloService = new();
        private readonly NameService _nameService = new();

        private void OnClick(object sender, RoutedEventArgs e)
        {
            string username = _nameService.GetName(UsernameBox.Text);
            string message = _helloService.GetMessage(username);

            MessageBox.Show($"Hello, {message}");
        }
    }
}