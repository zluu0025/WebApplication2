namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("CarRatingSet")]
    public partial class CarRatingSet
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        [AllowHtml]
        public string Comment { get; set; }

        public virtual CarSet CarSet { get; set; }
    }
}
