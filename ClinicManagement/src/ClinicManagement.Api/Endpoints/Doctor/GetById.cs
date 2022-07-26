using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using ClinicManagement.Core.Doctors.Use_Cases.GetById;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.DoctorEndpoints
{
  public class GetById : BaseAsyncEndpoint
    .WithRequest<GetByIdDoctorRequest>
    .WithResponse<GetByIdDoctorResponse>
  {
    private readonly IGetById useCase;

    public GetById(IGetById useCase) =>
      this.useCase = useCase;


    [HttpGet("api/doctors/{DoctorId}")]
    [SwaggerOperation(
        Summary = "Get a Doctor by Id",
        Description = "Gets a Doctor by Id",
        OperationId = "doctors.GetById",
        Tags = new[] { "DoctorEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdDoctorResponse>> HandleAsync([FromRoute] GetByIdDoctorRequest request, CancellationToken cancellationToken)
    {
      var response = await useCase.HandleAsync(request, cancellationToken);

      return Ok(response);
    }
  }
}
