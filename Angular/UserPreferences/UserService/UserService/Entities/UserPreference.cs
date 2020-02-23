using System;
using System.ComponentModel.DataAnnotations;

namespace UserService.Entities
{
    public class UserPreference
    {
        [Key]
        public Guid ProfessorId { get; set; }

        public string UserNickName { get; set; }

        public bool IsGraduated { get; set; }

        public bool IsProgrammer { get; set; }
    }
}
