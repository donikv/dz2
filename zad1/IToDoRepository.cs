using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    public interface IToDoRepository
    {
        /// <summary >
        /// Gets ToDoItem for a given id
        /// </ summary >
        /// <returns > ToDoItem if found , null otherwise </ returns >
        ToDoItem Get(Guid ToDoId);

    /// <summary >
        /// Adds new ToDoItem object in database .
        /// If object with the same id already exists ,
        /// method should throw DuplicateToDoItemException with the message
        ///" duplicate id: {id }".
        /// </ summary >
        void Add(ToDoItem ToDoItem);
        /// <summary >
        /// Tries to remove a ToDoItem with given id from the database .
        /// </ summary >
        /// <returns > True if success , false otherwise </ returns >
        bool Remove(Guid ToDoId);
        /// <summary >
        /// Updates given ToDoItem in database .
        /// If ToDoItem does not exist , method will add one .
        /// </ summary >
        void Update(ToDoItem ToDoItem);
        /// <summary >
        /// Tries to mark a ToDoItem as completed in database .
        /// </ summary >
        /// <returns > True if success , false otherwise </ returns >
        bool MarkAsCompleted(Guid ToDoId);
        /// <summary >
        /// Gets all ToDoItem objects in database , sorted by date created
        /// </ summary >
        List<ToDoItem> GetAll();
        /// <summary >
        /// Gets all incomplete ToDoItem objects in database
        /// </ summary >
        List<ToDoItem> GetActive();
        /// <summary >
        /// Gets all completed ToDoItem objects in database
        /// </ summary >
        List<ToDoItem> GetCompleted();
        /// <summary >
        /// Gets all ToDoItem objects in database that apply to the filter
        /// </ summary >
        List<ToDoItem> GetFiltered(Func<ToDoItem, bool> filterFunction);
    }

}
