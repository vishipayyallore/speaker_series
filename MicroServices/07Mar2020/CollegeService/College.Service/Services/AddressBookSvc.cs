using College.Service.Entities;
using College.Service.Persistence;
using College.Service.Protos;
using Grpc.Core;
using System.Threading.Tasks;

namespace College.Service.Services
{
    public class AddressBookSvc : AddressBookService.AddressBookServiceBase
    {

        private readonly PersonDbContext _personDbContext;

        public AddressBookSvc(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }

        public override async Task<HealthResponse> AddPersonHealthData(HealthRequest request, ServerCallContext context)
        {
            var healthData = new HealthData { Name = request.Name, HealthParameter1 = request.HealthParameter1, HealthParameter2 = request.HealthParameter2 };

            _personDbContext.Health.Add(healthData);
            await _personDbContext.SaveChangesAsync();

            var results = new HealthResponse { Message = "Health Data Save Successfully." };

            return results;
        }

        public override async Task<AddressAdditionResponse> AddUserAddress(AddressAdditionRequest request, ServerCallContext context)
        {
            var userAddress = new AddressData { Name = request.Name, Address = request.Address };

            _personDbContext.Add(userAddress);
            await _personDbContext.SaveChangesAsync();

            var results = new AddressAdditionResponse { Message = "Address Save Successfully." };

            return results;
        }

    }

}
