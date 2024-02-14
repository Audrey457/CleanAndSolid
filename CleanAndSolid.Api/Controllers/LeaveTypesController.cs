using CleanAndSolid.Application.Features.LeaveType.Commands.CreateLeaveType;
using CleanAndSolid.Application.Features.LeaveType.Commands.DeleteLeaveType;
using CleanAndSolid.Application.Features.LeaveType.Commands.UpdateLeaveType;
using CleanAndSolid.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using CleanAndSolid.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanAndSolid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator mediator;

        public LeaveTypesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/<LeaveTypesController>
        [HttpGet]
        public async Task<List<LeaveTypeDto>> Get()
        {
            //Le médiator permet d'envoyer la requête et d'invoquer automatiquement le bon handler.
            var leaveTypes = await mediator.Send(new GetLeaveTypesQuery());
            return leaveTypes;
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<LeaveTypeDetailsDto> Get(int id)
        {
            var leaveType = await mediator.Send(new GetLeaveTypeDetailsQuery(id));
            return leaveType;
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        public async Task<int> Post([FromBody] LeaveTypeDto leaveType)
        {
            var leaveTypeId = await mediator.Send(new CreateLeaveTypeCommand { Name = leaveType.Name, DefaultDays = leaveType.DefaultDays });
            return leaveTypeId;
        }

        // PUT api/<LeaveTypesController>/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] LeaveTypeDto leaveType)
        {
            await mediator.Send(new UpdateLeaveTypeCommand { Id = id, Name = leaveType.Name, DefaultDays = leaveType.DefaultDays });
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            mediator.Send(new DeleteLeaveTypeCommand { Id = id });
        }
    }
}
