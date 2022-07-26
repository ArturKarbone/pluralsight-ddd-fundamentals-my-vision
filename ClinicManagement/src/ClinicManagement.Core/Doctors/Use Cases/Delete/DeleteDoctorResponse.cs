using System;
using BlazorShared.Models;

namespace ClinicManagement.Core.Doctors.Use_Cases.Delete
{
  public class DeleteDoctorResponse : BaseResponse
  {

    public DeleteDoctorResponse(Guid correlationId) : base(correlationId)
    {
    }

    public DeleteDoctorResponse()
    {
    }
  }
}
