using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using ClinicManagement.Core.Rooms.Use_Cases.GetById;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicManagement.Api.RoomEndpoints
{
  public class GetById : BaseAsyncEndpoint
    .WithRequest<GetByIdRoomRequest>
    .WithResponse<GetByIdRoomResponse>
  {
    private readonly IGetById useCase;


    public GetById(IGetById useCase) =>
      this.useCase = useCase;


    [HttpGet("api/rooms/{RoomId}")]
    [SwaggerOperation(
        Summary = "Get a Room by Id",
        Description = "Gets a Room by Id",
        OperationId = "rooms.GetById",
        Tags = new[] { "RoomEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdRoomResponse>> HandleAsync([FromRoute] GetByIdRoomRequest request, CancellationToken cancellationToken)
    {
      var response = useCase.HandleAsync(request, cancellationToken);

      return response switch
      {
        null => NotFound(),
        _ => Ok(response)
      };
    }
  }
}
