using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using ClinicManagement.Core.Doctors.Use_Cases.Create;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.DoctorEndpoints
{
  public class Create : BaseAsyncEndpoint
    .WithRequest<CreateDoctorRequest>
    .WithResponse<CreateDoctorResponse>
  {
    private readonly ICreate useCase;

    public Create(ICreate useCase) =>
      this.useCase = useCase;


    [HttpPost("api/doctors")]
    [SwaggerOperation(
        Summary = "Creates a new Doctor",
        Description = "Creates a new Doctor",
        OperationId = "doctors.create",
        Tags = new[] { "DoctorEndpoints" })
    ]
    public override async Task<ActionResult<CreateDoctorResponse>> HandleAsync(CreateDoctorRequest request, CancellationToken cancellationToken)
    {
      var response = await useCase.HandleAsync(request, cancellationToken);
      return Ok(response);     
    }
  }
}
