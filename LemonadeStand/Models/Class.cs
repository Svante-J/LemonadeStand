namespace LemonadeStand.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class LemonadeViewModel
    {
        [Required]  
        
        public string? Lemonade{ get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public int MoneyPaid { get; set; }

        public int ApllesAdded { get; set; }
        public int MelondAdded { get; set; }
        public int OrangeAdded { get; set; }
        
    }
}
