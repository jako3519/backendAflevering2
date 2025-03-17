using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ExperienceAPI.Models;

public class SharedExperience
{
    public int ShareExperienceID { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public int ExperienceID_FK { get; set; }

    public Experience Experience { get; set; }
    public ICollection<GuestSharedExperience> GuestSharedExperiences { get; set; }
}
