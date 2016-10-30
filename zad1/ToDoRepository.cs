using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing ToDoTtems .
    /// </ summary >
    public class ToDoRepository : IToDoRepository
    {
        /// <summary >
        /// Repository does not fetch ToDoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly List<ToDoItem> _inMemoryToDoDatabase;

        public ToDoRepository(List<ToDoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryToDoDatabase = initialDbState;
            }
            else
            {
                _inMemoryToDoDatabase = new List<ToDoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >() ;
            // x ?? y -> if x is not null , expression returns x. Else y.
        }

        public ToDoItem Get(Guid ToDoId)
        {
            if (ToDoId == null)
            {
                throw new ArgumentNullException();
            }
            return _inMemoryToDoDatabase.Where(a => a.Id == ToDoId).FirstOrDefault();
        }

        public void Add(ToDoItem ToDoItem)
        {
            if (ToDoItem == null)
            {
                throw new ArgumentNullException();
            }
            else if (_inMemoryToDoDatabase.Where(a => a == ToDoItem).FirstOrDefault() == null)
            {
                _inMemoryToDoDatabase.Add(ToDoItem);
            }
            else throw new DuplicateToDoItemException("There can't be two items of the same name");
        }


        public bool Remove(Guid ToDoId)
        {
            if (_inMemoryToDoDatabase.Where(a => a.Id == ToDoId).FirstOrDefault() != null)
            {
                _inMemoryToDoDatabase.Remove(_inMemoryToDoDatabase.Where(a => a.Id == ToDoId).FirstOrDefault());
                return true;
            }
            else return false;

        }

        public void Update(ToDoItem ToDoItem)
        {
            if (ToDoItem == null)
            {
                throw new ArgumentNullException();
            }

            if (_inMemoryToDoDatabase.Where(a => a.Id == ToDoItem.Id).FirstOrDefault() != null)
            {
                Remove(ToDoItem.Id);

            }
            _inMemoryToDoDatabase.Add(ToDoItem);
        }

        public bool MarkAsCompleted(Guid ToDoId)
        {
            if (_inMemoryToDoDatabase.Where(a => a.Id == ToDoId).FirstOrDefault() != null)
            {
                _inMemoryToDoDatabase.Where(a => a.Id == ToDoId).FirstOrDefault().MarkAsCompleted();
                return true;
            }
            return false;
        }

        public List<ToDoItem> GetAll()
        {
            if (_inMemoryToDoDatabase.Count == 0) return null;
            return _inMemoryToDoDatabase;
        }

        public List<ToDoItem> GetActive()
        {
            List<ToDoItem>retList=new List<ToDoItem>();
            retList.AddRange(_inMemoryToDoDatabase.Where(a => a.IsCompleted == false));
            if (retList.Count == 0) return null;
            return retList;
        }

        public List<ToDoItem> GetCompleted()
        {
            List<ToDoItem> retList = new List<ToDoItem>();
            retList.AddRange(_inMemoryToDoDatabase.Where(a => a.IsCompleted == true));
            if (retList.Count == 0) return null;
            return retList;
        }

        public List<ToDoItem> GetFiltered(Func<ToDoItem, bool> filterFunction)
        {
            List<ToDoItem> retList = new List<ToDoItem>();
            retList.AddRange(_inMemoryToDoDatabase.Where(filterFunction));
            if (retList.Count == 0) return null;
            return retList;
        }
    }
}

// implement ITodoRepository


