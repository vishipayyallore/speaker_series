using Address.Server.Entities;
using Address.Server.Persistence;
using Address.Server.Protos;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address.Server.Services
{
    public class AddressBookService : AddressBookServer.AddressBookServerBase
    {

        private readonly PersonDbContext _personDbContext;

        public AddressBookService(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }

        public override async Task<AddressAdditionResponse> AddUserAddress(AddressAdditionRequest request, ServerCallContext context)
        {
            var userAddress = new AddressData { Name = request.Name, Address = request.Address, Enrollment = request.Enrollment };

            _personDbContext.Add(userAddress);
            await _personDbContext.SaveChangesAsync();

            var results = new AddressAdditionResponse { Message = "Address Save Successfully." };

            return results;
        }
    }
}
