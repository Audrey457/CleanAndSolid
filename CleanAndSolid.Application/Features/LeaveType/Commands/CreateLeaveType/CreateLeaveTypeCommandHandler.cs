using AutoMapper;
using CleanAndSolid.Application.Contracts.Persistance;
using MediatR;

namespace CleanAndSolid.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this.mapper = mapper;
            this.leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Valider les données entrantes

            //Convertir vers l'entity domain
            var leaveTypeToCreate = mapper.Map<Domain.LeaveType>(request);

            //Ajouter à la bdd
            await leaveTypeRepository.CreateAsync(leaveTypeToCreate);

            //Retourner l'id de l'enregistrement
            return leaveTypeToCreate.Id;
        }
    }
}
