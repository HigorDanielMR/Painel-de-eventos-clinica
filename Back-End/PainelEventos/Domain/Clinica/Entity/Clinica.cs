using Domain.Shared.Entity;

namespace Domain.Entity
{
    public class Clinica : EntityBase
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
    }
}