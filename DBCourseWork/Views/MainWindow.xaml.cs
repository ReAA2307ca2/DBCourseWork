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
using DBCourseWork.Data;
using DBCourseWork.Views;

namespace DBCourseWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ReAaContext _context = new();
        
        public MainWindow()
        {
            if(UserCookies.LoggedUser == null)
            {
                RegisterWindow regWin = new RegisterWindow(_context);
                if(regWin.ShowDialog() != true)
                {
                    this.Close();
                }
            }
            InitializeComponent();
            
        }
    }
}