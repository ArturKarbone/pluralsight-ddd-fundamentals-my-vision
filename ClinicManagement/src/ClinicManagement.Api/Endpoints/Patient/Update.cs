using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using BlazorShared.Models.Patient;
using ClinicManagement.Core.Patients.Use_Cases.Update;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.PatientEndpoints
{
  public class Update : BaseAsyncEndpoint
    .WithRequest<UpdatePatientRequest>
    .WithResponse<UpdatePatientResponse>
  {
    private readonly IUpdate updateUseCase;

    public Update(IUpdate updateUseCase) =>
      this.updateUseCase = updateUseCase;

    [HttpPut("api/patients")]
    [SwaggerOperation(
        Summary = "Updates a Patient",
        Description = "Updates a Patient",
        OperationId = "patients.update",
        Tags = new[] { "PatientEndpoints" })
    ]
    public override async Task<ActionResult<UpdatePatientResponse>> HandleAsync(UpdatePatientRequest request, CancellationToken cancellationToken)
    {
      var response = await updateUseCase.HandleAsync(request, cancellationToken);

      return response switch
      {
        null => NotFound(),
        _ => Ok(response)
      };
    }
  }
}
