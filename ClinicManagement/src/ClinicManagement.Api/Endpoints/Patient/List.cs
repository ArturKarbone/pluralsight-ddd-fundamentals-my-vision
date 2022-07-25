using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using BlazorShared.Models.Patient;
using ClinicManagement.Core.Patients.Use_Cases.List;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.PatientEndpoints
{
  public class List : BaseAsyncEndpoint
    .WithRequest<ListPatientRequest>
    .WithResponse<ListPatientResponse>
  {
    private readonly IList listUseCase;

    public List(IList listUseCase) =>
      this.listUseCase = listUseCase;


    [HttpGet("api/patients")]
    [SwaggerOperation(
        Summary = "List Patients",
        Description = "List Patients",
        OperationId = "patients.List",
        Tags = new[] { "PatientEndpoints" })
    ]
    public override async Task<ActionResult<ListPatientResponse>> HandleAsync([FromQuery] ListPatientRequest request, CancellationToken cancellationToken)
    {
      var response = await listUseCase.HandleAsync(request, cancellationToken);

      return response switch
      {
        null => NotFound(),
        _ => Ok(response)
      };
    }
  }
}
