using BlazorShared.Models;

namespace ClinicManagement.Core.Rooms.Use_Cases.Delete
{
  public class DeleteRoomRequest : BaseRequest
  {
    public int Id { get; set; }
  }
}
