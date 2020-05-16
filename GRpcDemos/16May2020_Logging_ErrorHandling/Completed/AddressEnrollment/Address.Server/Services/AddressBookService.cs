using Address.Common;
using Address.Server.Entities;
using Address.Server.Persistence;
using Address.Server.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Data.SqlClient;
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
            var userAddress = GetAddressData(request);

            try
            {
                if(userAddress.Enrollment == "Bank")
                {
                    var trailer = new Metadata()
                    {
                        { "BadValue", "Enrollment type is Bank" },
                        { "Field", "Enrollment" },
                        { "Message", "Bank enrollment is stopped temporarily" }
                    };
                    throw new RpcException(new Status(StatusCode.Cancelled, "Bank enrollment is stopped temporarily"), trailer);
                }
                _personDbContext.Add(userAddress);
                await _personDbContext.SaveChangesAsync();
            }
            catch (InvalidOperationException)
            {
                var trailer = new Metadata()
                {
                    { "CorelationId", Guid.NewGuid().ToString() },
                    { "Message", "Unable to save the Data inside Database." }
                };
                throw new RpcException(new Status(StatusCode.Internal, "Internal Error"), trailer);
            }
            catch (RpcException rpcError)
            {
                throw rpcError;
            }

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
