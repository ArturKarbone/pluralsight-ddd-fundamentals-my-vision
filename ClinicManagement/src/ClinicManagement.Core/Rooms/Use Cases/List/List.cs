using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagement.Core.Rooms.Domain;
using ClinicManagement.Core.Rooms.DTOs;
using ClinicManagement.Core.Specifications;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Rooms.Use_Cases.List
{
  public interface IList
  {
    Task<ListRoomResponse> HandleAsync(ListRoomRequest request, CancellationToken cancellationToken);
  }

  public class List : IList
  {
    private readonly IRepository<Room> _repository;
    private readonly IMapper _mapper;

    public List(IRepository<Room> repository,
      IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<ListRoomResponse> HandleAsync(ListRoomRequest request, CancellationToken cancellationToken)
    {
      var response = new ListRoomResponse(request.CorrelationId);

      var roomSpec = new RoomSpecification();
      var rooms = await _repository.ListAsync(roomSpec);
      if (rooms is null) return null;

      response.Rooms = _mapper.Map<List<RoomDto>>(rooms);
      response.Count = response.Rooms.Count;

      return response;
    }
  }
}
