using BlazorShared.Models;

namespace ClinicManagement.Core.Doctors.Use_Cases.Delete
{
  public class DeleteDoctorRequest : BaseRequest
  {
    public int Id { get; set; }
  }
}
