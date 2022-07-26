using System;
using BlazorShared.Models;
using ClinicManagement.Core.Doctors.DTOs;

namespace ClinicManagement.Core.Doctors.Use_Cases.Create
{
  public class CreateDoctorResponse : BaseResponse
  {
    public DoctorDto Doctor { get; set; } = new DoctorDto();

    public CreateDoctorResponse(Guid correlationId) : base(correlationId)
    {
    }

    public CreateDoctorResponse()
    {
    }
  }
}
