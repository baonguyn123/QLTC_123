using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp16.Models;

namespace WindowsFormsApp16
{
    public class VMNBillinfo
    {
        public int ID { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        public int? IdProduct { get; set; }
        public int? IdBill { get; set; }

        public string ProductName { get; set; } // Thêm thuộc tính ProductName

        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }
    }
}
