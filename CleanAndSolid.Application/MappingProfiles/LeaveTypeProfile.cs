using AutoMapper;
using CleanAndSolid.Application.Features.LeaveType.Commands.CreateLeaveType;
using CleanAndSolid.Application.Features.LeaveType.Commands.UpdateLeaveType;
using CleanAndSolid.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using CleanAndSolid.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using CleanAndSolid.Domain;

namespace CleanAndSolid.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
            CreateMap<LeaveType, CreateLeaveTypeCommand>().ReverseMap();
            CreateMap<LeaveType, UpdateLeaveTypeCommand>().ReverseMap();
        }

    }
}
