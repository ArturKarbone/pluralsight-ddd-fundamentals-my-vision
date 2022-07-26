using BlazorShared.Models;

namespace ClinicManagement.Core.Rooms.Use_Cases.Create
{
  public class CreateRoomRequest : BaseRequest
  {
    public string Name { get; set; }

    public override string ToString()
    {
      return $"Room: Name = {Name}";
    }
  }
}
