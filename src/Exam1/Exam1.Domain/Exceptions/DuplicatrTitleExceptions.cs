using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Domain.Exceptions
{
    public class DuplicatrTitleExceptions : Exception
    {
        public DuplicatrTitleExceptions() : base("Title is Duplicate") { }
    }
}
