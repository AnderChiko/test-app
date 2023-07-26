﻿
namespace Test.BusinessLogic.Models
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public decimal? Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Deleted { get; set; }
    }
}