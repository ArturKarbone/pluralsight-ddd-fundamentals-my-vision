using Ardalis.Specification;
using ClinicManagement.Core.Patiens.Domain;

namespace ClinicManagement.Core.Patiens.Specifications
{
  public class PatientByClientIdSpecification : Specification<Patient>
  {
    public PatientByClientIdSpecification(int clientId)
    {
      Query
          .Where(patient => patient.ClientId == clientId);

      Query.OrderBy(patient => patient.Name);
    }
  }
}
