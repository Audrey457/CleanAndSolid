using AutoMapper;
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
