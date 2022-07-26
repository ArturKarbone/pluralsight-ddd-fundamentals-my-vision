using BlazorShared.Models;

namespace ClinicManagement.Core.Doctors.Use_Cases.Create
{
  public class CreateDoctorRequest : BaseRequest
  {
    public string Name { get; set; }
  }
}
