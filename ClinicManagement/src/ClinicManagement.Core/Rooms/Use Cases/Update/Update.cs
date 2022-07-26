using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagement.Core.Rooms.Domain;
using ClinicManagement.Core.Rooms.DTOs;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Rooms.Use_Cases.Update
{
  public interface IUpdate
  {
    Task<UpdateRoomResponse> HandleAsync(UpdateRoomRequest request, CancellationToken cancellationToken);
  }

  public class Update : IUpdate
  {
    private readonly IRepository<Room> _repository;
    private readonly IMapper _mapper;

    public Update(IRepository<Room> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }


    public async Task<UpdateRoomResponse> HandleAsync(UpdateRoomRequest request, CancellationToken cancellationToken)
    {
      var response = new UpdateRoomResponse(request.CorrelationId);

      var toUpdate = _mapper.Map<Room>(request);
      await _repository.UpdateAsync(toUpdate);

      var dto = _mapper.Map<RoomDto>(toUpdate);
      response.Room = dto;

      return response;
    }
  }
}
