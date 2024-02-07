using AutoMapper;
using CleanAndSolid.Application.Contracts.Persistance;
using CleanAndSolid.Application.Exceptions;
using MediatR;

namespace CleanAndSolid.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public GetLeaveTypeDetailQueryHandler(IMapper mapper,  ILeaveTypeRepository leaveTypeRepository)
        {
            this.mapper = mapper;
            this.leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveType = await leaveTypeRepository.GetByIdAsync(request.Id);
            if (leaveType == null)
                throw new NotFoundException(nameof(LeaveType), request.Id);
            var data = mapper.Map<LeaveTypeDetailsDto>(leaveType);
            return data;
        }
    }
}
