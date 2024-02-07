using CleanAndSolid.Application.Contracts.Persistance;
using MediatR;

namespace CleanAndSolid.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository) => 
            this.leaveTypeRepository = leaveTypeRepository;
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveTypeToDelete = await leaveTypeRepository.GetByIdAsync(request.Id);
            
            //Vérifier que l'enregistrement existe

            await leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            return Unit.Value;
        }
    }
}
