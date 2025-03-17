namespace ExperienceAPI.Models;

public class CreateExperienceDTO
{
    public string Type { get; set; }
    public int Price { get; set; }
    public int ProviderID_FK { get; set; }
}

// Dto bruges til at insætte data i databasen, uden at skulle bruge alle properties fra klassen. denne bruges kun til post metoden i controlleren.