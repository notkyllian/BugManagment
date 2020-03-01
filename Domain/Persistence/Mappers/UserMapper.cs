using System;
using System.Collections.Generic;
using Domain.Business.Entities;
using MySql.Data.MySqlClient;

namespace Domain.Persistence.Mappers
{
    internal class UserMapper
    {
        private readonly string _connectionString = "";

        internal UserMapper(string connectionString)
        {
            _connectionString = connectionString;
        }


        private List<Employee> GetEmployeesFromProjectManager(int pmId)
        {
            var employees = new List<Employee>();

            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand("SELECT * from tbluser WHERE projectmanager_id = @id", connection);

            command.Parameters.AddWithValue("@id", pmId);

            connection.Open();
            var dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                var id = Convert.ToInt32(dataReader["id"]);
                var name = Convert.ToString(dataReader["name"]);
                var birthday = Convert.ToDateTime(dataReader["birthday"]);

                var username = Convert.ToString(dataReader["username"]);
                var password = Convert.ToString(dataReader["password"]);

                var employee = new Employee(id, name, birthday, password, username);

                employees.Add(employee);
            }

            return employees;
        }

        internal List<User> GetTaskFromDb()
        {
            var users = new List<User>();

            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand("SELECT * from tbluser", connection);

            connection.Open();
            var dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                var id = Convert.ToInt32(dataReader["id"]);
                var name = Convert.ToString(dataReader["name"]);
                var birthday = Convert.ToDateTime(dataReader["birthday"]);

                var username = Convert.ToString(dataReader["username"]);
                var password = Convert.ToString(dataReader["password"]);


                switch (Convert.ToString(dataReader["rol"]).ToLower())
                {
                    case "projectmanager":
                        var projectmanager = new Projectmanager(id, name, birthday, password, username);
                        projectmanager.Load(GetEmployeesFromProjectManager(projectmanager.Id));
                        users.Add(projectmanager);
                        break;
                    case "employee":
                        var employee = new Employee(id, name, birthday, password, username);
                        users.Add(employee);
                        break;
                    case "user":
                        var user = new User(id, name, birthday, password, username);
                        users.Add(user);
                        break;
                    default:
                        throw new Exception("Invalid usertype");
                }
            }

            connection.Close();
            return users;
        }


        internal void AddUserToDb(User user)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "INSERT INTO tbltask (id, name, birthday, rol, username, password)" +
                " VALUES (@id, @name, @birthday, @rol, @username, @password)"
                , connection);
            if (user.GetType() == typeof(User)) command.Parameters.AddWithValue("rol", DBNull.Value);
            if (user.GetType() == typeof(Employee)) command.Parameters.AddWithValue("rol", "employee");
            if (user.GetType() == typeof(Projectmanager)) command.Parameters.AddWithValue("rol", "projectmanager");


            command.Parameters.AddWithValue("id", user.Id);
            command.Parameters.AddWithValue("name", user.Name);
            command.Parameters.AddWithValue("birthday", user.Birthday);
            command.Parameters.AddWithValue("username", user.Username);
            command.Parameters.AddWithValue("password", user.Password);

            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
        }

        internal void UpdateUserInDb(User user)
        {


        }
    }
}