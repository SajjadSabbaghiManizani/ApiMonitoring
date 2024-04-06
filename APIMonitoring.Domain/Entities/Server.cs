using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMonitoring.Domain.Entities
{
    public class Server : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string IpAddress { get; set; }
        public string OperatingSystem { get; set; }
        public bool IsOnline { get; set; }
        public DateTime LastUpdated { get; set; }
        [Required]
        public Uri Uri { get; set; }
    }
}

