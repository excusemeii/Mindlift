using Mindlift.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mindlift.Data;

namespace Mindlift.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reviews
        [HttpGet]
        public ActionResult<IEnumerable<Review>> GetAll()
        {
            var reviews = _context.Review.Include(r => r.Book).ToList();
            return Ok(reviews);
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public ActionResult<Review> GetById(int id)
        {
            var review = _context.Review.Include(r => r.Book).FirstOrDefault(r => r.ReviewId == id);

            if (review == null)
            {
                return NotFound($"Review with ID {id} not found.");
            }

            return Ok(review);
        }

        // POST: api/Reviews
        /*[HttpPost]
        public ActionResult<Review> Post([FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
 
            review.ReviewDate = DateTime.Now;
            _context.Review.Add(review);
            _context.SaveChanges();
 
            return CreatedAtAction(nameof(GetById), new { id = review.ReviewId }, review);
        }
 
        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Review updatedReview)
        {
            if (id != updatedReview.ReviewId)
            {
                return BadRequest("ID mismatch.");
            }
 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
 
            var existingReview = _context.Review.Find(id);
            if (existingReview == null)
            {
                return NotFound($"Review with ID {id} not found.");
            }
 
            existingReview.Rating = updatedReview.Rating;
            existingReview.Comment = updatedReview.Comment;
            existingReview.ReviewDate = DateTime.Now;
 
            _context.Entry(existingReview).State = EntityState.Modified;
            _context.SaveChanges();
 
            return NoContent();
        }
 
        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var review = _context.Review.Find(id);
            if (review == null)
            {
                return NotFound($"Review with ID {id} not found.");
            }
 
            _context.Review.Remove(review);
            _context.SaveChanges();
 
            return NoContent();
        }*/
    }
}