namespace Domain.Shared.Entity
{
    public abstract class EntityBase
    {
        public string Id { get; set; }
        public DateTime DataCriacao { get; protected set; }
        public DateTime DataAtualizacao { get; protected set; }

        public void AdicionarDataCriacao()
        {
            DataCriacao = DateTime.Now;
        }

        public void AdicionarDataAtualizacao()
        {
            DataAtualizacao = DateTime.Now;
        }
    }
}