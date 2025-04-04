namespace WindowsFormsApp16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            BillInfo = new HashSet<BillInfo>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string DisplayName { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int? Quantity { get; set; }

        public double? TotalPricef { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductCategory { get; set; }

        public DateTime SaleDate { get; set; }

        public int? EmployeeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillInfo> BillInfo { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
