using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using BlazorShared.Models.Patient;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ClinicManagement.Core.Patients.Use_Cases.Delete;

namespace ClinicManagement.Api.PatientEndpoints
{
  public class Delete : BaseAsyncEndpoint
    .WithRequest<DeletePatientRequest>
    .WithResponse<DeletePatientResponse>
  {
    private readonly IDelete deleteUseCase;

    public Delete(IDelete deleteUseCase) =>
      this.deleteUseCase = deleteUseCase;


    [HttpDelete("api/patients/{id}")]
    [SwaggerOperation(
        Summary = "Deletes a Patient",
        Description = "Deletes a Patient",
        OperationId = "patients.delete",
        Tags = new[] { "PatientEndpoints" })
    ]
    public override async Task<ActionResult<DeletePatientResponse>> HandleAsync([FromRoute] DeletePatientRequest request, CancellationToken cancellationToken)
    {
      var response = await deleteUseCase.HandleAsync(request, cancellationToken);

      return response switch
      {
        null => NotFound(),
        DeletePatientResponse r => Ok(r)
      };    
    }
  }
}
