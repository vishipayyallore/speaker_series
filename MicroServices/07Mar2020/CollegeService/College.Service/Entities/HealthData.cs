using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace College.Service.Entities
{

    public class HealthData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int HealthParameter1 { get; set; }

        public int HealthParameter2 { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime ReceivedAt { get; set; }
    }

}
