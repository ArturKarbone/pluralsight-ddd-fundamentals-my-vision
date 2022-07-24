using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlazorShared.Models.Client;
using ClinicManagement.Core.Clients.Domain;
using ClinicManagement.Core.Clients.Specifications;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Clients.Use_Cases.List
{
  public interface IList
  {
    Task<ListClientResponse> HandleAsync(ListClientRequest request, CancellationToken cancellationToken);
  }

  public class List : IList
  {
    private readonly IRepository<Client> _repository;
    private readonly IMapper _mapper;

    public List(IRepository<Client> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }


    public async Task<ListClientResponse> HandleAsync(ListClientRequest request, CancellationToken cancellationToken)
    {
      var response = new ListClientResponse(request.CorrelationId);

      var spec = new ClientsIncludePatientsSpec();
      var clients = await _repository.ListAsync(spec);
      if (clients is null) return null;

      response.Clients = _mapper.Map<List<ClientDto>>(clients);
      response.Count = response.Clients.Count;

      return response;
    }
  }
}
