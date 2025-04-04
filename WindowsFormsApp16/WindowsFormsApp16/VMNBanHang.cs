using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp16
{
    public class VMNBanHang
    {
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

        public string FullName { get; set; }
    }
}
