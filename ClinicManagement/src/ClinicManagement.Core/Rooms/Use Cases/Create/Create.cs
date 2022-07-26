using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagement.Core.Rooms.Domain;
using ClinicManagement.Core.Rooms.DTOs;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Rooms.Use_Cases.Create
{
  public interface ICreate
  {
    Task<CreateRoomResponse> HandleAsync(CreateRoomRequest request, CancellationToken cancellationToken);
  }

  public class Create : ICreate
  {
    private readonly IRepository<Room> _repository;
    private readonly IMapper _mapper;

    public Create(IRepository<Room> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }


    public async Task<CreateRoomResponse> HandleAsync(CreateRoomRequest request, CancellationToken cancellationToken)
    {
      var response = new CreateRoomResponse(request.CorrelationId);

      var toAdd = _mapper.Map<Room>(request);
      toAdd = await _repository.AddAsync(toAdd);

      var dto = _mapper.Map<RoomDto>(toAdd);
      response.Room = dto;

      return response;
    }
  }
}
