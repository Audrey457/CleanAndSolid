using AutoMapper;
using CleanAndSolid.Application.Contracts.Logging;
using CleanAndSolid.Application.Contracts.Persistance;
using CleanAndSolid.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAndSolid.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations
{
    public class GetLeaveAllocationsQueryHandler : IRequestHandler<GetLeaveAllocationsQuery, List<LeaveAllocationDto>>
    {
        private readonly IMapper mapper;
        private readonly ILeaveAllocationRepository repository;
        private readonly IAppLogger<GetLeaveAllocationsQueryHandler> logger;

        public GetLeaveAllocationsQueryHandler(IMapper mapper, ILeaveAllocationRepository repository, IAppLogger<GetLeaveAllocationsQueryHandler> logger)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationsQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocations = await repository.GetAsync();

            //Convert data objects to Dto Objects
            var data = mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

            //return list of DTO Objet
            logger.LogInformation("Leave allocations were retrieved successfully");
            return data;
        }
    }
}
