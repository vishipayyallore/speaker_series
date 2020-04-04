using College.Api.Entities;
using College.Api.Persistence;
using College.Services.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace College.Services.RPCServices
{
    public class CollegeGrpcService : CollegeService.CollegeServiceBase
    {

        private readonly CollegeDbContext _collegeDbContext;

        public CollegeGrpcService(CollegeDbContext collegeDbContext)
        {
            _collegeDbContext = collegeDbContext;
        }

        public override async Task<GetProfessorResponse> GetProfessorById(GetProfessorRequest request, ServerCallContext context)
        {
            GetProfessorResponse getProfessorResponse = new GetProfessorResponse();

            if (!_collegeDbContext.Professors.Any(record => record.ProfessorId == Guid.Parse(request.ProfessorId)))
            {
                getProfessorResponse = null;
            }

            var professor = await _collegeDbContext.Professors
                .Where(record => record.ProfessorId == Guid.Parse(request.ProfessorId))
                .Include(student => student.Students)
                .FirstOrDefaultAsync();

            getProfessorResponse = GetProfessorObject(professor);

            return getProfessorResponse;
        }

        public override async Task<AllProfessorsResonse> GetAllProfessors(Empty request, ServerCallContext context)
        {
            AllProfessorsResonse allProfessorsResonse = new AllProfessorsResonse();

            var allProfessors = await _collegeDbContext.Professors.ToListAsync();

            allProfessorsResonse.Count = allProfessors.Count;

            foreach (var professor in allProfessors)
            {
                allProfessorsResonse.Professors.Add(GetProfessorObject(professor));
            }

            return allProfessorsResonse;
        }

        private static GetProfessorResponse GetProfessorObject(Professor professor)
        {
            return new GetProfessorResponse()
            {
                ProfessorId = professor.ProfessorId.ToString(),
                Name = professor.Name,
                Teaches = professor.Teaches,
                IsPhd = professor.IsPhd,
                Salary = decimal.ToDouble(professor.Salary),
                Doj = Timestamp.FromDateTime(professor.Doj.ToUniversalTime())
            };
        }

    }
}
