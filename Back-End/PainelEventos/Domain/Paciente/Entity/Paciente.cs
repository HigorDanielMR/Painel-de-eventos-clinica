using Domain.Shared.Entity;
using Domain.Shared.Interface;

namespace Domain.Entity
{
    public class Paciente : EntityBase, IPersonBase
    {
        string IPersonBase.Nome { get; set; }
        int IPersonBase.Idade { get; set; }
        string IPersonBase.Endereco { get; set; }
        string IPersonBase.Telefone { get; set; }
        string IPersonBase.CPF { get; set; }
        string IPersonBase.Genero { get; set; }
        public string NumeroCartaoSUS { get; set; }
    }
}