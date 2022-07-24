using System.Threading.Tasks;
using ClinicManagement.Core.Clients.Domain;
using ClinicManagement.Infrastructure.Data;
using UnitTests.Builders;
using Xunit;

namespace IntegrationTests.ClientTests
{
  public class EfRepositoryDelete : BaseEfRepoTestFixture
  {
    private readonly EfRepository<Client> _repository;

    public EfRepositoryDelete()
    {
      _repository = GetRepository<Client>();
    }

    [Fact]
    public async Task DeletesClientAfterAddingIt()
    {
      var id = 8;

      var client = await AddClient(id);
      await _repository.DeleteAsync(client);

      Assert.DoesNotContain(await _repository.ListAsync(),
          i => i.Id == id);
    }

    private async Task<Client> AddClient(int id)
    {
      var client = new ClientBuilder().Id(id).Build();

      await _repository.AddAsync(client);

      return client;
    }
  }
}
