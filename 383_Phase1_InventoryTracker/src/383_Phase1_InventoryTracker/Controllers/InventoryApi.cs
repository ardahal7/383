using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _383_Phase1_InventoryTracker.Entities;

namespace _383_Phase1_InventoryTracker.Controllers
{
    [Produces("application/json")]
    [Route("api/InventoryApi")]
    public class InventoryApi : Controller
    {
        private readonly InventoryTrackerContext _context;

        public InventoryApi(InventoryTrackerContext context)
        {
            _context = context;
        }

        // GET: api/InventoryApi
        [HttpGet]
        public IEnumerable<InventoryItem> GetInventoryItems()
        {
            return _context.InventoryItems;
        }

        // GET: api/InventoryApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            InventoryItem inventoryItem = await _context.InventoryItems.SingleOrDefaultAsync(m => m.Id == id);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            return Ok(inventoryItem);
        }

        // PUT: api/InventoryApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryItem([FromRoute] int id, [FromBody] InventoryItem inventoryItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventoryItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventoryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryItemExists(id))
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

        // POST: api/InventoryApi
        [HttpPost]
        public async Task<IActionResult> PostInventoryItem([FromBody] InventoryItem inventoryItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InventoryItems.Add(inventoryItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InventoryItemExists(inventoryItem.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInventoryItem", new { id = inventoryItem.Id }, inventoryItem);
        }

        // DELETE: api/InventoryApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            InventoryItem inventoryItem = await _context.InventoryItems.SingleOrDefaultAsync(m => m.Id == id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            _context.InventoryItems.Remove(inventoryItem);
            await _context.SaveChangesAsync();

            return Ok(inventoryItem);
        }

        private bool InventoryItemExists(int id)
        {
            return _context.InventoryItems.Any(e => e.Id == id);
        }
    }
}