using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ardalis.HttpClientTestExtensions;
using ClinicManagement.Api;
using ClinicManagement.Core.Appointment_Types.Use_Cases.List;
using Xunit;
using Xunit.Abstractions;

namespace FunctionalTests.Api
{
  [Collection("Sequential")]
  public class AppointmentTypesList : IClassFixture<CustomWebApplicationFactory<Startup>>
  {
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _outputHelper;

    public AppointmentTypesList(CustomWebApplicationFactory<Startup> factory, ITestOutputHelper outputHelper)
    {
      _client = factory.CreateClient();
      _outputHelper = outputHelper;
    }

    [Fact]
    public async Task Returns3AppointmentTypes()
    {
      var result = await _client.GetAndDeserialize<ListAppointmentTypeResponse>("/api/appointment-types", _outputHelper);

      Assert.Equal(3, result.AppointmentTypes.Count());
      Assert.Contains(result.AppointmentTypes, x => x.Name == "Wellness Exam");
    }
  }
}
