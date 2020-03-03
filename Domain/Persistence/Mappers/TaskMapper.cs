using System;
using System.Collections.Generic;
using Domain.Business.Entities;
using Domain.Business.Repositories;
using MySql.Data.MySqlClient;

namespace Persistence
{
    internal class TaskMapper
    {
        private readonly string _connectionString;

        internal TaskMapper(string connectionString)
        {
            _connectionString = connectionString;
        }


        internal List<Task> GetTaskFromDb()
        {
            var tasks = new List<Task>();

            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand("SELECT * from tbltask", connection);

            connection.Open();
            var dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                TimeSpan.TryParse(Convert.ToString(dataReader["timespent"]), out var timeSpan);
                var task = new Task(
                    Convert.ToInt32(dataReader["id"]),
                    BugRepository.Items.Find(x => x.Id == (Convert.ToInt32(dataReader["bug_id"]))),
                    Convert.ToString(dataReader["description"]),
                    Convert.ToInt32(dataReader["size"]),
                    timeSpan
                );
                if (!dataReader.IsDBNull(dataReader.GetOrdinal("user_id")))
                    task.Employee =
                        (Employee) UserRepository.Items.Find(x => x.Id == Convert.ToInt32(dataReader["user_id"]));
                tasks.Add(task);
            }

            connection.Close();
            return tasks;
        }

        internal void AddTaskToDb(Task task)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "INSERT INTO tbltask (id, description, size, timespent, bug_id)" +
                " VALUES (@id, @description, @size, @timespent, @bugid)"
                , connection);


            command.Parameters.AddWithValue("id", task.Id);
            command.Parameters.AddWithValue("description", task.Description);
            command.Parameters.AddWithValue("size", task.Size);
            command.Parameters.AddWithValue("timespent", task.TimeSpent);
            command.Parameters.AddWithValue("bugid", task.Bug.Id);
            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
        }

        internal void UpdateTaskInDb(Task task)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "UPDATE tbltask SET description = @description, size = @size, timespent = @timespent, user_id = @user_id" +
                " WHERE id=@id"
                , connection);
            command.Parameters.AddWithValue("id", task.Id);
            command.Parameters.AddWithValue("description", task.Description);
            command.Parameters.AddWithValue("timespent", task.TimeSpent);
            command.Parameters.AddWithValue("size", task.Size);
            command.Parameters.AddWithValue("user_id", task.Employee.Id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        internal void DeleteTaskFromDb(Task task)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "DELETE FROM tbltask" +
                " WHERE id=@id"
                , connection);
            command.Parameters.AddWithValue("id", task.Id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}