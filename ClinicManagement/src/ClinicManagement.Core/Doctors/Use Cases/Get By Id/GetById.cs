using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagement.Core.Doctors.Domain;
using ClinicManagement.Core.Doctors.DTOs;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Doctors.Use_Cases.GetById
{
  public interface IGetById
  {
    Task<GetByIdDoctorResponse> HandleAsync(GetByIdDoctorRequest request, CancellationToken cancellationToken);
  }

  public class GetById : IGetById
  {
    private readonly IRepository<Doctor> _repository;
    private readonly IMapper _mapper;

    public GetById(IRepository<Doctor> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<GetByIdDoctorResponse> HandleAsync(GetByIdDoctorRequest request, CancellationToken cancellationToken)
    {
      var response = new GetByIdDoctorResponse(request.CorrelationId);

      var doctor = await _repository.GetByIdAsync(request.DoctorId);
      if (doctor is null) return null;

      response.Doctor = _mapper.Map<DoctorDto>(doctor);

      return response;
    }
  }
}
