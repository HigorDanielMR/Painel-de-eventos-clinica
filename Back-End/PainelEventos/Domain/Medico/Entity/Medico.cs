using Domain;
using Domain.Shared.Validator;

namespace Domain.Entity
{
    public class Medico : Pessoa
    {
        public string CRM { get; set; }
        public override string Nome { get; set; }
        public override int Idade { get; set; }
        public override string Endereco { get; set; }
        public override string Telefone { get; set; }
        public override string CPF { get; set; }
        public override string Genero { get; set; }

        public Medico(string cRM, string nome, int idade, string endereco, string telefone, string cPF, string genero)
        {
            this.Id = Guid.NewGuid().ToString();
            CRM = cRM;
            Nome = nome;
            Idade = idade;
            Endereco = endereco;
            Telefone = telefone;
            CPF = cPF;
            Genero = genero;
            this.Validar();
        }

        public void Atualizar(string nome, int idade, string endereco, string telefone)
        {
            Nome = nome;
            Idade = idade;
            Endereco = endereco;
            Telefone = telefone;
            this.Validar();
        }

        protected override void Validar()
        {
            var validador = DomainValidator.Istanciar();

            validador.ValidarStringVaziaOuNula(this.Nome, "Nome não pode ser nulo.");
            validador.ValidarStringVaziaOuNula(this.Genero, "Gênero não pode ser nulo.");
            validador.ValidarStringVaziaOuNula(this.Endereco, "Endereço não pode ser nulo.");
            validador.Validar(() => this.Telefone.Length == 11, "Telefone não esta valido.");
            validador.Validar(() => this.CPF.Length == 11, "CPF não esta valido.");
            validador.Validar(() => this.CRM.Trim().Length == 12, "CRM não esta valida.");
            validador.Validar(() => this.Idade > 0, "Idade tem que ser maior do que zero.");

            validador.ThrowSePossuiErro();
        }
    }
}