using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using ClinicManagement.Core.Rooms.Use_Cases.Update;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.RoomEndpoints
{
  public class Update : BaseAsyncEndpoint
    .WithRequest<UpdateRoomRequest>
    .WithResponse<UpdateRoomResponse>
  {
    private readonly IUpdate useCase;

    public Update(IUpdate useCase) =>
      this.useCase = useCase;


    [HttpPut("api/rooms")]
    [SwaggerOperation(
        Summary = "Updates a Room",
        Description = "Updates a Room",
        OperationId = "rooms.update",
        Tags = new[] { "RoomEndpoints" })
    ]
    public override async Task<ActionResult<UpdateRoomResponse>> HandleAsync(UpdateRoomRequest request, CancellationToken cancellationToken)
    {
      var response = await useCase.HandleAsync(request, cancellationToken);

      return Ok(response);
    }
  }
}
