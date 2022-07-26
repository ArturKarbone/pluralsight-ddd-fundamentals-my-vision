using System;
using BlazorShared.Models;
using ClinicManagement.Core.Rooms.DTOs;

namespace ClinicManagement.Core.Rooms.Use_Cases.Update
{
  public class UpdateRoomResponse : BaseResponse
  {
    public RoomDto Room { get; set; } = new RoomDto();

    public UpdateRoomResponse(Guid correlationId) : base(correlationId)
    {
    }

    public UpdateRoomResponse()
    {
    }
  }
}
