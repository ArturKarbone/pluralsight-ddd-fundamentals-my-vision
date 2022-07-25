using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlazorShared.Models.Patient;
using ClinicManagement.Core.Clients.Domain;
using ClinicManagement.Core.Clients.Specifications;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Patients.Use_Cases.Delete
{
  public interface IDelete
  {
    Task<DeletePatientResponse> HandleAsync(DeletePatientRequest request, CancellationToken cancellationToken);
  }

  public class Delete : IDelete
  {
    private readonly IRepository<Client> _repository;
    private readonly IMapper _mapper;

    public Delete(IRepository<Client> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<DeletePatientResponse> HandleAsync(DeletePatientRequest request, CancellationToken cancellationToken)
    {
      var response = new DeletePatientResponse(request.CorrelationId);

      var spec = new ClientByIdIncludePatientsSpec(request.ClientId);
      var client = await _repository.GetBySpecAsync(spec);
      if (client == null) return null;

      var patientToDelete = client.Patients.FirstOrDefault(p => p.Id == request.PatientId);
      client.Patients.Remove(patientToDelete);

      await _repository.UpdateAsync(client);

      return response;
    }
  }
}
