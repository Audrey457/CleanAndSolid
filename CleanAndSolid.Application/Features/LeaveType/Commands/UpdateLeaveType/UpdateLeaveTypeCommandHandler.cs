using AutoMapper;
using CleanAndSolid.Application.Contracts.Persistance;
using CleanAndSolid.Application.Exceptions;
using MediatR;

namespace CleanAndSolid.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this.mapper = mapper;
            this.leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeCommandValidator(leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid LeaveType", validationResult);

            var leaveTypeToUpdate = mapper.Map<Domain.LeaveType>(request);
            await leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);
            return Unit.Value;
        }
    }
}
