using Domain.Shared.Entity;

namespace Domain;

public abstract class Pessoa : EntityBase, IPessoaBase
{
    public abstract string Nome { get; set; }
    public abstract int Idade { get; set; }
    public abstract string Endereco { get; set; }
    public abstract string Telefone { get; set; }
    public abstract string CPF { get; set; }
    public abstract string Genero { get; set; }

    public bool CpfEhValido(string cpf)
    {
        return true;
    }

    public bool NomeEhValido(string nome)
    {
        return true;
    }

    public bool TelefoneEhValido(string telefone)
    {
        return true;
    }
}
