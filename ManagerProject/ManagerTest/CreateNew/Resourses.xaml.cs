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
using System.Data.Entity;
using ManagerTest.CreateNew;
using ManagerTest.DAL.EF.Repositories;
using ManagerTest.DAL.Domain;
using ManagerTest.BL;
using ManagerTest;

namespace ManagerTest.CreateNew
{
    /// <summary>
    /// Логика взаимодействия для Resourses.xaml
    /// </summary>
    public partial class Resourses : Window
    {
        public RepositoryResourseEF db;
        public GetResourse getRes;
        public Context context;
        public Resourses()
        {
            InitializeComponent();
            context = new Context();
            // db = new RepositoryResourseEF(context);
            db = new RepositoryResourseEF();

            db.db.Resourses.Load();

            getRes = new GetResourse();


            //  ResourseGrid.ItemsSource = context.Resourses.Local.ToBindingList();

            // ResourseGrid.ItemsSource = db.db.Resourses.Local.ToBindingList();
            UPDATE();




            this.Closing += MainWindow_Closing;


        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Close();
        }
        private void UPDATE()
        {
            // ResourseGrid.ItemsSource = db.db.Resourses.Local.ToBindingList();
            ResourseGrid.ItemsSource = getRes.ReturnResourse().ToList();

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            //context.Resourses.Load();
            db.db.Resourses.Load();

            //ResourseGrid.ItemsSource = getRes.ReturnResourse().ToList();
            UPDATE();
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
            UPDATE();
            //ResourseGrid.ItemsSource = getRes.ReturnResourse().ToList();



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

