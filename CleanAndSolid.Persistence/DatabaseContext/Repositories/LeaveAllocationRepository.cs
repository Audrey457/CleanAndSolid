using CleanAndSolid.Application.Contracts.Persistance;
using CleanAndSolid.Domain;

namespace CleanAndSolid.Persistence.DatabaseContext.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(CleanAndSolidDbContext context) : base(context)
        {
        }
    }
}
