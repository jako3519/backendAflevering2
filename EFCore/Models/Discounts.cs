

using System.ComponentModel.DataAnnotations.Schema;

namespace ExperienceAPI.Models;

public class Discount
{
    public int ExperienceID_FK { get; set; }
    public int GroupSize { get; set; }
    public decimal PriceAfterDiscount { get; set; }
    public decimal DiscountAmount { get; set; }

    public Experience Experience { get; set; }
}
