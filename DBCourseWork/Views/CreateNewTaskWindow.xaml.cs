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
    /// Логика взаимодействия для CreateNewTaskWindow.xaml
    /// </summary>
    public partial class CreateNewTaskWindow : Window
    {
        private ReAaContext _context;
        public CreateNewTaskWindow(ReAaContext context)
        {
            InitializeComponent();
            _context = context;

            cb_Workers.ItemsSource = _context.Users.Where(u => u.Role.Name != "admin").ToList();
            cb_Orders.ItemsSource = _context.Orders.ToList();
        }
        private void bt_Create_Click_1(object sender, RoutedEventArgs e)
        {
            Models.Task newTask = new()
            {
                Order = (Order)cb_Orders.SelectedItem,
                Name = tb_Stage.Text,
                Parts = tb_Parts.Text,
                Workplace = int.Parse(tb_Workplace.Text),
                Worker = (User)cb_Workers.SelectedItem
            };

            _context.Tasks.Add(newTask);
            _context.SaveChanges();

            DialogResult = true;
            return;
        }
    }
}
