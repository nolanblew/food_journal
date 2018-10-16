using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Food_Journal.Api;
using Food_Journal.DB.Models;

namespace Food_Journal.Api.Controllers
{
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class FoodItemEntriesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public FoodItemEntriesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/FoodItemEntries
        [HttpGet]
        public IEnumerable<FoodItemEntry> GetFoodItemEntries()
        {
            return _context.FoodItemEntries;
        }

        // GET: api/FoodItemEntries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodItemEntry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foodItemEntry = await _context.FoodItemEntries.FindAsync(id);

            if (foodItemEntry == null)
            {
                return NotFound();
            }

            return Ok(foodItemEntry);
        }

        // PUT: api/FoodItemEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodItemEntry([FromRoute] int id, [FromBody] FoodItemEntry foodItemEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != foodItemEntry.Id)
            {
                return BadRequest();
            }

            foodItemEntry.UpdatedAt = DateTimeOffset.Now;

            _context.Entry(foodItemEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodItemEntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FoodItemEntries
        [HttpPost]
        public async Task<IActionResult> PostFoodItemEntry([FromBody] FoodItemEntry foodItemEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foodItemEntry.CreatedAt = DateTimeOffset.Now;
            foodItemEntry.UpdatedAt = DateTimeOffset.Now;

            _context.FoodItemEntries.Add(foodItemEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodItemEntry", new { id = foodItemEntry.Id }, foodItemEntry);
        }

        // DELETE: api/FoodItemEntries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodItemEntry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foodItemEntry = await _context.FoodItemEntries.FindAsync(id);
            if (foodItemEntry == null)
            {
                return NotFound();
            }

            _context.FoodItemEntries.Remove(foodItemEntry);
            await _context.SaveChangesAsync();

            return Ok(foodItemEntry);
        }

        private bool FoodItemEntryExists(int id)
        {
            return _context.FoodItemEntries.Any(e => e.Id == id);
        }
    }
}