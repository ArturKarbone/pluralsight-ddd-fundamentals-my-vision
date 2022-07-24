using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlazorShared.Models.Client;
using ClinicManagement.Core.Clients.Domain;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Clients.Use_Cases.Create
{
  public interface ICreate
  {
    Task<CreateClientResponse> HandleAsync(CreateClientRequest request, CancellationToken cancellationToken);
  }

  public class Create : ICreate
  {
    private readonly IRepository<Client> _repository;
    private readonly IMapper _mapper;

    public Create(IRepository<Client> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<CreateClientResponse> HandleAsync(CreateClientRequest request, CancellationToken cancellationToken)
    {
      var response = new CreateClientResponse(request.CorrelationId);

      var toAdd = _mapper.Map<Client>(request);
      toAdd = await _repository.AddAsync(toAdd);

      var dto = _mapper.Map<ClientDto>(toAdd);
      response.Client = dto;

      return response;
    }
  }
}
