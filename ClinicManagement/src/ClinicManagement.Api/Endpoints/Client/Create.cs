using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using BlazorShared.Models.Client;
using ClinicManagement.Core.Clients.Use_Cases.Create;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.ClientEndpoints
{
  public class Create : BaseAsyncEndpoint
    .WithRequest<CreateClientRequest>
    .WithResponse<CreateClientResponse>
  {

    private readonly ICreate createUsecase;

    public Create(ICreate createUsecase)
    {
      this.createUsecase = createUsecase;
    }

    [HttpPost("api/clients")]
    [SwaggerOperation(
        Summary = "Creates a new Client",
        Description = "Creates a new Client",
        OperationId = "clients.create",
        Tags = new[] { "ClientEndpoints" })
    ]
    public override async Task<ActionResult<CreateClientResponse>> HandleAsync(CreateClientRequest request, CancellationToken cancellationToken)
    {
      var response = await createUsecase.HandleAsync(request, cancellationToken);

      return Ok(response);
    }
  }
}
