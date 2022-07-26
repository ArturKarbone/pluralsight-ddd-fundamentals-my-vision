using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using ClinicManagement.Core.Rooms.Use_Cases.Delete;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.RoomEndpoints
{
  public class Delete : BaseAsyncEndpoint
    .WithRequest<DeleteRoomRequest>
    .WithResponse<DeleteRoomResponse>
  {
    private readonly IDelete useCase;

    public Delete(IDelete useCase) =>
      this.useCase = useCase;

    [HttpDelete("api/rooms/{id}")]
    [SwaggerOperation(
        Summary = "Deletes a Room",
        Description = "Deletes a Room",
        OperationId = "rooms.delete",
        Tags = new[] { "RoomEndpoints" })
    ]
    public override async Task<ActionResult<DeleteRoomResponse>> HandleAsync([FromRoute] DeleteRoomRequest request, CancellationToken cancellationToken)
    {
      var response = await useCase.HandleAsync(request, cancellationToken);
      return Ok(response);
    }
  }
}
