using ManagerTest.BL;
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

namespace ManagerTest.CreateNew
{
   
    public partial class CreateUser : Window
    {
        Context db1;
        AddUser user;
        string CreateRole = "User";

        public CreateUser()
        {
            InitializeComponent();
            user = new AddUser();
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            CreateRole = pressed.Content.ToString();

        }
        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {

                user.AddUsr(CreateFio.Text, CreateLogin.Text, CreatePassword.Text, CreateRole);

                db1.SaveChanges();


                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка ввода!");
            }
        }
        internal void AddDB(Context context)
        {
            db1 = context;
        }
    }
}
