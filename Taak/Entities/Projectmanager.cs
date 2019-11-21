using System.Collections.Generic;

namespace Taak.Entities
{
    public class Projectmanager : User
    {
        private readonly List<Employee> _employees; //Employees to manage

        internal Projectmanager(int id, string naam) : base(id, naam)
        {
            _employees = new List<Employee>();
        }

        internal void addEmployee(Employee employee)
        {
            _employees.Add(employee);
        }
    }
}