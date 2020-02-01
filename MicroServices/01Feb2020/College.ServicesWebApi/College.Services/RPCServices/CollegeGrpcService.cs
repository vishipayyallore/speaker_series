using College.Api.Persistence;
using College.Api.Protos;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace College.Api.RPCServices
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

            getProfessorResponse.ProfessorId = professor.ProfessorId.ToString();
            getProfessorResponse.Name = professor.Name;
            getProfessorResponse.Teaches = professor.Teaches;
            getProfessorResponse.IsPhd = professor.IsPhd;
            getProfessorResponse.Salary = decimal.ToDouble(professor.Salary);

            return getProfessorResponse;
        }
    }
}
