using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using ClinicManagement.Core.Appointment_Types.Use_Cases.List;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.AppointmentTypeEndpoints
{
  public class List : BaseAsyncEndpoint
    .WithRequest<ListAppointmentTypeRequest>
    .WithResponse<ListAppointmentTypeResponse>
  {
    private readonly IList useCase;

    public List(IList useCase) =>
      this.useCase = useCase;

    [HttpGet("api/appointment-types")]
    [SwaggerOperation(
        Summary = "List Appointment Types",
        Description = "List Appointment Types",
        OperationId = "appointment-types.List",
        Tags = new[] { "AppointmentTypeEndpoints" })
    ]
    public override async Task<ActionResult<ListAppointmentTypeResponse>> HandleAsync([FromQuery] ListAppointmentTypeRequest request, CancellationToken cancellationToken)
    {
      var response = await useCase.HandleAsync(request, cancellationToken);

      return Ok(response);
    }
  }
}
