using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using ClinicManagement.Core.Doctors.Use_Cases.List;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.DoctorEndpoints
{
  public class List : BaseAsyncEndpoint
    .WithRequest<ListDoctorRequest>
    .WithResponse<ListDoctorResponse>
  {
    private readonly IList useCase;

    public List(IList useCase) =>
      this.useCase = useCase;

    [HttpGet("api/doctors")]
    [SwaggerOperation(
        Summary = "List Doctors",
        Description = "List Doctors",
        OperationId = "doctors.List",
        Tags = new[] { "DoctorEndpoints" })
    ]
    public override async Task<ActionResult<ListDoctorResponse>> HandleAsync([FromQuery] ListDoctorRequest request, CancellationToken cancellationToken)
    {
      var response = await useCase.HandleAsync(request, cancellationToken);
      return response switch
      {
        null => NotFound(),
        _ => Ok(response)
      };
    }
  }
}
