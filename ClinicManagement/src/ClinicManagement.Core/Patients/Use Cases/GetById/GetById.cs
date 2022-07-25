using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlazorShared.Models.Patient;
using ClinicManagement.Core.Clients.Domain;
using ClinicManagement.Core.Clients.Specifications;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Patients.Use_Cases.GetById
{
  public interface IGetById
  {
    Task<GetByIdPatientResponse> HandleAsync(GetByIdPatientRequest request, CancellationToken cancellationToken);
  }

  public class GetById : IGetById
  {
    private readonly IRepository<Client> _repository;
    private readonly IMapper _mapper;

    public GetById(IRepository<Client> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }


    public async Task<GetByIdPatientResponse> HandleAsync(GetByIdPatientRequest request, CancellationToken cancellationToken)
    {
      var response = new GetByIdPatientResponse(request.CorrelationId);

      var spec = new ClientByIdIncludePatientsSpec(request.ClientId);
      var client = await _repository.GetBySpecAsync(spec);
      //TOOD: maybe not to return nulls here?
      if (client == null) return null;

      var patient = client.Patients.FirstOrDefault(p => p.Id == request.PatientId);
      if (patient == null) return null;

      response.Patient = _mapper.Map<PatientDto>(patient);

      return response;
    }
  }
}
