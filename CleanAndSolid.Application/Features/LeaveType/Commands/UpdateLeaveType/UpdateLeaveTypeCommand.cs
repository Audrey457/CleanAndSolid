using MediatR;

namespace CleanAndSolid.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }
    }
}
