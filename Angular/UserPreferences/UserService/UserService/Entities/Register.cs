using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Entities
{
    public class Register
    {
        public string Role { get; set; }
        public string Name { get; set; }
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }

}
