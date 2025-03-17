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

        //  GET experiences for a specific provider
        [HttpGet("provider/{providerId}")]
        public ActionResult<IEnumerable<Experience>> GetByProvider(int providerId)
        {
            var experiences = _context.Experiences.Where(e => e.ProviderID_FK == providerId).ToList();
            return Ok(experiences);
        }

        

        [HttpPost]
        public ActionResult<Experience> CreateExperience(Experience newExperience)
        {
            if (!ModelState.IsValid) 
            {
             return BadRequest(ModelState);
            }
            _context.Experiences.Add(newExperience);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetExperienceById), new { id = newExperience.ExperienceID }, newExperience);
        }

        //  PUT update  experience
        [HttpPut("{id}")]
        public IActionResult UpdateExperience(int id, Experience updatedExperience)
        {
            var experience = _context.Experiences.Find(id);
            if (experience == null) return NotFound("Experience not found");

            experience.Type = updatedExperience.Type;
            experience.Price = updatedExperience.Price;
            experience.ProviderID_FK = updatedExperience.ProviderID_FK;

            _context.SaveChanges();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteExperience(int id)
        {
            var experience = _context.Experiences.Find(id);
            if (experience == null) return NotFound("Experience not found");

            _context.Experiences.Remove(experience);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
