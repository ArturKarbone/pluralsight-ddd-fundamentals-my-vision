using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlazorShared.Models.Patient;
using ClinicManagement.Core.Clients.Domain;
using ClinicManagement.Core.Clients.Specifications;
using ClinicManagement.Core.Patiens.Domain;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Patients.Use_Cases.Create
{
  public interface ICreate
  {
    Task<CreatePatientResponse> HandleAsync(CreatePatientRequest request, CancellationToken cancellationToken);
  }

  public class Create : ICreate
  {
    private readonly IRepository<Client> _repository;
    private readonly IMapper _mapper;

    public Create(IRepository<Client> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<CreatePatientResponse> HandleAsync(CreatePatientRequest request, CancellationToken cancellationToken)
    {
      var response = new CreatePatientResponse(request.CorrelationId);

      var spec = new ClientByIdIncludePatientsSpec(request.ClientId);
      var client = await _repository.GetBySpecAsync(spec);
      if (client == null) return null;

      // right now we only add huskies
      var newPatient = new Patient
      {
        ClientId = client.Id,
        Name = request.PatientName,
        AnimalType = new AnimalType("Dog", "Husky")
      };
      client.Patients.Add(newPatient);

      await _repository.UpdateAsync(client);

      var dto = _mapper.Map<PatientDto>(newPatient);
      response.Patient = dto;

      return response;
    }
  }
}
