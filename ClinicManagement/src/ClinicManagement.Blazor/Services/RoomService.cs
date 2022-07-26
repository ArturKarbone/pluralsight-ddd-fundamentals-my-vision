using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicManagement.Core.Rooms.DTOs;
using ClinicManagement.Core.Rooms.Use_Cases.Create;
using ClinicManagement.Core.Rooms.Use_Cases.Delete;
using ClinicManagement.Core.Rooms.Use_Cases.GetById;
using ClinicManagement.Core.Rooms.Use_Cases.List;
using ClinicManagement.Core.Rooms.Use_Cases.Update;
using Microsoft.Extensions.Logging;

namespace ClinicManagement.Blazor.Services
{
  public class RoomService
  {
    private readonly HttpService _httpService;
    private readonly ILogger<RoomService> _logger;

    public RoomService(HttpService httpService, ILogger<RoomService> logger)
    {
      _httpService = httpService;
      _logger = logger;
    }

    public async Task<RoomDto> CreateAsync(CreateRoomRequest room)
    {
      _logger.LogInformation($"Creating room: {room}");
      return (await _httpService.HttpPostAsync<CreateRoomResponse>("rooms", room)).Room;
    }

    public async Task<RoomDto> EditAsync(UpdateRoomRequest room)
    {
      return (await _httpService.HttpPutAsync<UpdateRoomResponse>("rooms", room)).Room;
    }

    public async Task DeleteAsync(int roomId)
    {
      await _httpService.HttpDeleteAsync<DeleteRoomResponse>("rooms", roomId);
    }

    public async Task<RoomDto> GetByIdAsync(int roomId)
    {
      return (await _httpService.HttpGetAsync<GetByIdRoomResponse>($"rooms/{roomId}")).Room;
    }

    public async Task<List<RoomDto>> ListPagedAsync(int pageSize)
    {
      _logger.LogInformation("Fetching rooms from API.");

      return (await _httpService.HttpGetAsync<ListRoomResponse>($"rooms")).Rooms;
    }

    public async Task<List<RoomDto>> ListAsync()
    {
      _logger.LogInformation("Fetching rooms from API.");

      return (await _httpService.HttpGetAsync<ListRoomResponse>($"rooms")).Rooms;
    }
  }
}
