using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExperienceAPI.Models;

public class Provider
{
    public int ProviderID { get; set; }
   
    //public string CVR { get; set; } // denne blev fjernet ift. opgave E 2. migration

    public string TouristicPermit { get; set; } // ny ift. opgave E 1 migration

    public string BusinessPhysicalAddress { get; set; }
    public string PhoneNumber { get; set; }

    public ICollection<Experience> Experiences { get; set; }
}

