﻿using Address.Server.Entities;
using Address.Server.Persistence;
using Address.Server.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Address.Server.Services
{

    public class AddressBookService : AddressBookServer.AddressBookServerBase
    {
        private readonly PersonDbContext _personDbContext;
        private readonly string[] _enrollmentStatus = { "Pending", "In Progress", "Rejected", "Enrolled" };

        public AddressBookService(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }

        public override async Task<AddressAdditionResponse> AddUserAddress(AddressAdditionRequest request, ServerCallContext context)
        {
            // var userAddress = new AddressData { Name = request.Name, Address = request.Address, Enrollment = request.Enrollment };
            var userAddress = GetAddressData(request);

            _personDbContext.Add(userAddress);
            await _personDbContext.SaveChangesAsync();

            var results = new AddressAdditionResponse { Message = "Address Save Successfully." };

            return results;
        }

        public override async Task<Empty> AddAddressEnrollments(IAsyncStreamReader<AddressAdditionRequest> requestStream, ServerCallContext context)
        {
            var dbTask = Task.Run(async () =>
            {
                await foreach (var address in requestStream.ReadAllAsync())
                {
                    Console.WriteLine($"{address.Name} | {address.Address} | {address.Enrollment}");

                    //var userAddress = new AddressData {
                    //    Name = address.Name, Address = address.Address, Enrollment = address.Enrollment
                    //};
                    var userAddress = GetAddressData(address);

                    _personDbContext.Add(userAddress);
                    await _personDbContext.SaveChangesAsync();
                }
            });
            
            await dbTask.ConfigureAwait(false);
            
            return await Task.FromResult(new Empty());
        }

        private AddressData GetAddressData(AddressAdditionRequest address)
        {
            return new AddressData
            {
                Name = address.Name,
                Address = address.Address,
                Enrollment = address.Enrollment,
                EnrollmentStatus = _enrollmentStatus[Utilities.GetRandomValue(1, 4)]
            };
        }

    }

}
