using CleanAndSolid.Application.Contracts.Persistance;
using CleanAndSolid.Domain;

namespace CleanAndSolid.Persistence.DatabaseContext.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(CleanAndSolidDbContext context) : base(context)
        {
        }

    }
}
