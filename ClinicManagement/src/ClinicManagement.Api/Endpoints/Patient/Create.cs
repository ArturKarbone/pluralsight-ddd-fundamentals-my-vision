using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using BlazorShared.Models.Patient;
using ClinicManagement.Core.Patients.Use_Cases.Create;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.PatientEndpoints
{
  public class Create : BaseAsyncEndpoint
    .WithRequest<CreatePatientRequest>
    .WithResponse<CreatePatientResponse>
  {
    private readonly ICreate createUseCase;

    public Create(ICreate createUseCase)
    {
      this.createUseCase = createUseCase;
    }

    [HttpPost("api/patients")]
    [SwaggerOperation(
        Summary = "Creates a new Patient",
        Description = "Creates a new Patient",
        OperationId = "patients.create",
        Tags = new[] { "PatientEndpoints" })
    ]
    public override async Task<ActionResult<CreatePatientResponse>> HandleAsync(CreatePatientRequest request, CancellationToken cancellationToken)
    {

      var response = await createUseCase.HandleAsync(request, cancellationToken);

      return response switch
      {
        null => NotFound(),
        _ => Ok(response)
      };
    }
  }
}
