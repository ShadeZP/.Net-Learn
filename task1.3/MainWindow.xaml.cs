using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using task2;

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

        private readonly HelloService _service = new();

        private void OnClick(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text.Length > 0 ? UsernameBox.Text : "Guest";
            string message = _service.GetMessage(username);

            MessageBox.Show($"Hello, {message}");
        }
    }
}