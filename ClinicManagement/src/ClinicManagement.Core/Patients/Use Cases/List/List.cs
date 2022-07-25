using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlazorShared.Models.Patient;
using ClinicManagement.Core.Clients.Domain;
using ClinicManagement.Core.Clients.Specifications;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Patients.Use_Cases.List
{
  public interface IList
  {
    Task<ListPatientResponse> HandleAsync(ListPatientRequest request, CancellationToken cancellationToken);
  }

  public class List : IList
  {
    private readonly IRepository<Client> _repository;
    private readonly IMapper _mapper;

    public List(IRepository<Client> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<ListPatientResponse> HandleAsync(ListPatientRequest request, CancellationToken cancellationToken)
    {
      var response = new ListPatientResponse(request.CorrelationId);

      var spec = new ClientByIdIncludePatientsSpec(request.ClientId);
      var client = await _repository.GetBySpecAsync(spec);
      if (client == null) return null;

      response.Patients = _mapper.Map<List<PatientDto>>(client.Patients);
      response.Count = response.Patients.Count;

      return response;
    }
  }
}
