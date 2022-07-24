using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using BlazorShared.Models.Client;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ClinicManagement.Core.Clients.Use_Cases.List;

namespace ClinicManagement.Api.ClientEndpoints
{
  public class List : BaseAsyncEndpoint
    .WithRequest<ListClientRequest>
    .WithResponse<ListClientResponse>
  {
    private readonly IList listUseCase;

    public List(IList listUseCase) =>
      this.listUseCase = listUseCase;

    [HttpGet("api/clients")]
    [SwaggerOperation(
        Summary = "List Clients",
        Description = "List Clients",
        OperationId = "clients.List",
        Tags = new[] { "ClientEndpoints" })
    ]
    public override async Task<ActionResult<ListClientResponse>> HandleAsync([FromQuery] ListClientRequest request, CancellationToken cancellationToken)
    {
      var response = await listUseCase.HandleAsync(request, cancellationToken);

      return response switch
      {
        null => NotFound(),
        _ => response
      };
    }
  }
}
