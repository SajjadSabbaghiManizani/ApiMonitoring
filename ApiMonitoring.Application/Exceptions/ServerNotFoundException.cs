using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMonitoring.Application.Exceptions
{
    public class ServerNotFoundException : Exception
    {
        public ServerNotFoundException() : base("Server not found.")
        {
        }

        public ServerNotFoundException(string message) : base(message)
        {
        }

        public ServerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

}
