using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiMonitoring.Application.DTOs.UserDtos
{
    public class RegisterResult
    {
        public bool Succeeded { get; set; }
        [JsonIgnore]
        public Dictionary<string, string> Errors { get; set; }
    }
}
