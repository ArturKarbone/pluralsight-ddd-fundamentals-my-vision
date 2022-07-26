using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using ClinicManagement.Core.Doctors.Use_Cases.Update;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.DoctorEndpoints
{
  public class Update : BaseAsyncEndpoint
    .WithRequest<UpdateDoctorRequest>
    .WithResponse<UpdateDoctorResponse>
  {
    private readonly IUpdate useCase;

    public Update(IUpdate useCase) =>
      this.useCase = useCase;


    [HttpPut("api/doctors")]
    [SwaggerOperation(
        Summary = "Updates a Doctor",
        Description = "Updates a Doctor",
        OperationId = "doctors.update",
        Tags = new[] { "DoctorEndpoints" })
    ]
    public override async Task<ActionResult<UpdateDoctorResponse>> HandleAsync(UpdateDoctorRequest request, CancellationToken cancellationToken)
    {
      var response = await useCase.HandleAsync(request, cancellationToken);
      return Ok(response);
    }
  }
}
