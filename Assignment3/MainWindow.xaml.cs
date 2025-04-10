using Assignment3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

namespace Assignment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private readonly Dat154Context dx = new();
        // Local cashe av data
        private readonly LocalView<Student> Students;



        public MainWindow()
        {
            InitializeComponent();

            Students = dx.Students.Local;

            // Vise en liste av alle studenter fra databasen
            dx.Students.Load();
            // Setter datacontext, hvor den skal få dataene sine fra
            studentList.DataContext = Students.OrderBy(s => s.Studentname);

        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            studentList.DataContext = Students.Where(s => s.Studentname.Contains(searchField.Text))
                .OrderBy(s => s.Studentname);

        }

        private void toCourses_Click(object sender, RoutedEventArgs e)
        {
            Courses cw = new Courses(dx);
            cw.Show();
            
        }
    }
}