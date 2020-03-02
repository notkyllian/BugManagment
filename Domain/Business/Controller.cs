using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Business.Entities;
using Domain.Business.Repositories;

namespace Domain
{
    public class Controller
    {
        private static readonly bool _isLoaded = false;

        private static readonly UserRepository _userRepository = new UserRepository();
        private static readonly TaskRepository _taskRepository = new TaskRepository();
        private static readonly BugRepository _bugRepository = new BugRepository();

        public Controller()
        {
            if (!_isLoaded)
            {
                _bugRepository.Load(Persistence.Controller.GetBugs());
                _taskRepository.Load(Persistence.Controller.GetTasks());
                foreach (var Bug in _bugRepository.GetAll())
                    Bug.Load(_taskRepository.GetAll().Where(x => x.Bug.Id == Bug.Id).ToList());
                _userRepository.Load(Persistence.Controller.GetUsers());
            }
        }


        #region User

        public User AddUser(string naam, DateTime birthday, string username, string password)
        {
            var toAdd = new User(_userRepository.GetNextId(), naam, birthday, username, password);
            _userRepository.AddItem(toAdd);
            return toAdd;
        }

        public Employee AddEmployee(string naam, DateTime birthday, string username, string password)
        {
            var toAdd = new Employee(_userRepository.GetNextId(), naam, birthday, password, username);
            _userRepository.AddItem(toAdd);
            return toAdd;
        }

        public Projectmanager AddProjectmanager(string naam, DateTime birthday, string username, string password)
        {
            var toAdd = new Projectmanager(_userRepository.GetNextId(), naam, birthday, username, password);
            _userRepository.AddItem(toAdd);
            return toAdd;
        }

        public User UpdateUser(User user)
        {
            if (_userRepository.GetItem(user.Id) != null) return _userRepository.UpdateItem(user);
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
            bug._tasks.Add(toAdd);
            _taskRepository.AddItem(toAdd);
            return toAdd;
        }

        public Task UpdateTask(Task task)
        {
            if (_taskRepository.GetItem(task.Id) != null) return _taskRepository.UpdateItem(task);
            throw new Exception("Task with id: " + task.Id + " not found.");
        }

        public Task GetTask(int id)
        {
            var toGet = _taskRepository.GetItem(id);
            if (toGet != null)
                return toGet;
            throw new Exception("Task with id: " + id + " not found.");
        }

        public void RemoveTask(Bug bug, int id)
        {
            var toRemove = _taskRepository.GetItem(id);
            if (toRemove != null)
            {
                bug._tasks.Remove(toRemove);
                _taskRepository.RemoveItem(id);
            }
            else
            {
                throw new Exception("User with id: " + id + " not found.");
            }
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
            if (_bugRepository.GetItem(bug.Id) != null) return _bugRepository.UpdateItem(bug);
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
            {
                foreach (var task in toRemove._tasks) _taskRepository.RemoveItem(task.Id);
                _bugRepository.RemoveItem(id);
            }
            else
            {
                throw new Exception("Bug with id: " + id + " not found.");
            }
        }

        public List<Bug> GetBugList()
        {
            return _bugRepository.GetAll();
        }

        #endregion

        #region Functions

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
            UpdateUser(employee);
        }

        #endregion
    }
}