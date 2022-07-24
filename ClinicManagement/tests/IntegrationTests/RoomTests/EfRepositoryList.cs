using System.Linq;
using System.Threading.Tasks;
using ClinicManagement.Infrastructure.Data;
using UnitTests.Builders;
using Xunit;
using ClinicManagement.Core.Rooms.Domain;

namespace IntegrationTests.RoomTests
{
  public class EfRepositoryList : BaseEfRepoTestFixture
  {
    private readonly EfRepository<Room> _repository;

    public EfRepositoryList()
    {
      _repository = GetRepository<Room>();
    }

    [Fact]
    public async Task ListsRoomAfterAddingIt()
    {
      await AddRoom();

      var rooms = await _repository.ListAsync();

      Assert.True(rooms?.Count > 0);
    }

    private async Task<Room> AddRoom()
    {
      var room = new RoomBuilder().Id(7).Build();

      await _repository.AddAsync(room);

      return room;
    }
  }
}
