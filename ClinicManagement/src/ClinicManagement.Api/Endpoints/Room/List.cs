using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using ClinicManagement.Core.Rooms.Use_Cases.List;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.RoomEndpoints
{
  public class List : BaseAsyncEndpoint
    .WithRequest<ListRoomRequest>
    .WithResponse<ListRoomResponse>
  {
    private readonly IList useCase;

    public List(IList useCase) =>
      this.useCase = useCase;


    [HttpGet("api/rooms")]
    [SwaggerOperation(
        Summary = "List Rooms",
        Description = "List Rooms",
        OperationId = "rooms.List",
        Tags = new[] { "RoomEndpoints" })
    ]
    public override async Task<ActionResult<ListRoomResponse>> HandleAsync([FromQuery] ListRoomRequest request, CancellationToken cancellationToken)
    {
      var response = await useCase.HandleAsync(request, cancellationToken);

      return response switch
      {
        null => NotFound(),
        _ => Ok(response)
      };
    }
  }
}
