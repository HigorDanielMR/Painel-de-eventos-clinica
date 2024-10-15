using Domain;
using Domain.Shared.Validator;

namespace Domain.Entity
{
    public class Paciente : Pessoa
    {
        public string NumeroCartaoSUS { get; set; }
        public override string Nome { get; set; }
        public override int Idade { get; set; }
        public override string Endereco { get; set; }
        public override string Telefone { get; set; }
        public override string CPF { get; set; }
        public override string Genero { get; set; }

        public Paciente(string numeroCartaoSUS, string nome, int idade, string endereco, string telefone, string cPF, string genero) : base()
        {
            this.Id = Guid.NewGuid().ToString();
            NumeroCartaoSUS = numeroCartaoSUS;
            Nome = nome;
            Idade = idade;
            Endereco = endereco;
            Telefone = telefone;
            CPF = cPF;
            Genero = genero;
            this.Validar();
        }

        public void Atualizar(string nome, int idade, string genero)
        {
            Nome = nome;
            Idade = idade;
            Genero = genero;
            this.Validar();
        }

        protected override void Validar()
        {
            var validador = DomainValidator.Istanciar();

            validador.ValidarStringVaziaOuNula(this.NumeroCartaoSUS, "Número do cartão do sus não pode ser nulo");
            validador.ValidarStringVaziaOuNula(this.Nome, "Nome não pode ser nulo");
            validador.ValidarStringVaziaOuNula(this.Endereco, "Endereço não pode ser nulo");
            validador.ValidarStringVaziaOuNula(this.Telefone, "Telefone não pode ser nulo");
            validador.ValidarStringVaziaOuNula(this.CPF, "CPF não pode ser nulo");
            validador.ValidarStringVaziaOuNula(this.Genero, "Gênero não pode ser nulo");
            validador.Validar(() => this.CPF.Length == 11, "CPF não está valido");
            validador.Validar(() => this.Telefone.Length == 11, "Telefone não está valido");
            validador.Validar(() => this.Idade <= 0, "Idade deve ser maior ou igual a zero");

            validador.ThrowSePossuiErro();
        }
    }
}