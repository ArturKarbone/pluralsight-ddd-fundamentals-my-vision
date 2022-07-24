using PluralsightDdd.SharedKernel;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Rooms.Domain
{
  public class Room : BaseEntity<int>, IAggregateRoot
  {
    public string Name { get; set; }

    public Room(int id, string name)
    {
      Id = id;
      Name = name;
    }

    public override string ToString()
    {
      return Name;
    }
  }
}
