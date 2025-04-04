namespace WindowsFormsApp16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoardingInfo")]
    public partial class BoardingInfo
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string OwnerName { get; set; }

        [Required]
        [StringLength(50)]
        public string Contact { get; set; }

        [Required]
        [StringLength(100)]
        public string PetName { get; set; }

        public int Quantity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double Price { get; set; }

        public double? TotalPrice { get; set; }

        public int? EmployeeID { get; set; }

        [StringLength(100)]
        public string CageName { get; set; }

       

        public virtual Employee Employee { get; set; }
    }
}
