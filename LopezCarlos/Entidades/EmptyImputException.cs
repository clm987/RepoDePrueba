using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EmptyImputException : Exception
    {
        public EmptyImputException()
        {

        }

        public EmptyImputException(string message) : base(message)
        {

        }

        public EmptyImputException(string message, Exception innerException)
        {

        }
    }
}
