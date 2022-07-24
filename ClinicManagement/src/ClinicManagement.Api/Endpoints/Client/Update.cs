using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using BlazorShared.Models.Client;
using ClinicManagement.Core.Clients.Use_Cases.Update;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.ClientEndpoints
{
  public class Update : BaseAsyncEndpoint
    .WithRequest<UpdateClientRequest>
    .WithResponse<UpdateClientResponse>
  {
    private readonly IUpdate updateUseCase;

    public Update(IUpdate updateUseCase) =>
      this.updateUseCase = updateUseCase;


    [HttpPut("api/clients")]
    [SwaggerOperation(
        Summary = "Updates a Client",
        Description = "Updates a Client",
        OperationId = "clients.update",
        Tags = new[] { "ClientEndpoints" })
    ]
    public override async Task<ActionResult<UpdateClientResponse>> HandleAsync(UpdateClientRequest request, CancellationToken cancellationToken)
    {
      var response = await updateUseCase.HandleAsync(request, cancellationToken);
      return Ok(response);
    }
  }
}
