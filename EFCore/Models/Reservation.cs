
namespace ExperienceAPI.Models;

public class Reservation
{
    public int ReservationID { get; set; }
    public int GuestID { get; set; }
    public int ExperienceID_FK { get; set; }
    public int GroupSize_FK { get; set; }
    public decimal PriceAfterDiscount_PK { get; set; }

    public Guest Guest { get; set; }
    public Experience Experience { get; set; }

    public Discount Discount { get; set; } 

}
