using AutoMapper;
using CleanAndSolid.Application.Contracts.Logging;
using CleanAndSolid.Application.Contracts.Persistance;
using CleanAndSolid.Application.Exceptions;
using MediatR;

namespace CleanAndSolid.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IAppLogger<UpdateLeaveTypeCommandHandler> logger;

        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<UpdateLeaveTypeCommandHandler> logger)
        {
            this.mapper = mapper;
            this.leaveTypeRepository = leaveTypeRepository;
            this.logger = logger;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeCommandValidator(leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(LeaveType), request.Id);
                throw new BadRequestException("Invalid LeaveType", validationResult);
            }

            var leaveTypeToUpdate = mapper.Map<Domain.LeaveType>(request);
            await leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);
            return Unit.Value;
        }
    }
}
