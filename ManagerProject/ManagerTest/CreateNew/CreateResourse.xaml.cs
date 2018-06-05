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
using ManagerTest;
using System.Data.Entity;
using ManagerTest.DAL.EF.Repositories;
using ManagerTest.DAL.Domain;
using ManagerTest.BL;

namespace ManagerTest.CreateNew
{
    /// <summary>
    /// Логика взаимодействия для CreateProject.xaml
    /// </summary>
    public partial class CreateResourse : Window
    {
        //ResourseContext context1;
        ResourseContext db1;
        AddResourse resourse;
        public CreateResourse()
        {
            InitializeComponent();
            resourse = new AddResourse();
        }

        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {

                resourse.AddRes(CreateName.Text, Convert.ToInt32(CreateSerialN.Text), CreateTime.Text, CreatePurposeToUse.Text);

                db1.SaveChanges();

                
                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Ошибка ввода!");
            }
        }
        internal void AddDB(ResourseContext context)
        {
            db1 = context;
        }
    }
}
