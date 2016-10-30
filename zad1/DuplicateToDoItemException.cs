using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    public class DuplicateToDoItemException : Exception
    {
        public DuplicateToDoItemException()
        {

        }

        public DuplicateToDoItemException(string message)
            : base(message)
        {

        }

        public DuplicateToDoItemException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}

