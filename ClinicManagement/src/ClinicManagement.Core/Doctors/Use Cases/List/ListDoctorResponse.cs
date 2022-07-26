using System;
using System.Collections.Generic;
using BlazorShared.Models;
using ClinicManagement.Core.Doctors.DTOs;

namespace ClinicManagement.Core.Doctors.Use_Cases.List
{
  public class ListDoctorResponse : BaseResponse
  {
    public List<DoctorDto> Doctors { get; set; } = new List<DoctorDto>();

    public int Count { get; set; }

    public ListDoctorResponse(Guid correlationId) : base(correlationId)
    {
    }

    public ListDoctorResponse()
    {
    }
  }
}
