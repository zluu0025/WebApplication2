namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarSet")]
    public partial class CarSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarSet()
        {
            BookingSets = new HashSet<BookingSet>();
            CarRatingSets = new HashSet<CarRatingSet>();
        }

        public int Id { get; set; }

        [Required]
        public string CarVin { get; set; }

        [Required]
        public string CarMark { get; set; }

        [Required]
        public string CarModel { get; set; }

        [Required]
        public string CarType { get; set; }

        public double CarPrice { get; set; }

        public DateTime CarRegisterDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingSet> BookingSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarRatingSet> CarRatingSets { get; set; }
    }
}
