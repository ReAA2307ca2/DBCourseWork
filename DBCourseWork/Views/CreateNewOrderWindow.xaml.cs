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
    /// Логика взаимодействия для CreateNewOrderWindow.xaml
    /// </summary>
    public partial class CreateNewOrderWindow : Window
    {
        private ReAaContext _context;
        public CreateNewOrderWindow(ReAaContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void bt_Create_Click(object sender, RoutedEventArgs e)
        {
            Client newClient = new()
            {
                Name = tb_clientName.Text
            };
            _context.Clients.Add(newClient);
            _context.SaveChanges();

            Order newOrder = new Order()
            {
                Client = _context.Clients.FirstOrDefault(c => c.Name == tb_clientName.Text),
                Description = tb_description.Text
            };
            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            DialogResult = true;
            return;
        }
    }
}
