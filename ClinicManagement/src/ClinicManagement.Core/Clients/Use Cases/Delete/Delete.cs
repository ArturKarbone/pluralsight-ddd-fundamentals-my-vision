using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlazorShared.Models.Client;
using ClinicManagement.Core.Clients.Domain;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Clients.Use_Cases.Delete
{
  public interface IDelete
  {
    Task<DeleteClientResponse> HandleAsync(DeleteClientRequest request, CancellationToken cancellationToken);
  }

  public class Delete : IDelete
  {
    private readonly IRepository<Client> _repository;
    private readonly IMapper _mapper;

    public Delete(IRepository<Client> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    //TODO: research CancellationToken
    public async Task<DeleteClientResponse> HandleAsync(DeleteClientRequest request, CancellationToken cancellationToken)
    {
      var response = new DeleteClientResponse(request.CorrelationId);

      var toDelete = _mapper.Map<Client>(request);
      await _repository.DeleteAsync(toDelete);

      return response;
    }
  }
}
