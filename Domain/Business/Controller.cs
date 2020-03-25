using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Business.Entities;
using Domain.Business.Repositories;

namespace Domain.Business
{
    public class Controller
    {
        private readonly bool _isLoaded = false;

        private static readonly UserRepository UserRepository = new UserRepository();
        private static readonly TaskRepository TaskRepository = new TaskRepository();
        private static readonly BugRepository BugRepository = new BugRepository();

        public Controller()
        {

            
            if (_isLoaded) return;

            UserRepository.Load(Persistence.Controller.GetUsers());
            BugRepository.Load(Persistence.Controller.GetBugs());
            TaskRepository.Load(Persistence.Controller.GetTasks());


            foreach (var bug in BugRepository.GetAll())
                bug.Load(TaskRepository.GetAll().Where(x => x.Bug.Id == bug.Id).ToList());
            foreach (var employee in UserRepository.GetAll().OfType<Employee>())
                employee.Load(TaskRepository.GetAll().Where(x => x.Employee != null && x.Employee.Id == employee.Id).ToList());

            _isLoaded = true;
        }

        #region Presentation Layer

        public User Login(string username, string password)
        {
            var user = GetUsers().Find(x => x.Username == username && x.Password == password);
            return user;
        }

        #endregion

        #region User

        public User AddUser(string naam, DateTime birthday, string username, string password)
        {
            var toAdd = new User(UserRepository.GetNextId(), naam, birthday, username, password);
            UserRepository.AddItem(toAdd);
            return toAdd;
        }

        public Employee AddEmployee(string naam, DateTime birthday, string username, string password)
        {
            var toAdd = new Employee(UserRepository.GetNextId(), naam, birthday, username, password);
            UserRepository.AddItem(toAdd);
            return toAdd;
        }

        public Projectmanager AddProjectmanager(string naam, DateTime birthday, string username, string password)
        {
            var toAdd = new Projectmanager(UserRepository.GetNextId(), naam, birthday, username, password);
            UserRepository.AddItem(toAdd);
            return toAdd;
        }

        public User UpdateUser(User user)
        {
            if (UserRepository.GetItem(user.Id) != null) return UserRepository.UpdateItem(user);
            throw new Exception("User with id: " + user.Id + " not found.");
        }

        public User GetUser(int id)
        {
            var toGet = UserRepository.GetItem(id);
            if (toGet != null)
                return toGet;
            throw new Exception("User with id: " + id + " not found.");
        }

        public void RemoveUser(int id)
        {
            var toRemove = UserRepository.GetItem(id);
            if (toRemove != null)
                UserRepository.RemoveItem(id);
            else
                throw new Exception("User with id: " + id + " not found.");
        }

        public List<User> GetUsers()
        {
            return UserRepository.GetAll();
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> lE = new List<Employee>();
            lE.Add(new Employee(0, "None", DateTime.MinValue, " ", " "));
            lE.AddRange(UserRepository.GetAll().OfType<Employee>().ToList());
            return lE;
        }

        #endregion

        #region Task

        public Task AddTask(Bug bug, int size, string description, TimeSpan? maxWait = null)
        {
            var timeSpent = maxWait ?? TimeSpan.Zero;
            var toAdd = new Task(TaskRepository.GetNextId(), bug, description, size, timeSpent);
            bug.Tasks.Add(toAdd);
            TaskRepository.AddItem(toAdd);
            return toAdd;
        }

        public Task UpdateTask(Task task)
        {
            if (TaskRepository.GetItem(task.Id) != null) return TaskRepository.UpdateItem(task);
            throw new Exception("Task with id: " + task.Id + " not found.");
        }

        public Task GetTask(int id)
        {
            var toGet = TaskRepository.GetItem(id);
            if (toGet != null)
                return toGet;
            throw new Exception("Task with id: " + id + " not found.");
        }

        public void RemoveTask(Bug bug, int id)
        {
            var toRemove = TaskRepository.GetItem(id);
            if (toRemove != null)
            {
                bug.Tasks.Remove(toRemove);
                TaskRepository.RemoveItem(id);
            }
            else
            {
                throw new Exception("User with id: " + id + " not found.");
            }
        }

        public void AddTaskToUser(int id, Employee user)
        {
            var task = GetTask(id);
            task.Employee = user;
            UpdateTask(task);
        }

        public List<Task> GetTaskList()
        {
            return TaskRepository.GetAll();
        }

        #endregion

        #region Bugs

        public Bug AddBug(string description)
        {
            var toAdd = new Bug(BugRepository.GetNextId(), description);
            BugRepository.AddItem(toAdd);
            return toAdd;
        }

        public Bug UpdateBug(Bug bug)
        {
            if (BugRepository.GetItem(bug.Id) != null) return BugRepository.UpdateItem(bug);
            throw new Exception("Bug with id: " + bug.Id + " not found.");
        }

        public Bug GetBug(int id)
        {
            var toGet = BugRepository.GetItem(id);
            if (toGet != null)
                return toGet;
            throw new Exception("Bug with id: " + id + " not found.");
        }

        public void RemoveBug(int id)
        {
            var toRemove = BugRepository.GetItem(id);
            if (toRemove != null)
                //foreach (var task in toRemove._tasks) _taskRepository.RemoveItem(task.Id); Not needed since we do Cascade Delete now.
                BugRepository.RemoveItem(id);
            else
                throw new Exception("Bug with id: " + id + " not found.");
        }

        public List<Bug> GetBugList()
        {
            return BugRepository.GetAll();
        }

        #endregion

        #region Functions

        public void AddTaskToEmployee(Task task, Employee employee)
        {
            employee.AddTask(task);
            task.Employee = employee;
            UpdateTask(task);
        }

        public void AddTimeToTask(Task task, TimeSpan time)
        {
            task.AddTime(time);
            UpdateTask(task);
        }

        public void AddEmployeeToProject(Projectmanager projectmanager, Employee employee)
        {
            projectmanager.AddEmployee(employee);
            UpdateUser(employee);
        }

        #endregion
    }
}