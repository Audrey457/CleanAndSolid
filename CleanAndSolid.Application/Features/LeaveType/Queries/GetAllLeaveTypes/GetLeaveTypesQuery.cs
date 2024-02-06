using MediatR;

namespace CleanAndSolid.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    //On peut utiliser record car ce sera immutable.
    public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;
}
