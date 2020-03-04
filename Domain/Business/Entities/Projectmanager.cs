using System;
using System.Collections.Generic;

namespace Domain.Business.Entities
{
    public class Projectmanager : User
    {
        private readonly List<Employee> _employees; //Employees to manage

        internal Projectmanager(int id, string name, DateTime birthday, string password, string username) : base(id,
            name,
            birthday, password, username)
        {
            _employees = new List<Employee>();
        }

        internal void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        internal void Load(List<Employee> employees)
        {
            foreach (var employee in employees) _employees.Add(employee);
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }
    }
}