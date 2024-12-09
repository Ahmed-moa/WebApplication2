using System.ComponentModel.DataAnnotations;


namespace WebApplication2.Models
{
    public class ProductVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter product name")]
        [MinLength(3,ErrorMessage ="Minimum length 3")]
        [MaxLength(10,ErrorMessage ="Maximum length 10")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please Enter product code")]

        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Please Enter product price")]

        public decimal Price { get; set; }
    }
}
