using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.BusinessLogic.Models
{
    public class OrderItems
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }

        public int? ProductId { get; set; }

        public int? Quatity { get; set; }

        public decimal? Vat { get; set; }

        public decimal? Price { get; set; } 
    }
}