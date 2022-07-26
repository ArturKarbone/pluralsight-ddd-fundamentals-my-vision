using AutoMapper;
using ClinicManagement.Core.Rooms.Domain;
using ClinicManagement.Core.Rooms.DTOs;
using ClinicManagement.Core.Rooms.Use_Cases.Create;
using ClinicManagement.Core.Rooms.Use_Cases.Delete;
using ClinicManagement.Core.Rooms.Use_Cases.Update;

namespace ClinicManagement.Api.MappingProfiles
{
  public class RoomProfile : Profile
  {
    public RoomProfile()
    {
      CreateMap<Room, RoomDto>()
          .ForMember(dto => dto.RoomId, options => options.MapFrom(src => src.Id));
      CreateMap<RoomDto, Room>()
          .ForMember(dto => dto.Id, options => options.MapFrom(src => src.RoomId));
      CreateMap<CreateRoomRequest, Room>();
      CreateMap<UpdateRoomRequest, Room>()
          .ForMember(dto => dto.Id, options => options.MapFrom(src => src.RoomId));
      CreateMap<DeleteRoomRequest, Room>();
    }
  }
}
