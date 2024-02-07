using CleanAndSolid.Application.Contracts.Persistance;
using CleanAndSolid.Application.Exceptions;
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
            if(leaveTypeToDelete == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }


            await leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            return Unit.Value;
        }
    }
}
