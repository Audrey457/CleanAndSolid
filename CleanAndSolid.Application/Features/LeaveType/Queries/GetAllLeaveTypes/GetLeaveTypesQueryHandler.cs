using AutoMapper;
using CleanAndSolid.Application.Contracts.Persistance;
using MediatR;

namespace CleanAndSolid.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this.mapper = mapper;
            this.leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var leaveTypes = await leaveTypeRepository.GetAsync();

            //Convert data objects to Dto Objects
            var data = mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            //return list of DTO Objet
            return data;
        }
    }
}
