using ManagerTest.BL;
using ManagerTest.DAL.Domain;
using ManagerTest.DAL.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace ManagerTest.CreateNew
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        public RepositoryUserEF db;
        public GetUser getUsr;
        public Context context;
        public Users()
        {
            InitializeComponent();

            context = new Context();
            db = new RepositoryUserEF();

            db.db.Resourses.Load();
            getUsr = new GetUser();
            UPDATE();




            this.Closing += MainWindow_Closing;


        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Close();
        }
        private void UPDATE()
        {
           
             UserGrid.ItemsSource = getUsr.ReturnUser().ToList();

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
           
            db.db.Users.Load();

           
            UPDATE();
            db.Save();
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < UserGrid.SelectedItems.Count; i++)
                {
                    User user = UserGrid.SelectedItems[i] as User;
                    if (user != null)
                    {
                        db.Delete(user);
                    }
                }
            }
            UPDATE();
        



        }


        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            CreateUser userNew = new CreateUser();
            userNew.Owner = this;
            userNew.Show();
            userNew.AddDB(context);

        }

    }
}
