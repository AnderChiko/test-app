using System.ComponentModel.DataAnnotations;

namespace Test.BusinessLogic.Models
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(60)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public bool? IsTaxable { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(60)]
        public string CreateBy { get; set; }

        public List<ProductPrice>? ProductPrice { get; set; }
    }
}