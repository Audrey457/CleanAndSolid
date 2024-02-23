using CleanAndSolid.Application.Contracts.Persistance;
using CleanAndSolid.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanAndSolid.Persistence.DatabaseContext.Repositories
{
    //Il faut hériter des deux car on a une custom méthode pour ILeaveTypeRepository, et GenericRepository correspond à l'implémentation des autres méthodes.
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(CleanAndSolidDbContext context) : base(context)
        {
        }

        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            return await context.LeaveTypes.AnyAsync(t => t.Name == name) == false;
        }
    }
}
