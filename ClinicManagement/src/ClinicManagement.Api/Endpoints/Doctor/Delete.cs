using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using ClinicManagement.Core.Doctors.Use_Cases.Delete;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.DoctorEndpoints
{
  public class Delete : BaseAsyncEndpoint
    .WithRequest<DeleteDoctorRequest>
    .WithResponse<DeleteDoctorResponse>
  {
    private readonly IDelete useCase;


    public Delete(IDelete useCase) =>
      this.useCase = useCase;


    [HttpDelete("api/doctors/{id}")]
    [SwaggerOperation(
        Summary = "Deletes a Doctor",
        Description = "Deletes a Doctor",
        OperationId = "doctors.delete",
        Tags = new[] { "DoctorEndpoints" })
    ]
    public override async Task<ActionResult<DeleteDoctorResponse>> HandleAsync([FromRoute] DeleteDoctorRequest request, CancellationToken cancellationToken)
    {
      var response = await useCase.HandleAsync(request, cancellationToken);
      return Ok(response);
    }
  }
}
