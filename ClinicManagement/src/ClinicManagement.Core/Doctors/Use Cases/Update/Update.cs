using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagement.Core.Doctors.Domain;
using ClinicManagement.Core.Doctors.DTOs;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Doctors.Use_Cases.Update
{
  public interface IUpdate
  {
    Task<UpdateDoctorResponse> HandleAsync(UpdateDoctorRequest request, CancellationToken cancellationToken);
  }

  public class Update : IUpdate
  {
    private readonly IRepository<Doctor> _repository;
    private readonly IMapper _mapper;

    public Update(IRepository<Doctor> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<UpdateDoctorResponse> HandleAsync(UpdateDoctorRequest request, CancellationToken cancellationToken)
    {
      var response = new UpdateDoctorResponse(request.CorrelationId);

      var toUpdate = _mapper.Map<Doctor>(request);
      await _repository.UpdateAsync(toUpdate);

      var dto = _mapper.Map<DoctorDto>(toUpdate);
      response.Doctor = dto;

      return response;
    }
  }
}
