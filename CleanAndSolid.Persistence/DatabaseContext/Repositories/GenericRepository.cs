using CleanAndSolid.Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CleanAndSolid.Persistence.DatabaseContext.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
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
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
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
