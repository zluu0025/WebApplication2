namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookingSet")]
    public partial class BookingSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BookingSet()
        {
            OrderLineSets = new HashSet<OrderLineSet>();
        }

        [Key]
        public int BookingID { get; set; }

        [Required]
        public DateTime BookingTime { get; set; }

        [Required]
        public DateTime RengtingStart { get; set; }

        [Required]
        public DateTime RentingEnd { get; set; }

        [Required]
        [Phone]
        public string Contact_PhonbeNumber { get; set; }

        [Required]
        public int LocationId { get; set; }
        [Required]
        public int CarId { get; set; }

        [Required]
        public string UserID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLineSet> OrderLineSets { get; set; }

        public virtual CarSet CarSet { get; set; }

        public virtual LocationSet LocationSet { get; set; }
    }
}
