﻿using System.Linq;
using System.Threading.Tasks;
using ClinicManagement.Core.Clients.Domain;
using ClinicManagement.Infrastructure.Data;
using UnitTests.Builders;
using Xunit;

namespace IntegrationTests.ClientTests
{
  public class EfRepositoryList : BaseEfRepoTestFixture
  {
    private readonly EfRepository<Client> _repository;

    public EfRepositoryList()
    {
      _repository = GetRepository<Client>();
    }

    [Fact]
    public async Task ListsClientAfterAddingIt()
    {
      await AddClient();

      var clients = await _repository.ListAsync();

      Assert.True(clients?.Count > 0);
    }

    private async Task<Client> AddClient()
    {
      var client = new ClientBuilder().Id(7).Build();

      await _repository.AddAsync(client);

      return client;
    }
  }
}
