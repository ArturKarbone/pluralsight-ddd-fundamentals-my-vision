using System;
using BlazorShared.Models;

namespace ClinicManagement.Core.Rooms.Use_Cases.Delete
{
  public class DeleteRoomResponse : BaseResponse
  {
    public DeleteRoomResponse(Guid correlationId) : base(correlationId)
    {
    }

    public DeleteRoomResponse()
    {
    }
  }
}
