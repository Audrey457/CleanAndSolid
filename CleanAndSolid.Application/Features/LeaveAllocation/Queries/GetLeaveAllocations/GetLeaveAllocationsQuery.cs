﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAndSolid.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations
{
    public record GetLeaveAllocationsQuery : IRequest<List<LeaveAllocationDto>>;
}
