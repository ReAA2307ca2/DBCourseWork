using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DBCourseWork.Data;

namespace DBCourseWork.Views
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private ReAaContext _context;
        public RegisterWindow(ReAaContext context)
        {
            _context = context;

            InitializeComponent();
        }

        private void bt_login_Click(object sender, RoutedEventArgs e)
        {
            var user = _context.Employees.FirstOrDefault(user => user.Login == tb_login.Text && user.Password == tb_password.Text);
            if(user != null) {
                MessageBox.Show("User not found");
                return;
            }
            UserCookies.LoggedUser = user!;
            DialogResult = true;
            return;
        }
    }
}
