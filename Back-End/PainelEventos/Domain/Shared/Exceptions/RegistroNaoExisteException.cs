using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Exceptions
{
    public class RegistroNaoExisteException : Exception
    {

        public RegistroNaoExisteException() : base("Registro informado não existente") { }

        public RegistroNaoExisteException(string message) : base(message) { }
    }
}
