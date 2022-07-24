using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using BlazorShared.Models.Client;
using ClinicManagement.Core.Clients.Use_Cases.Delete;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.ClientEndpoints
{
  public class Delete : BaseAsyncEndpoint
    .WithRequest<DeleteClientRequest>
    .WithResponse<DeleteClientResponse>
  {
    private readonly IDelete deleteUsecase;

    public Delete(IDelete deleteUsecase) =>
      (this.deleteUsecase) = (deleteUsecase);

    [HttpDelete("api/clients/{id}")]
    [SwaggerOperation(
        Summary = "Deletes a Client",
        Description = "Deletes a Client",
        OperationId = "clients.delete",
        Tags = new[] { "ClientEndpoints" })
    ]
    public override async Task<ActionResult<DeleteClientResponse>> HandleAsync([FromRoute] DeleteClientRequest request, CancellationToken cancellationToken) =>
       Ok(await deleteUsecase.HandleAsync(request, cancellationToken));

  }
}
