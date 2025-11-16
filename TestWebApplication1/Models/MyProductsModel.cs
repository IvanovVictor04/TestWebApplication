using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestWebApplication1.Models
{
    public class MyProductsModel
    {
        [Key]
        public string productCode { get; set; }
        public string productName { get; set; }
        public string productLine { get; set; }
        public string productScale { get; set; }
        public string productVendor { get; set; }
        public string productDescription { get; set; }
        public int QuantityInStock { get; set; }
        public decimal buyPrice { get; set; }
        public decimal MSRP { get; set; }
    }
}
