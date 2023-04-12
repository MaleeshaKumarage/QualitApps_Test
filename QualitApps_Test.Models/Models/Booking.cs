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
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TypeOfGoods TypeOfGoods { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
        public Guid DriverId { get; set; }
    }
}
