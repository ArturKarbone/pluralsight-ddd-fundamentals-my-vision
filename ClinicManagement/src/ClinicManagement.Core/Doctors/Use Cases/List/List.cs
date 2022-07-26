using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagement.Core.Doctors.Domain;
using ClinicManagement.Core.Doctors.DTOs;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Doctors.Use_Cases.List
{
  public interface IList
  {
    Task<ListDoctorResponse> HandleAsync(ListDoctorRequest request, CancellationToken cancellationToken);
  }

  public class List : IList
  {
    private readonly IRepository<Doctor> _repository;
    private readonly IMapper _mapper;

    public List(IRepository<Doctor> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }


    public async Task<ListDoctorResponse> HandleAsync(ListDoctorRequest request, CancellationToken cancellationToken)
    {
      var response = new ListDoctorResponse(request.CorrelationId);

      var doctors = await _repository.ListAsync();
      if (doctors is null) return null;

      response.Doctors = _mapper.Map<List<DoctorDto>>(doctors);
      response.Count = response.Doctors.Count;

      return response;
    }
  }
}
