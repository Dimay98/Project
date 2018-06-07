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
using System.Data.Entity;
using ManagerTest.CreateNew;
using ManagerTest.DAL.EF.Repositories;
using ManagerTest.DAL.Domain;
using System.ComponentModel.Design;
using ManagerTest.BL;

namespace ManagerTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
           


        }

      
        private void CreateButton_Resourse(object sender, RoutedEventArgs e)
        {
            Resourses res = new Resourses();
            res.Show();
            
        }

        private void CreateButton_User(object sender, RoutedEventArgs e)
        {
            Users us = new Users();
            us.Show();
            
            
        }
    }
}
