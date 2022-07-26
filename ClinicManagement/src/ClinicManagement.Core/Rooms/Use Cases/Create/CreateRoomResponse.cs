using System;
using BlazorShared.Models;
using ClinicManagement.Core.Rooms.DTOs;

namespace ClinicManagement.Core.Rooms.Use_Cases.Create
{
  public class CreateRoomResponse : BaseResponse
  {
    public RoomDto Room { get; set; } = new RoomDto();

    public CreateRoomResponse(Guid correlationId) : base(correlationId)
    {
    }

    public CreateRoomResponse()
    {
    }
  }
}
