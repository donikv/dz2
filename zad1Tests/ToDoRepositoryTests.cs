using Microsoft.VisualStudio.TestTools.UnitTesting;
using zad1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    [TestClass()]
    public class ToDoRepositoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullToDatabaseThrowsException()
        {
            IToDoRepository repository = new ToDoRepository();
            repository.Add(null);
        }

        [TestMethod]
        public void AddingItemWillAddToDatabase()
        {
            IToDoRepository repository = new ToDoRepository();
            var ToDoItem = new ToDoItem(" Groceries ");
            repository.Add(ToDoItem);
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.IsTrue(repository.Get(ToDoItem.Id) != null);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateToDoItemException))]
        public void AddingExistingItemWillThrowException()
        {
            IToDoRepository repository = new ToDoRepository();
            var ToDoItem = new ToDoItem(" Groceries ");
            repository.Add(ToDoItem);
            repository.Add(ToDoItem);
        }
        //testne metode kopirane iz zadace

        //testna metoda za konstruktor
        [TestMethod]
        public void ConstructorWillAddList()
        {
            List<ToDoItem> repository = new List<ToDoItem>();
            var ToDoItem = new ToDoItem(" Groceries ");
            repository.Add(ToDoItem);
            IToDoRepository repository2 = new ToDoRepository(repository);
            Assert.AreEqual(true, repository.SequenceEqual(repository2.GetAll()));
        }

        //moje testne metode
        //test metode za Get
        [TestMethod]
        public void SearchingExisitingWillReturnItem()
        {
            IToDoRepository repository = new ToDoRepository();
            var ToDoItem = new ToDoItem(" Groceries ");
            var ToDoItem2 = new ToDoItem(" Groceries1 ");
            repository.Add(ToDoItem);
            repository.Add(ToDoItem2);
            Assert.AreEqual(ToDoItem, repository.Get(ToDoItem.Id));
        }
        [TestMethod]
        public void SearchingNonExisitingWillReturnNull()
        {
            IToDoRepository repository = new ToDoRepository();
            var ToDoItem = new ToDoItem(" Groceries ");
            var ToDoItem2 = new ToDoItem(" Groceries1 ");
            var ToDoItem3 = new ToDoItem(" Groceries2 ");
            repository.Add(ToDoItem);
            repository.Add(ToDoItem2);
            Assert.AreEqual(null, repository.Get(ToDoItem3.Id));
        }
        //test metode za Get gotove


        //test metode za Remove
        [TestMethod]
        public void RemovingExisitingWillRemoveIt()
        {
            IToDoRepository repository = new ToDoRepository();
            var ToDoItem = new ToDoItem(" Groceries ");
            var ToDoItem2 = new ToDoItem(" Groceries1 ");
            repository.Add(ToDoItem);
            repository.Add(ToDoItem2);
            Assert.AreEqual(true, repository.Remove(ToDoItem.Id));
            Assert.AreEqual(1, repository.GetAll().Count);
        }
        [TestMethod]
        public void RemovingNonExisitingWillReturnFalse()
        {
            IToDoRepository repository = new ToDoRepository();
            var ToDoItem = new ToDoItem(" Groceries ");
            var ToDoItem2 = new ToDoItem(" Groceries1 ");
            var ToDoItem3 = new ToDoItem(" Groceries2 ");
            repository.Add(ToDoItem);
            repository.Add(ToDoItem2);
            Assert.AreEqual(false, repository.Remove(ToDoItem3.Id));
            Assert.AreEqual(2, repository.GetAll().Count);
        }
        //test metode za Remove gotove


        //test metode za Update
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdatingNullInDatabaseThrowsException()
        {
            IToDoRepository repository = new ToDoRepository();
            repository.Update(null);
        }
        [TestMethod]
        public void UpdatingExistingWillUpdateIt()
        {
            IToDoRepository repository = new ToDoRepository();
            var ToDoItem = new ToDoItem(" Groceries ");
            repository.Add(ToDoItem);
            ToDoItem.Text = "Groceries novo";
            repository.Update(ToDoItem);
            Assert.AreEqual(ToDoItem, repository.Get(ToDoItem.Id));
            Assert.AreEqual(1, repository.GetAll().Count);
        }
        [TestMethod]
        public void UpdatingNonExistingWillCreateIt()
        {
            IToDoRepository repository = new ToDoRepository();
            var ToDoItem = new ToDoItem(" Groceries ");
            var ToDoItem2 = new ToDoItem(" Groceries 1");
            repository.Add(ToDoItem);
            repository.Update(ToDoItem2);
            Assert.AreEqual(ToDoItem2, repository.Get(ToDoItem2.Id));
            Assert.AreEqual(2, repository.GetAll().Count);
        }
        //test metode za Update gotove


        //test metode za MarkAsCompleted
        [TestMethod]
        public void MarkingExisitingCompleteWillCompleteIt()
        {
            IToDoRepository repository = new ToDoRepository();
            var ToDoItem = new ToDoItem(" Groceries ");
            repository.Add(ToDoItem);
            ToDoItem.IsCompleted=true;
            ToDoItem.DateCompleted=DateTime.Now;
            Assert.AreEqual(true, repository.MarkAsCompleted(ToDoItem.Id));
            Assert.AreEqual(ToDoItem, repository.Get(ToDoItem.Id));
        }
        [TestMethod]
        public void MarkingNonExisitingCompleteReturnFalse()
        {
            IToDoRepository repository = new ToDoRepository();
            var ToDoItem = new ToDoItem(" Groceries ");
            var ToDoItem2 = new ToDoItem(" Groceries 1");
            repository.Add(ToDoItem);
            Assert.AreEqual(false, repository.MarkAsCompleted(ToDoItem2.Id));
        }
        //test metode za MarkAsComplete gotove


        //test metode za GetAll
        [TestMethod]
        public void GetAllReturnsAll()
        {
            List<ToDoItem> repository = new List<ToDoItem>();
            var ToDoItem = new ToDoItem(" Groceries ");
            repository.Add(ToDoItem);
            IToDoRepository repository2 = new ToDoRepository(repository);
            Assert.AreEqual(repository, repository2.GetAll());
        }
        //test metode za GetAll gotove


        //test metode za GetActive
        [TestMethod]
        public void GetActiveReturnsAllActive()
        {
            List<ToDoItem> repository = new List<ToDoItem>();
            var ToDoItem = new ToDoItem(" Groceries ");
            var ToDoItem2 = new ToDoItem(" Groceries 1");
            ToDoItem2.MarkAsCompleted();
            repository.Add(ToDoItem);
            IToDoRepository repository2 = new ToDoRepository();
            repository2.Add(ToDoItem);
            repository2.Add(ToDoItem2);
            Assert.AreEqual(true, repository.SequenceEqual(repository2.GetActive()));
        }
        //test metode za GetActive gotove


        //test metode za GetCompleted
        [TestMethod]
        public void GetCompletedReturnsAllCompleted()
        {
            List<ToDoItem> repository = new List<ToDoItem>();
            var ToDoItem = new ToDoItem(" Groceries ");
            var ToDoItem2 = new ToDoItem(" Groceries 1");
            ToDoItem.MarkAsCompleted();
            repository.Add(ToDoItem);
            IToDoRepository repository2 = new ToDoRepository();
            repository2.Add(ToDoItem);
            repository2.Add(ToDoItem2);
            Assert.AreEqual(true, repository.SequenceEqual(repository2.GetCompleted()));
        }
        //test metode za GetCompleted gotove


        //test metode za GetFiltered
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InputingNullFunctionThrowsException()
        {
            IToDoRepository repository = new ToDoRepository();
            var ToDoItem = new ToDoItem(" Groceries ");
            repository.Add(ToDoItem);
            repository.GetFiltered(null);
        }
        [TestMethod]
        public void InputingFunctionReturnsList()
        {
            IToDoRepository repository = new ToDoRepository();
            var ToDoItem = new ToDoItem(" Groceries ");
            repository.Add(ToDoItem);
            Assert.AreEqual(true, repository.GetAll().SequenceEqual(repository.GetFiltered(a=>a==a)));
        }
    }


}