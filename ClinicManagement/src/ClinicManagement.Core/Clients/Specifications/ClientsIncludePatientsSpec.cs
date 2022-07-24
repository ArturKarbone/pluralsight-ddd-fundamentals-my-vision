using Ardalis.Specification;
using ClinicManagement.Core.Clients.Domain;

namespace ClinicManagement.Core.Clients.Specifications
{
  public class ClientsIncludePatientsSpec : Specification<Client>
  {
    public ClientsIncludePatientsSpec()
    {
      Query
        .Include(client => client.Patients)
        .OrderBy(client => client.FullName);
    }
  }
}
