using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExperienceAPI.Validators;



namespace ExperienceAPI.Models;

public class Experience
{
    public int ExperienceID { get; set; }
    public string Type { get; set; }

    [NonNegativePrice] //  her bliver  den "Custom validation attribute" kaldt
                       //  De er defineret under validators
    //public decimal Price { get; set; }
        public int Price { get; set; }

    public int ProviderID_FK { get; set; }

    public Provider Provider { get; set; }
    public ICollection<Discount> Discounts { get; set; }
    public ICollection<SharedExperience> SharedExperiences { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}
