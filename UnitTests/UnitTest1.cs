using System;
using Domain;
using Domain.Business.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMS
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestUserInheritance()
        {
            var _c = new Controller();

            var emp = _c.AddEmployee("Dirk", DateTime.Now, "Dirk", "test");
            var pm = _c.AddProjectmanager("Jens", DateTime.Now, "Jens", "test");


            _c.AddEmployeeToProject(pm, emp);

            Assert.AreEqual(_c.GetUsers().Count, 3);
        }

        [TestMethod]
        public void TestControllerData()
        {
            var _c = new Controller();
            var _c2 = new Controller();

            _c.AddUser("TestUser1", DateTime.Now, "Test", "test");
            _c2.AddUser("TestUser2", DateTime.Now, "Test2", "test");

            Assert.AreEqual(_c.GetUsers().Count, _c2.GetUsers().Count);
        }

        [TestMethod]
        public void TestTaskLogic()
        {
            var _c = new Controller();

            var employee = _c.AddEmployee("Dirk", DateTime.Now, "Dirk", "test");
            var bug = _c.AddBug("Error 404 on index.php page");
            var task = _c.AddTask(bug, 10, "Make page redirect to temp directory", TimeSpan.FromDays(1));
            _c.AddTaskToEmployee(task, employee);

            Assert.AreEqual(_c.GetBug(1).GetTaskCount(), 1);
        }

        [TestMethod]
        public void TestUpdateFunctionality()
        {
            var _c = new Controller();

            var user = _c.AddUser("Philip", DateTime.Now, "Philip", "test");
            user.Name = "Philip2";
            _c.UpdateUser(user);

            Assert.AreEqual(_c.GetUser(user.Id).Name, "Philip2");
        }

        [TestMethod]
        public void TestTaskToEmployeeComposition()
        {
            var _c = new Controller();

            var employee = _c.AddEmployee("Dirk", DateTime.Now, "Dirk", "test");
            var bug = _c.AddBug("Error 404 on index.php page");
            var task = _c.AddTask(bug, 10, "Make page redirect to temp directory", TimeSpan.FromDays(1));
            _c.AddTaskToEmployee(task, employee);

            Assert.AreEqual(_c.GetTask(1).Employee, employee);
        }

        [TestMethod]
        public void TestDB()
        {
            var c = new Controller();

            var bug = c.GetBug(1);
            var task = c.GetTask(1);

            var employee = (Employee) c.GetUser(1);

            Assert.AreEqual(task.Employee, employee);

        }
    }
}