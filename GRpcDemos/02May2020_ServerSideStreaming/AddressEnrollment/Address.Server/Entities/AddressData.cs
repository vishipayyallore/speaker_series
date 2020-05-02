using System;
using System.ComponentModel.DataAnnotations;

namespace Address.Server.Entities
{
    public class AddressData
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Enrollment { get; set; }

        public string EnrollmentStatus { get; set; }
    }

}
