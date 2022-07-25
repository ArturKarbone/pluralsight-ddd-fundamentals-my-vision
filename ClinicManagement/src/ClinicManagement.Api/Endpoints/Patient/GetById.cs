using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using BlazorShared.Models.Patient;
using ClinicManagement.Core.Patients.Use_Cases.GetById;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.PatientEndpoints
{
  public class GetById : BaseAsyncEndpoint
    .WithRequest<GetByIdPatientRequest>
    .WithResponse<GetByIdPatientResponse>
  {
    private readonly IGetById getByIdUseCase;
    private readonly IMapper _mapper;

    public GetById(IGetById getByIdUseCase) =>
      this.getByIdUseCase = getByIdUseCase;

    [HttpGet("api/patients/{PatientId}")]
    [SwaggerOperation(
        Summary = "Get a Patient by Id with ClientId (via querystring)",
        Description = "Gets a Patient by Id",
        OperationId = "patients.GetById",
        Tags = new[] { "PatientEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdPatientResponse>> HandleAsync([FromRoute] GetByIdPatientRequest request,
      CancellationToken cancellationToken)
    {
      var response = await getByIdUseCase.HandleAsync(request, cancellationToken);

      return response switch
      {
        null => NotFound(),
        _ => Ok(response)
      };
    }
  }
}
