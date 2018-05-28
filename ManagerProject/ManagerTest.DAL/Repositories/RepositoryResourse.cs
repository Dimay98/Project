using ManagerTest.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManagerTest.DAL.Repositories
{
    public class RepositoryResourse : IRepository<Resourse>
    { 
        string ConnectString;
        DataTable Resourses;
        SqlDataAdapter adapter;

        SqlConnection sqlConnection = null;
        public RepositoryResourse()
        {
            ConnectString = ConfigurationManager.ConnectionStrings["ManagerConnection"].ConnectionString;
            sqlConnection = new SqlConnection(ConnectString);
            sqlConnection.Open();
        }
        public void Close()
        {
            sqlConnection.Close();
        }
        public void Delete(int Id)
        {

            sqlConnection.Open();

            const string sqlExpression = "DELETE FROM Resourse WHERE Id=@Id";
            var command = new SqlCommand(sqlExpression, sqlConnection);
            var idParameter = new SqlParameter("@Id", Id);
            command.Parameters.Add(idParameter);
            command.ExecuteNonQuery();
            sqlConnection.Close();

        }
        public void Update()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(Resourses);
        }
      
        public IEnumerable<Resourse> GetAll()
        {
            var resources = new List<Resourse>();

            sqlConnection.Open();

            const string sqlExpression = "SELECT Id,Name,SerialN,Time,PurposeToUse FROM Resourse";
            var command = new SqlCommand(sqlExpression, sqlConnection);


            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                resources.Add(new Resourse
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    SerialN = reader.GetInt32(2),
                    Time = reader.GetString(3),
                    PurposeToUse = reader.GetString(4)
                });
            }

            return resources;

        }
        public void Delete(Resourse entity)
        {
             sqlConnection.Open();

                const string sqlExpression = "DELETE FROM Resourses WHERE Id = @Id";
                var command = new SqlCommand(sqlExpression, sqlConnection);
                var idParameter = new SqlParameter("@Id", entity.Id);
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();
            
        }
        public void Update(Resourse entity)
        {

            sqlConnection.Open();

            const string sqlExpression =
                "UPDATE Projects" +
                "SET Name = @Name, SerialN = @SerialN, Time = @Time, PurposeToUse = @PurposeToUse" +
                "WHERE Id = @Id";
            var command = new SqlCommand(sqlExpression, sqlConnection);
            var parameters = new[]
            {
                    new SqlParameter("@Id", entity.Id),
                    new SqlParameter("@Name", entity.Name),
                    new SqlParameter("@SerialN", entity. SerialN),
                    new SqlParameter("@Time", entity.Time),
                    new SqlParameter("@PurposeToUse", entity.PurposeToUse)
                };
            command.Parameters.AddRange(parameters);
            command.ExecuteNonQuery();

            sqlConnection.Close();

        }
        public void Create(Resourse entity)
        {
            sqlConnection.Open();

            const string sqlExpression =
                "INSERT INTO Projects (Id, Name, SerialN, Time, PurposeToUse)" +
                "VALUES (@Id, @Name, @SerialN, @Time, @PurposeToUse)";
            var command = new SqlCommand(sqlExpression, sqlConnection);
            var parameters = new[]
            {
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@name", entity.Name),
                    new SqlParameter("@shortInfo", entity.SerialN),
                    new SqlParameter("@info", entity.Time),
                    new SqlParameter("@creatureDate", entity.PurposeToUse)
                };
            command.Parameters.AddRange(parameters);

            command.ExecuteNonQuery();



            sqlConnection.Close();

        }
        

    }
}
