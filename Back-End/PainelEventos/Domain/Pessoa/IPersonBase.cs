namespace Domain;

public interface IPessoaBase
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string CPF { get; set; }
    public string Genero { get; set; }
}