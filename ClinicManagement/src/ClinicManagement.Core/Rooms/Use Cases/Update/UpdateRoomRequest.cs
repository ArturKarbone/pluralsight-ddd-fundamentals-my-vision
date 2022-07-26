using BlazorShared.Models;

namespace ClinicManagement.Core.Rooms.Use_Cases.Update
{
  public class UpdateRoomRequest : BaseRequest
  {
    public int RoomId { get; set; }
    public string Name { get; set; }
  }
}
