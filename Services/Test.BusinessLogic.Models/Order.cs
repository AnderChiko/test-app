
using System.ComponentModel.DataAnnotations;

namespace Test.BusinessLogic.Models
{
    public class Order
    {

        public int Id { get; set; }
        [StringLength(60)]
        public string ReferenceNumber { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public List<OrderItems>? OrderItems { get; set; }
    }
}