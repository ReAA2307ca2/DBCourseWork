using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
using DBCourseWork.Models;

namespace DBCourseWork.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для AdminUC.xaml
    /// </summary>
    public partial class AdminUC : UserControl, INotifyPropertyChanged
    {
        private ReAaContext _context;
        public AdminUC(ReAaContext context)
        {
            _context = context;
            InitializeComponent();

            lb_Workers.ItemsSource = _context.Users.Local.ToObservableCollection();
            lb_Orders.ItemsSource = _context.Orders.Local.ToObservableCollection();
            lb_Tasks.ItemsSource = _context.Tasks.Local.ToObservableCollection();
            lb_furniture.ItemsSource = _context.Furnitures.Local.ToObservableCollection();
            lb_Teams.ItemsSource = _context.Teams.Local.ToObservableCollection();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private void bt_createOrder_Click(object sender, RoutedEventArgs e)
        {
            CreateNewOrderWindow newWin = new(_context);
            newWin.ShowDialog();
        }

        private void bt_deleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if(lb_Orders.SelectedItem != null)
            {
                _context.Orders.Remove((Order)lb_Orders.SelectedItem);
                _context.SaveChanges();
            }
        }

        private void bt_createTask_Click(object sender, RoutedEventArgs e)
        {
            CreateNewTaskWindow newWin = new(_context);
            newWin.ShowDialog();
        }

        private void bt_deleteTask_Click(object sender, RoutedEventArgs e)
        {
            _context.Tasks.Remove((Models.Task)lb_Tasks.SelectedItem);
            _context.SaveChanges();
        }

        private void bt_createWorker_Click(object sender, RoutedEventArgs e)
        {
            CreateNewUserWindow newWin = new(_context);
            newWin.ShowDialog();
        }

        private void bt_deleteWorker_Click(object sender, RoutedEventArgs e)
        {
            if (lb_Workers.SelectedItem != null)
            {
                _context.Users.Remove((User)lb_Workers.SelectedItem);
                _context.SaveChanges();
            }
        }

        private void bt_createFurniture_Click(object sender, RoutedEventArgs e)
        {
            CreateFurnitureWindow newWin = new(_context);
            newWin.ShowDialog();
        }

        private void bt_deleteFurniture_Click(object sender, RoutedEventArgs e)
        {
            if(lb_furniture.SelectedItem != null)
            {
                _context.Furnitures.Remove((Furniture)lb_furniture.SelectedItem);
                _context.SaveChanges();
            }
        }

        private void bt_createTeam_Click(object sender, RoutedEventArgs e)
        {
            Team newTeam = new Team();
            _context.Teams.Add(newTeam);
            _context.SaveChanges();
        }

        private void bt_deleteTeam_Click(object sender, RoutedEventArgs e)
        {
            if(lb_Teams.SelectedItem != null)
            {
                var teamMemebers = _context.Users.Where(u => u.Team == (Team)lb_Teams.SelectedItem).ToList();
                foreach(User member in teamMemebers)
                {
                    member.Team = null;
                }
                _context.Teams.Remove((Team)lb_Teams.SelectedItem);
                _context.SaveChanges();
            }
        }
    }
}
