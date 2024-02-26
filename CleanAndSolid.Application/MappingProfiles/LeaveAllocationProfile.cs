using AutoMapper;
using CleanAndSolid.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using CleanAndSolid.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAndSolid.Application.MappingProfiles
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ForMember(a => a.LeaveType, m => m.MapFrom(s => s.LeaveType));
        }
    }
}
