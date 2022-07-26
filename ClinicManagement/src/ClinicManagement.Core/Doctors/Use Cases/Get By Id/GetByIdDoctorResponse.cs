using System;
using BlazorShared.Models;
using ClinicManagement.Core.Doctors.DTOs;

namespace ClinicManagement.Core.Doctors.Use_Cases.GetById
{
  public class GetByIdDoctorResponse : BaseResponse
  {
    public DoctorDto Doctor { get; set; } = new DoctorDto();

    public GetByIdDoctorResponse(Guid correlationId) : base(correlationId)
    {
    }

    public GetByIdDoctorResponse()
    {
    }
  }
}
