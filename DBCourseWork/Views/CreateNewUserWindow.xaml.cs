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
using DBCourseWork.Models;

namespace DBCourseWork.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateNewUserWindow.xaml
    /// </summary>
    public partial class CreateNewUserWindow : Window
    {
        private ReAaContext _context;
        public CreateNewUserWindow(ReAaContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void bt_Create_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new()
            {
                Name = tb_Name.Text,
                password = tb_password.Text,
                Role = _context.Roles.FirstOrDefault(r => r.Name == "user")
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();

            DialogResult = true;
            return;
        }
    }
}
