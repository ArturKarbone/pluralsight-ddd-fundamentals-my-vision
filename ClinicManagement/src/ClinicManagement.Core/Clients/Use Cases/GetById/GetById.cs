using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlazorShared.Models.Client;
using ClinicManagement.Core.Clients.Domain;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Clients.Use_Cases.GetById
{
  public interface IGetById
  {
    Task<GetByIdClientResponse> HandleAsync(GetByIdClientRequest request, CancellationToken cancellationToken);
  }

  public class GetById : IGetById
  {
    private readonly IRepository<Client> _repository;
    private readonly IMapper _mapper;

    public GetById(IRepository<Client> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<GetByIdClientResponse> HandleAsync(GetByIdClientRequest request, CancellationToken cancellationToken)
    {
      var response = new GetByIdClientResponse(request.CorrelationId);

      var client = await _repository.GetByIdAsync(request.ClientId);
      if (client is null)
        return null;

      response.Client = _mapper.Map<ClientDto>(client);
      return response;
    }
  }
}
