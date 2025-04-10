using Assignment3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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


namespace Assignment3
{
    public partial class Courses : Window
    {
        private readonly Dat154Context dx = new();

        private readonly LocalView<Course> CoursesList;
        private readonly LocalView<Student> Students;
        private readonly LocalView<Grade> Grades;

        public Courses(Dat154Context context)


        {
            InitializeComponent();
            DataContext = this;
            Grades = dx.Grades.Local;
            Students = dx.Students.Local;
            CoursesList = dx.Courses.Local;
            studentGradesList.ItemsSource = CoursesList;

            dx.Courses.Load();
           
            
            
            

        }

        private void studentGradesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (studentGradesList.SelectedItem != null)
            {
                Course selectedCourse = (Course)studentGradesList.SelectedItem;

                var studentGradesForCourse = from grade in dx.Grades
                                             join student in dx.Students on grade.Studentid equals student.Id
                                             where grade.Coursecode == selectedCourse.Coursecode
                                             select new
                                             {
                                                 StudentName = student.Studentname,
                                                 Grade = grade.Grade1
                                             };

                studentGradesList.ItemsSource = studentGradesForCourse.ToList();
            }
        }




    }
}
