using System;
using System.Collections.Generic;
using Domain.Business.Entities;
using MySql.Data.MySqlClient;

namespace Persistence
{
    internal class BugMapper
    {
        //Task cannot exist without Bug
        //For the rest all independent


        private readonly string _connectionString = "";

        internal BugMapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        internal List<Bug> GetBugsFromDb()
        {
            var _bugs = new List<Bug>();

            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand("SELECT * from tblbug", connection);

            connection.Open();
            var dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                var _bug = new Bug(
                    Convert.ToInt32(dataReader["id"]),
                    Convert.ToString(dataReader["description"])
                );
                _bugs.Add(_bug);
            }

            connection.Close();
            return _bugs;
        }

        internal void AddBugToDb(Bug bug)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "INSERT INTO tblbug (id, description)" +
                " VALUES (@id, @description)"
                , connection);


            command.Parameters.AddWithValue("id", bug.Id);
            command.Parameters.AddWithValue("description", bug.Description);

            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
        }

        internal void UpdateBugInDb(Bug bug)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "UPDATE tblbug SET description = @description" +
                " WHERE id=@id"
                , connection);
            command.Parameters.AddWithValue("id", bug.Id);
            command.Parameters.AddWithValue("description", bug.Description);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        internal void DeleteBugInDb(Bug bug)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "DELETE FROM tblbug" +
                " WHERE id=@id"
                , connection);
            command.Parameters.AddWithValue("id", bug.Id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}