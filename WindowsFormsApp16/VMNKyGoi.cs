using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WindowsFormsApp16
{
    public class VMNKyGoi
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

        public string FullName { get; set; }
    }
}
