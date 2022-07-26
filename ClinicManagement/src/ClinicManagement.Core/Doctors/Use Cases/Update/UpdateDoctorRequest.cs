using BlazorShared.Models;

namespace ClinicManagement.Core.Doctors.Use_Cases.Update
{
  public class UpdateDoctorRequest : BaseRequest
  {
    public int DoctorId { get; set; }
    public string Name { get; set; }
  }
}
