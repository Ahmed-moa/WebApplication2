using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

namespace WebApplication2.DAL.Entities
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(20)]
        public string ProductCode { get; set; }

        public decimal Price { get; set; } // تعديل النوع

        internal static void Add(ProductVM pdt)
        {
            throw new NotImplementedException();
        }
    }
}
