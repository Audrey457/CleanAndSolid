using AutoMapper;
using CleanAndSolid.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using CleanAndSolid.Domain;

namespace CleanAndSolid.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
        }

    }
}
