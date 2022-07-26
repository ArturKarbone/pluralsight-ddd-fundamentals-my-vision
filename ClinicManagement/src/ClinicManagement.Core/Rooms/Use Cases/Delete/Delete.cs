using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagement.Core.Rooms.Domain;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Rooms.Use_Cases.Delete
{
  public interface IDelete
  {
    Task<DeleteRoomResponse> HandleAsync(DeleteRoomRequest request, CancellationToken cancellationToken);
  }

  public class Delete : IDelete
  {
    private readonly IRepository<Room> _repository;
    private readonly IMapper _mapper;

    public Delete(IRepository<Room> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<DeleteRoomResponse> HandleAsync(DeleteRoomRequest request, CancellationToken cancellationToken)
    {
      var response = new DeleteRoomResponse(request.CorrelationId);

      var toDelete = _mapper.Map<Room>(request);
      await _repository.DeleteAsync(toDelete);

      return response;
    }
  }
}
