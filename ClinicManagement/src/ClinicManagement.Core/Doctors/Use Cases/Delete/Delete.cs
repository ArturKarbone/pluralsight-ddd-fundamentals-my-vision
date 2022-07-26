using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagement.Core.Doctors.Domain;
using PluralsightDdd.SharedKernel.Interfaces;

namespace ClinicManagement.Core.Doctors.Use_Cases.Delete
{
  public interface IDelete
  {
    Task<DeleteDoctorResponse> HandleAsync(DeleteDoctorRequest request, CancellationToken cancellationToken);
  }

  public class Delete : IDelete
  {
    private readonly IRepository<Doctor> _repository;
    private readonly IMapper _mapper;

    public Delete(IRepository<Doctor> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }


    public async Task<DeleteDoctorResponse> HandleAsync(DeleteDoctorRequest request, CancellationToken cancellationToken)
    {
      var response = new DeleteDoctorResponse(request.CorrelationId);

      var toDelete = _mapper.Map<Doctor>(request);
      await _repository.DeleteAsync(toDelete);

      return response;
    }
  }
}
