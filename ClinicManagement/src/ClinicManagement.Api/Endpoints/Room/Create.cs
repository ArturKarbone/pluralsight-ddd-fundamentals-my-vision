using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using ClinicManagement.Core.Rooms.Use_Cases.Create;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.RoomEndpoints
{
  public class Create : BaseAsyncEndpoint
    .WithRequest<CreateRoomRequest>
    .WithResponse<CreateRoomResponse>
  {
    private readonly ICreate createUseCase;

    public Create(ICreate createUseCase) =>
      this.createUseCase = createUseCase;


    [HttpPost("api/rooms")]
    [SwaggerOperation(
        Summary = "Creates a new Room",
        Description = "Creates a new Room",
        OperationId = "rooms.create",
        Tags = new[] { "RoomEndpoints" })
    ]
    public override async Task<ActionResult<CreateRoomResponse>> HandleAsync(CreateRoomRequest request, CancellationToken cancellationToken)
    {
      var response = await createUseCase.HandleAsync(request, cancellationToken);

      return Ok(response);
    }
  }
}
