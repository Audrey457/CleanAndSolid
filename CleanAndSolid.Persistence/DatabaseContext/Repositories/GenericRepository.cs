using CleanAndSolid.Application.Contracts.Persistance;
using CleanAndSolid.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanAndSolid.Persistence.DatabaseContext.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        //Protected => c'est le repository générique, il faut donc que les classes qui vont en hériter puissent y accéder.
        protected readonly CleanAndSolidDbContext context;

        public GenericRepository(CleanAndSolidDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            //Set<T> car générique => on ne sait pas quelle entité on cherche.
            //On n'a pas besoin de traquer donc on peut ajouter AsNoTracking pour gagner en performance.
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            //Autre façon de faire, car on a override SaveChangesAsync c'est un peu plus efficient de passer pas le change de l'entitystate.
            //context.Update(entity);
            
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
