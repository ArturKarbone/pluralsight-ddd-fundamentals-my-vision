using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicManagement.Core.Appointment_Types.DTOs;
using ClinicManagement.Core.Appointment_Types.Use_Cases.List;
using Microsoft.Extensions.Logging;

namespace ClinicManagement.Blazor.Services
{
  public class AppointmentTypeService
  {
    private readonly HttpService _httpService;
    private readonly ILogger<AppointmentTypeService> _logger;

    public AppointmentTypeService(HttpService httpService, ILogger<AppointmentTypeService> logger)
    {
      _httpService = httpService;
      _logger = logger;
    }

    public async Task<List<AppointmentTypeDto>> ListPagedAsync(int pageSize)
    {
      _logger.LogInformation("Fetching appointment types from API.");

      return (await _httpService.HttpGetAsync<ListAppointmentTypeResponse>($"appointment-types")).AppointmentTypes;
    }

    public async Task<List<AppointmentTypeDto>> ListAsync()
    {
      _logger.LogInformation("Fetching appointment types from API.");

      return (await _httpService.HttpGetAsync<ListAppointmentTypeResponse>($"appointment-types")).AppointmentTypes;
    }
  }
}
