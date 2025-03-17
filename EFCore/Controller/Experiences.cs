using Microsoft.AspNetCore.Mvc;

using ExperienceAPI.Data;
using ExperienceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace ExperienceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  
    public class ExperiencesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExperiencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET til alle experiences i db
        [HttpGet]
        public ActionResult<IEnumerable<Experience>> Get()
        {
            var experiences = _context.Experiences.ToList();
            return Ok(experiences);
        }

        
        [HttpGet("{id}")]
        public ActionResult<Experience> GetExperienceById(int id)
        {
            var experience = _context.Experiences.Find(id);
            if (experience == null) return NotFound("Experience not found");
            return Ok(experience);
        }

        [HttpPost]
public ActionResult<Experience> CreateExperience([FromBody] CreateExperienceDTO dto)
{
    if (dto == null)
        return BadRequest("Ingen experience modtaget.");

    var newExperience = new Experience
    {
        Type = dto.Type,
        Price = dto.Price,
        ProviderID_FK = dto.ProviderID_FK,
        Provider = null,
        Discounts = null,
        SharedExperiences = null,
        Reservations = null
    };

    _context.Experiences.Add(newExperience);
    _context.SaveChanges();

    return CreatedAtAction(nameof(GetExperienceById), new { id = newExperience.ExperienceID }, newExperience);
}



// PUT api/experiences/{id}
[HttpPut("{id}")]
public IActionResult UpdateExperience(int id, [FromBody] ExperienceUpdateDto updatedExperienceDto)
{
    var experience = _context.Experiences.Find(id);
    if (experience == null)
    {
        return NotFound("Experience not found");
    }

    // Map the DTO to the entity
    experience.Type = updatedExperienceDto.Type;
    experience.Price = updatedExperienceDto.Price;
    experience.ProviderID_FK = updatedExperienceDto.ProviderID_FK;

    _context.SaveChanges();

    return NoContent();
}

[HttpDelete("{id}")]
public IActionResult DeleteExperience(int id)
{
    var experience = _context.Experiences.Find(id);

    if (experience == null)
        return NotFound();

    _context.Experiences.Remove(experience);
    _context.SaveChanges();

    return NoContent();
}

        

    }}