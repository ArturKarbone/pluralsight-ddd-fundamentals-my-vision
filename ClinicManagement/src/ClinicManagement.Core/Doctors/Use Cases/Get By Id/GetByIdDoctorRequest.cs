using BlazorShared.Models;

namespace ClinicManagement.Core.Doctors.Use_Cases.GetById
{
  public class GetByIdDoctorRequest : BaseRequest
  {
    public int DoctorId { get; set; }
  }
}
