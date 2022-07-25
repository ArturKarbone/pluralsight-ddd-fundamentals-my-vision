using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlazorShared.Models.Patient;
using ClinicManagement.Core.Clients.Domain;
using ClinicManagement.Core.Clients.Specifications;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Patients.Use_Cases.Update
{
  public interface IUpdate
  {
    Task<UpdatePatientResponse> HandleAsync(UpdatePatientRequest request, CancellationToken cancellationToken);
  }

  public class Update : IUpdate
  {
    private readonly IRepository<Client> _repository;
    private readonly IMapper _mapper;

    public Update(IRepository<Client> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }


    public async Task<UpdatePatientResponse> HandleAsync(UpdatePatientRequest request, CancellationToken cancellationToken)
    {
      var response = new UpdatePatientResponse(request.CorrelationId);

      var spec = new ClientByIdIncludePatientsSpec(request.ClientId);
      var client = await _repository.GetBySpecAsync(spec);
      if (client == null) return null;

      var patientToUpdate = client.Patients.FirstOrDefault(p => p.Id == request.PatientId);
      if (patientToUpdate == null) return null;

      patientToUpdate.Name = request.Name;

      await _repository.UpdateAsync(client);

      var dto = _mapper.Map<PatientDto>(patientToUpdate);
      response.Patient = dto;

      return response;
    }
  }
}
