using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualitApps_Test.Models.Models
{
    public class Invoice
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
        public Guid CustomerId { get; set; }
        public BaseUser Customer { get; set; }
        public Guid BookingId { get; set; }
        public bool isVoid { get; set; }
        public Booking Booking { get; set; }
    }
}
