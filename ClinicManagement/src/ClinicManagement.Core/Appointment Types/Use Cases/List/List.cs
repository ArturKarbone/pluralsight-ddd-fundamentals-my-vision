using ClinicManagement.Core.Appointment_Types.Use_Cases.List;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagement.Core.Appointment_Types.Domain;
using ClinicManagement.Core.Appointment_Types.DTOs;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Appointment_Types.Use_Cases.List
{
  public interface IList
  {
    Task<ListAppointmentTypeResponse> HandleAsync(ListAppointmentTypeRequest request, CancellationToken cancellationToken);
  }

  public class List : IList
  {
    private readonly IRepository<AppointmentType> _repository;
    private readonly IMapper _mapper;

    public List(IRepository<AppointmentType> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }


    public async Task<ListAppointmentTypeResponse> HandleAsync(ListAppointmentTypeRequest request, CancellationToken cancellationToken)
    {
      var response = new ListAppointmentTypeResponse(request.CorrelationId);

      var appointmentTypes = await _repository.ListAsync();
      response.AppointmentTypes = _mapper.Map<List<AppointmentTypeDto>>(appointmentTypes);
      response.Count = response.AppointmentTypes.Count;

      return response;
    }
  }
}
