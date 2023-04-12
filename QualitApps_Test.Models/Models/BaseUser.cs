using QualitApps_Test.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QualitApps_Test.Models.Models
{
    public class BaseUser
    {

        [Key]
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserStatus Status { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserRole userRoles { get; set; }
        //public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }


}
