using System;
using BlazorShared.Models;
using ClinicManagement.Core.Rooms.DTOs;

namespace ClinicManagement.Core.Rooms.Use_Cases.GetById
{
  public class GetByIdRoomResponse : BaseResponse
  {
    public RoomDto Room { get; set; } = new RoomDto();

    public GetByIdRoomResponse(Guid correlationId) : base(correlationId)
    {
    }

    public GetByIdRoomResponse()
    {
    }
  }
}
