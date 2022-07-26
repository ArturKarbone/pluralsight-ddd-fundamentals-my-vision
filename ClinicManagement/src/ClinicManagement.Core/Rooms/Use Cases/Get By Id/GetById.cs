using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagement.Core.Rooms.Domain;
using ClinicManagement.Core.Rooms.DTOs;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Rooms.Use_Cases.GetById
{
  public interface IGetById
  {
    Task<GetByIdRoomResponse> HandleAsync(GetByIdRoomRequest request, CancellationToken cancellationToken);
  }

  public class GetById : IGetById
  {
    private readonly IRepository<Room> _repository;
    private readonly IMapper _mapper;

    public GetById(IRepository<Room> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }


    public async Task<GetByIdRoomResponse> HandleAsync(GetByIdRoomRequest request, CancellationToken cancellationToken)
    {
      var response = new GetByIdRoomResponse(request.CorrelationId);

      var room = await _repository.GetByIdAsync(request.RoomId);
      if (room is null) return null;

      response.Room = _mapper.Map<RoomDto>(room);

      return response;
    }
  }
}
