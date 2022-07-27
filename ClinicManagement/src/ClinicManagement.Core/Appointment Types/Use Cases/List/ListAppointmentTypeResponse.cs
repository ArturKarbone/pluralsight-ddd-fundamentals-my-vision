using System;
using System.Collections.Generic;
using BlazorShared.Models;
using ClinicManagement.Core.Appointment_Types.DTOs;

namespace ClinicManagement.Core.Appointment_Types.Use_Cases.List
{
  public class ListAppointmentTypeResponse : BaseResponse
  {
    public List<AppointmentTypeDto> AppointmentTypes { get; set; } = new List<AppointmentTypeDto>();

    public int Count { get; set; }

    public ListAppointmentTypeResponse(Guid correlationId) : base(correlationId)
    {
    }

    public ListAppointmentTypeResponse()
    {
    }
  }
}
