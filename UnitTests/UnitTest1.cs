using System;
using System.Collections.Generic;
using Domain;
using Domain.Business;
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
            var c = new Controller();

            var emp = c.AddEmployee("Dirk", DateTime.Now, "Dirk", "test");
            var pm = c.AddProjectmanager("Jens", DateTime.Now, "Jens", "test");


            c.AddEmployeeToProject(pm, emp);

            Assert.AreEqual(c.GetUsers().Count, 2);

            c.RemoveUser(emp.Id);
            c.RemoveUser(pm.Id);
        }

        [TestMethod]
        public void TestControllerData()
        {
            var c = new Controller();
            var c2 = new Controller();

            var u1 = c.AddUser("TestUser1", DateTime.Now, "Test", "test");
            var u2 = c2.AddUser("TestUser2", DateTime.Now, "Test2", "test");

            Assert.AreEqual(c.GetUsers().Count, c2.GetUsers().Count);

            c.RemoveUser(u1.Id);
            c.RemoveUser(u2.Id);
        }

        [TestMethod]
        public void TestTaskLogic()
        {
            var c = new Controller();

            var employee = c.AddEmployee("Dirk", DateTime.Now, "Dirk", "test");
            var bug = c.AddBug("Error 404 on index.php page");
            var task = c.AddTask(bug, 10, "Make page redirect to temp directory", TimeSpan.FromDays(1));
            c.AddTaskToEmployee(task, employee);

            Assert.AreEqual(c.GetBug(1).GetTaskCount(),
                1); //TODO fix the fact that I can't remove user because connection between user and task

            c.RemoveUser(employee.Id);
        }

        [TestMethod]
        public void TestUpdateFunctionality()
        {
            var c = new Controller();

            var emp = c.AddEmployee("Dirk", DateTime.Now, "Dirk", "test");
            var pm = c.AddProjectmanager("Jens", DateTime.Now, "Jens", "test");

            c.AddEmployeeToProject(pm, emp);
            emp.Name = "Philip2";

            c.UpdateUser(emp);

            Assert.AreEqual(pm.GetEmployees().Count, 1);
        }

        [TestMethod]
        public void TestTaskToEmployeeComposition()
        {
            var c = new Controller();
            c.AddBug("Nigga");
            c.AddTask(c.GetBug(1), 10, "Bruh");
        }
    }
}