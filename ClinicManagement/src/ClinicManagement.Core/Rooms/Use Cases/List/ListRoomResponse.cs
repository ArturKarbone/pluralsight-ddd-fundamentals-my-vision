using System;
using System.Collections.Generic;
using BlazorShared.Models;
using ClinicManagement.Core.Rooms.DTOs;

namespace ClinicManagement.Core.Rooms.Use_Cases.List
{
  public class ListRoomResponse : BaseResponse
  {
    public List<RoomDto> Rooms { get; set; } = new List<RoomDto>();

    public int Count { get; set; }

    public ListRoomResponse(Guid correlationId) : base(correlationId)
    {
    }

    public ListRoomResponse()
    {
    }
  }
}
