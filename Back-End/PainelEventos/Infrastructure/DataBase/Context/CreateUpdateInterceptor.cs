using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Domain.Shared.Entity;

namespace Infrastructure.DataBase.Context
{
    public class CreateUpdateInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
        {
            if (eventData.Context is not null)
            {
                AuditableEntities(eventData.Context);
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private static void AuditableEntities(DbContext context)
        {
            var entities = context.ChangeTracker.Entries<EntityBase>().ToList();

            foreach (EntityEntry<EntityBase> entry in entities)
            {
                EntityBase entityBase = entry.Entity;

                if (entry.State == EntityState.Added)
                    entityBase.AdicionarDataCriacao();

                if (entry.State == EntityState.Modified)
                    entityBase.AdicionarDataAtualizacao();
            }
        }

    }
}
