using DBCourseWork.Data;
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

namespace DBCourseWork.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateFurnitureWindow.xaml
    /// </summary>
    public partial class CreateFurnitureWindow : Window
    {
        ReAaContext _context;
        public CreateFurnitureWindow(ReAaContext context)
        {
            InitializeComponent();
            _context = context;

            cb_Order.ItemsSource = _context.Orders.ToList();
        }

        private void bt_CreateFurniture_Click(object sender, RoutedEventArgs e)
        {
            CreateFurnitureWindow newWin = new(_context);
            newWin.ShowDialog();
        }
    }
}
