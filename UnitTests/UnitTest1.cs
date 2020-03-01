using System;
using Domain;
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

            _c.AddEmployee("Dirk");
            _c.AddUser("Wilma");
            _c.AddProjectmanager("Jens");

            Assert.AreEqual(_c.GetUsers().Count, 3);
        }

        [TestMethod]
        public void TestControllerData()
        {
            var _c = new Controller();
            var _c2 = new Controller();

            _c.AddUser("TestUser1");
            _c2.AddUser("TestUser2");

            Assert.AreEqual(_c.GetUsers().Count, _c2.GetUsers().Count);
        }

        [TestMethod]
        public void TestTaskLogic()
        {
            var _c = new Controller();

            var employee = _c.AddEmployee("Dirk");
            var bug = _c.AddBug("Error 404 on index.php page");
            var task = _c.AddTask(bug, 10, "Make page redirect to temp directory", TimeSpan.FromDays(1));
            _c.AddTaskToEmployee(task, employee);

            Assert.AreEqual(_c.GetBug(1).GetTaskCount(), 1);
        }

        [TestMethod]
        public void TestUpdateFunctionality()
        {
            var _c = new Controller();

            var user = _c.AddUser("Philip");
            user.Naam = "Philip2";
            _c.UpdateUser(user);

            Assert.AreEqual(_c.GetUser(1).Naam, "Philip2");
        }

        [TestMethod]
        public void TestTaskToEmployeeComposition()
        {
            var _c = new Controller();

            var employee = _c.AddEmployee("Dirk");
            var bug = _c.AddBug("Error 404 on index.php page");
            var task = _c.AddTask(bug, 10, "Make page redirect to temp directory", TimeSpan.FromDays(1));
            _c.AddTaskToEmployee(task, employee);

            Assert.AreEqual(_c.GetTask(1).Employee, employee);
        }

        [TestMethod]
        public void TestDB()
        {
            var c = new Controller();
            var c2 = new Controller();

            var bug = c.GetBug(1);
            var task = c.AddTask(bug, 1, "Testing", TimeSpan.Zero);
            c.RemoveTask(bug, task.Id);

            Assert.AreEqual(bug.GetTaskCount(), 3);
        }
    }
}