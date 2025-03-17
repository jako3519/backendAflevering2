// QueriesCpmtroller, er til at vise queries fra afl. 1 

using Microsoft.AspNetCore.Mvc;
using ExperienceAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ExperienceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QueriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Getter for providers
        [HttpGet("providers")]
        public IActionResult GetProviders()
        {
            var result = _context.Providers
                .Select(p => new
                {
                    p.BusinessPhysicalAddress,
                    p.PhoneNumber,
                    p.TouristicPermit
                })
                .ToList();
            return Ok(result);
        }

        // Getter til experiences
        [HttpGet("experiences")]
        public IActionResult GetExperiences()
        {
            var result = _context.Experiences
                .Select(e => new
                {
                    e.Type,
                    e.Price
                })
                .ToList();
            return Ok(result);
        }

        // Getter til shared experiences
        [HttpGet("shared-experiences")]
        public IActionResult GetSharedExperiences()
        {
            var result = _context.SharedExperiences
                .OrderByDescending(se => se.Date)
                .Select(se => new
                {
                    se.Name,
                    se.Date
                })
                .ToList();
            return Ok(result);
        }

        // Getter til guest der er registrerede til en shared experience
        [HttpGet("shared-experiences/{id}/guests")]
        public IActionResult GetGuestsForSharedExperience(int id)
        {
            var result = _context.GuestSharedExperiences
                .Where(gse => gse.ShareExperienceID == id)
                .Select(gse => gse.Guest.Name)
                .ToList();
            return Ok(result);
        }

        // getter til Experiences, der er included i shared experiences
        [HttpGet("shared-experiences/{id}/experiences")]
        public IActionResult GetExperiencesForSharedExperience(int id)
        {
            var result = _context.SharedExperiences
                .Where(se => se.ShareExperienceID == id)
                .Select(se => new
                {
                    se.Experience.Type
                })
                .ToList();
            return Ok(result);
        }

        //  Getter til guests registeret til en af experience i  shared experience
        [HttpGet("shared-experiences/{sharedExperienceId}/experience/{experienceId}/guests")]
public IActionResult GetGuestsForExperienceInSharedExperience(int sharedExperienceId, int experienceId)
{
    var result = _context.GuestSharedExperiences
        .Where(gse => gse.ShareExperienceID == sharedExperienceId && gse.SharedExperience.ExperienceID_FK == experienceId)
        .Select(gse => gse.Guest.Name)
        .ToList();

    return Ok(result);
}

        // 7️⃣ Getter til at finde avg, og max pris af experiences
        [HttpGet("experiences/prices")]
        public IActionResult GetExperiencePriceStats()
        {
            var minPrice = _context.Experiences.Min(e => e.Price);
            var avgPrice = _context.Experiences.Average(e => e.Price);
            var maxPrice = _context.Experiences.Max(e => e.Price);

            return Ok(new { Min = minPrice, Avg = avgPrice, Max = maxPrice });
        }

        // getter til antal gust, og hvad prisen derefter bliver
        [HttpGet("experiences/sales")]
        public IActionResult GetExperienceSales()
        {
            var result = _context.Reservations
                .GroupBy(r => r.Experience.Type)
                .Select(group => new
                {
                    Experience = group.Key,
                    GuestCount = group.Count(),
                    TotalSales = group.Sum(r => r.PriceAfterDiscount_PK)
                })
                .ToList();
            return Ok(result);
        }

        // henter den bedste discount for hver experience
        [HttpGet("best-discounts")]
        public IActionResult GetBestDiscounts()
        {
            var result = _context.Discounts
                .GroupBy(d => d.ExperienceID_FK)
                .Select(group => new
                {
                    Experience = _context.Experiences
                        .Where(e => e.ExperienceID == group.Key)
                        .Select(e => e.Type)
                        .FirstOrDefault(),
                    BestDiscount = group.OrderByDescending(d => d.DiscountAmount).FirstOrDefault().GroupSize
                })
                .ToList();
            return Ok(result);
        }
    }
}
