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
        public RepositoryResourseEF db;
        public GetResourse getRes;
        public ResourseContext context;
        public MainWindow()
        {
            InitializeComponent();
            context = new ResourseContext();
            db = new RepositoryResourseEF();




            getRes = new GetResourse();
            context.Resourses.Load();
            ResourseGrid.ItemsSource = context.Resourses.Local.ToBindingList();
           

            this.Closing += MainWindow_Closing;
          

        }

            private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Close();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.Save();
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ResourseGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < ResourseGrid.SelectedItems.Count; i++)
                {
                    Resourse resourse = ResourseGrid.SelectedItems[i] as Resourse;
                    if (resourse != null)
                    {
                        db.Delete(resourse);
                    }
                }
            }
          
          

        }
        

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            CreateResourse resourseNew = new CreateResourse();
            resourseNew.Owner = this;
            resourseNew.Show();
            resourseNew.AddDB(context);

        }

       
    }
}
