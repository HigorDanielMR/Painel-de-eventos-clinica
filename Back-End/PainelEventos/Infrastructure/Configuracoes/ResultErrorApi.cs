using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuracoes;

public class ResultErrorApi
{
    public string Descricao { get; set; }

    public List<string> Erros { get; set; } = new List<string>();

    public void AddError(string error)
    {

        Erros.Add(error);
    }
}

