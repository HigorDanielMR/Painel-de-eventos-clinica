using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Exceptions;

/// <summary>
/// Exception base para erros de validações de dominio
/// </summary>
public class DomainInvalidException : Exception
{
    public List<string> Errors { get; set; }

    public DomainInvalidException(List<string> errors)
    {
        Errors = errors;
    }

    public DomainInvalidException(string errors)
    {
        Errors = new List<string>() { errors };
    }
}
