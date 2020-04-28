using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityDemo.Models
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LasttName { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public string Email { get; set; }
    }

}