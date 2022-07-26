using BlazorShared.Models;

namespace ClinicManagement.Core.Rooms.Use_Cases.GetById
{
  public class GetByIdRoomRequest : BaseRequest
  {
    public int RoomId { get; set; }
  }
}
