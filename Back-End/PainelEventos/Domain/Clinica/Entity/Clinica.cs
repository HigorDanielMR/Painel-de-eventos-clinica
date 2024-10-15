using Domain.Shared.Entity;
using Domain.Shared.Validator;

namespace Domain.Entity
{
    public class Clinica : EntityBase
    {
        public string Nome { get; protected set; }
        public string CNPJ { get; protected set; }

        public Clinica(string nome, string cNPJ)
        {
            this.Id = Guid.NewGuid().ToString();
            Nome = nome;
            CNPJ = cNPJ;
            this.Validar();
        }

        public void Atualizar(string nome)
        {
            Nome = nome;
            this.Validar();
        }

        protected override void Validar()
        {
            var validator = DomainValidator.Istanciar();

            validator.ValidarStringVaziaOuNula(this.Nome, "Nome não pode ser nulo!");
            validator.ValidarStringVaziaOuNula(this.CNPJ, "CNPJ não pode ser nulo!");
            validator.Validar(() => this.CNPJ.Length == 14, "CNPJ Não está valido!");

            validator.ThrowSePossuiErro();
        }
    }
}