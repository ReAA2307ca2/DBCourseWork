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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DBCourseWork.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserUC.xaml
    /// </summary>
    public partial class UserUC : UserControl
    {
        private ReAaContext _context;
        public UserUC(ReAaContext context)
        {
            _context = context;
            InitializeComponent();
            lb_Tasks.ItemsSource = _context.Tasks.Where(t => t.Worker.Name == UserCookies.LoggedUser.Name).ToList();
        }
    }
}
