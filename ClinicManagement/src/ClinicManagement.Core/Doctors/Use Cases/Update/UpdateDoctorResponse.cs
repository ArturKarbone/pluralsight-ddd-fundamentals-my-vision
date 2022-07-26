using System;
using BlazorShared.Models;
using ClinicManagement.Core.Doctors.DTOs;

namespace ClinicManagement.Core.Doctors.Use_Cases.Update
{
  public class UpdateDoctorResponse : BaseResponse
  {
    public DoctorDto Doctor { get; set; } = new DoctorDto();

    public UpdateDoctorResponse(Guid correlationId) : base(correlationId)
    {
    }

    public UpdateDoctorResponse()
    {
    }
  }
}
