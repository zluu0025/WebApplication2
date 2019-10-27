namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderLineSet")]
    public partial class OrderLineSet
    {
        public int Id { get; set; }

        public DateTime ConfirmStartTime { get; set; }

        public DateTime ConfirmEndTime { get; set; }

        [Required]
        public string ReturnStatus { get; set; }

        public int BookingBookingID1 { get; set; }

        public virtual BookingSet BookingSet { get; set; }
    }
}
