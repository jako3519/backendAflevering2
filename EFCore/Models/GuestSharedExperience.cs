using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExperienceAPI.Models;



public class GuestSharedExperience
{
    public int ShareExperienceID { get; set; }
    public int GuestID { get; set; }

    public SharedExperience SharedExperience { get; set; }
    public Guest Guest { get; set; }
}
