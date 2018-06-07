using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ManagerTest.DAL.Domain;

namespace ManagerTest.DAL.Repositories
{
    public class RepositoryUser : IRepository<User>
    {
        string ConnectString;
        DataTable Users;
        SqlDataAdapter adapter;

        SqlConnection sqlConnection = null;
        public RepositoryUser()
        {
            ConnectString = ConfigurationManager.ConnectionStrings["ManagerConnection"].ConnectionString;
            sqlConnection = new SqlConnection(ConnectString);
            //  sqlConnection.Open();
        }
        public void Close()
        {
            sqlConnection.Close();
        }
        public void Delete(int Id)
        {

            sqlConnection.Open();

            const string sqlExpression = "DELETE FROM Users WHERE Id=@Id";
            var command = new SqlCommand(sqlExpression, sqlConnection);
            var idParameter = new SqlParameter("@Id", Id);
            command.Parameters.Add(idParameter);
            command.ExecuteNonQuery();
            sqlConnection.Close();

        }
        public void Update()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(Users);
        }

        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();

            sqlConnection.Open();

            const string sqlExpression = "SELECT Id,FIO,Login,Password,Role FROM Users";
            var command = new SqlCommand(sqlExpression, sqlConnection);


            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new User
                {
                    Id = reader.GetInt32(0),
                    FIO = reader.GetString(1),
                    Login = reader.GetString(2),
                    Password = reader.GetString(3),
                    Role = reader.GetString(4)
                });
            }

            return users;

        }
        public void Delete(User entity)
        {
            sqlConnection.Open();

            const string sqlExpression = "DELETE FROM Users WHERE Id = @Id";
            var command = new SqlCommand(sqlExpression, sqlConnection);
            var idParameter = new SqlParameter("@Id", entity.Id);
            command.Parameters.Add(idParameter);
            command.ExecuteNonQuery();

        }
        public void Update(User entity)
        {

            sqlConnection.Open();

            const string sqlExpression =
                "UPDATE Users" +
                "SET FIO = @FIO, Login = @Login, Password = @Password, Role = @Role" +
                "WHERE Id = @Id";
            var command = new SqlCommand(sqlExpression, sqlConnection);
            var parameters = new[]
            {
                    new SqlParameter("@Id", entity.Id),
                    new SqlParameter("@FIO", entity.FIO),
                    new SqlParameter("@Login", entity.Login),
                    new SqlParameter("@Password", entity.Password),
                    new SqlParameter("@Role", entity.Role)
                };
            command.Parameters.AddRange(parameters);
            command.ExecuteNonQuery();

            sqlConnection.Close();

        }
        public void Create(User entity)
        {
            sqlConnection.Open();

            const string sqlExpression =
                "INSERT INTO Users (Id, FIO, Login, Password, Role)" +
                "VALUES (@Id, @FIO, @Login, @Password, @Role)";
            var command = new SqlCommand(sqlExpression, sqlConnection);
            var parameters = new[]
            {
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@FIO", entity.FIO),
                    new SqlParameter("@Login", entity.Login),
                    new SqlParameter("@Password", entity.Password),
                    new SqlParameter("@Role", entity.Role)
                };
            command.Parameters.AddRange(parameters);

            command.ExecuteNonQuery();



            sqlConnection.Close();

        }


    }
}
