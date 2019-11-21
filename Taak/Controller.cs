using System;
using System.Collections.Generic;
using Taak.Entities;

namespace Taak
{
    public class Controller
    {
        private static UserRepository _userRepository;
        private static TaskRepository _taskRepository;
        private static BugRepository _bugRepository;

        public Controller()
        {
            _userRepository = new UserRepository();
            _taskRepository = new TaskRepository();
            _bugRepository = new BugRepository();
        }


        #region User

        public User AddUser(string naam)
        {
            var toAdd = new User(_userRepository.GetNextId(), naam);
            _userRepository.AddItem(toAdd);
            return toAdd;
        }

        public Employee AddEmployee(string naam)
        {
            var toAdd = new Employee(_userRepository.GetNextId(), naam);
            _userRepository.AddItem(toAdd);
            return toAdd;
        }

        public Projectmanager AddProjectmanager(string naam)
        {
            var toAdd = new Projectmanager(_userRepository.GetNextId(), naam);
            _userRepository.AddItem(toAdd);
            return toAdd;
        }

        public User UpdateUser(User user)
        {
            var toUpdate = _userRepository.GetItem(user.Id);
            if (toUpdate != null)
            {
                _userRepository.RemoveItem(toUpdate.Id);
                _userRepository.AddItem(toUpdate);
                return toUpdate;
            }

            throw new Exception("User with id: " + user.Id + " not found.");
        }

        public User GetUser(int id)
        {
            var toGet = _userRepository.GetItem(id);
            if (toGet != null)
                return toGet;
            throw new Exception("User with id: " + id + " not found.");
        }

        public void RemoveUser(int id)
        {
            var toRemove = _userRepository.GetItem(id);
            if (toRemove != null)
                _userRepository.RemoveItem(id);
            else
                throw new Exception("User with id: " + id + " not found.");
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        #endregion

        #region Task

        public Task AddTask(Bug bug, int size, string description, TimeSpan timeSpent)
        {
            var toAdd = new Task(_taskRepository.GetNextId(), bug, description, size, timeSpent);
            bug.AddTask(toAdd);
            _taskRepository.AddItem(toAdd);
            return toAdd;
        }

        public Task UpdateTask(Task task)
        {
            var toUpdate = _taskRepository.GetItem(task.Id);
            if (toUpdate != null)
            {
                _taskRepository.RemoveItem(toUpdate.Id);
                _taskRepository.AddItem(toUpdate);
                return toUpdate;
            }

            throw new Exception("Task with id: " + task.Id + " not found.");
        }

        public Task GetTask(int id)
        {
            var toGet = _taskRepository.GetItem(id);
            if (toGet != null)
                return toGet;
            throw new Exception("Task with id: " + id + " not found.");
        }

        public void RemoveTask(int id)
        {
            var toRemove = _taskRepository.GetItem(id);
            if (toRemove != null)
                _taskRepository.RemoveItem(id);
            else
                throw new Exception("User with id: " + id + " not found.");
        }

        public void AddTaskToUser(int id, Employee user)
        {
            var Task = GetTask(id);
            Task.Employee = user;
            UpdateTask(Task);
        }

        public List<Task> GetTaskList()
        {
            return _taskRepository.GetAll();
        }

        #endregion

        #region Bugs

        public Bug AddBug(string description)
        {
            var toAdd = new Bug(_bugRepository.GetNextId(), description);
            _bugRepository.AddItem(toAdd);
            return toAdd;
        }

        public Bug UpdateBug(Bug bug)
        {
            var toUpdate = _bugRepository.GetItem(bug.Id);
            if (toUpdate != null)
            {
                _bugRepository.RemoveItem(toUpdate.Id);
                _bugRepository.AddItem(toUpdate);
                return toUpdate;
            }

            throw new Exception("Bug with id: " + bug.Id + " not found.");
        }

        public Bug GetBug(int id)
        {
            var toGet = _bugRepository.GetItem(id);
            if (toGet != null)
                return toGet;
            throw new Exception("Bug with id: " + id + " not found.");
        }

        public void RemoveBug(int id)
        {
            var toRemove = _bugRepository.GetItem(id);
            if (toRemove != null)
                _bugRepository.RemoveItem(id);
            else
                throw new Exception("Bug with id: " + id + " not found.");
        }

        public List<Bug> GetBugList()
        {
            return _bugRepository.GetAll();
        }

        #endregion

        #region Functions

        public void AddTaskToBug(Task task, Bug bug)
        {
            bug.AddTask(task);
        }

        public void AddTaskToEmployee(Task task, Employee employee)
        {
            employee.AddTask(task);
            task.Employee = employee;
        }

        public void AddTimeToTask(Task task, TimeSpan time)
        {
            task.AddTime(time);
        }

        public void AddEmployeeToProject(Projectmanager projectmanager, Employee employee)
        {
            projectmanager.addEmployee(employee);
        }

        #endregion
    }
}