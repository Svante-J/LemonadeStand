using LemonadeStand.Shared.Models;
using System.ComponentModel.DataAnnotations;
namespace LemonadeStand.Shared;

public class LemonadeViewModel
{
    [Required]
    [LemonadeTypeValidation]
    public string? Lemonade{ get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int MoneyPaid { get; set; }
    public int ApplesAdded { get; set; }
    public int MelondAdded { get; set; }
    public int OrangeAdded { get; set; }
    
}
