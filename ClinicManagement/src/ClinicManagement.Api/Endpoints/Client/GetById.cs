using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using BlazorShared.Models.Client;
using ClinicManagement.Core.Clients.Use_Cases.GetById;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.ClientEndpoints
{
  public class GetById : BaseAsyncEndpoint
    .WithRequest<GetByIdClientRequest>
    .WithResponse<GetByIdClientResponse>
  {
    private readonly IGetById getByIdUseCase;
    public GetById(IGetById getByIdUseCase)
    {
      this.getByIdUseCase = getByIdUseCase;
    }

    [HttpGet("api/clients/{ClientId}")]
    [SwaggerOperation(
        Summary = "Get a Client by Id",
        Description = "Gets a Client by Id",
        OperationId = "clients.GetById",
        Tags = new[] { "ClientEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdClientResponse>> HandleAsync([FromRoute] GetByIdClientRequest request, CancellationToken cancellationToken)
    {
      var response = await getByIdUseCase.HandleAsync(request, cancellationToken);

      if (response is null)
        return NotFound();

      return Ok(response);
    }
  }
}
