using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ExperienceAPI.Models;

public class Guest
{
    public int GuestID { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }

    public ICollection<Reservation> Reservations { get; set; }
    public ICollection<GuestSharedExperience> GuestSharedExperiences { get; set; }
}
