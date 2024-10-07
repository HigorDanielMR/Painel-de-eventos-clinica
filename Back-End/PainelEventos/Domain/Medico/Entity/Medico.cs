using Domain.Shared.Entity;

namespace Domain.Entity
{
    public class Medico : Person
    {
        public string CRM { get; set; }
        public override string Nome { get; set; }
        public override int Idade { get; set; }
        public override string Endereco { get; set; }
        public override string Telefone { get; set; }
        public override string CPF { get; set; }
        public override string Genero { get; set; }
    }
}