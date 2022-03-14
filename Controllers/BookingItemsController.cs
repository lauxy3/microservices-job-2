#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingAPI.Models;

namespace BookingAPI.Controllers
{
    [Route("api/bookingitems")]
    [ApiController]
    public class BookingItemsController : ControllerBase
    {
        private readonly BookingContext _context;

        public BookingItemsController(BookingContext context)
        {
            _context = context;
        }

        // GET: api/BookingItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }


        // GET: api/BookingItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingItem>> GetBookingItem(long id)
        {
            var bookingItem = await _context.TodoItems.FindAsync(id);

            if (bookingItem == null)
            {
                return NotFound();
            }

            return bookingItem;
            
        }
        
        // [HttpGet("Current_Location_Latitude")]
        // public navigator.geolocation.GetBookingItem(success, error, options)
        // { function success(pos) {
        // var crd = pos.coords;

        // console.log(`Latitude : ${crd.latitude}`);
        // console.log(`Longitude: ${crd.longitude}`);
  

        // function error(err) {
        // console.warn(`ERROR(${err.code}): ${err.message}`);}


        // PUT: api/BookingItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingItem(long id, BookingItem bookingItem)
        {
            if (id != bookingItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookingItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingItemExists(id))
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

        // POST: api/BookingItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingItem>> PostBookingItem(BookingItem bookingItem)
        {
            _context.TodoItems.Add(bookingItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetBookingItem), new { id = bookingItem.Id }, bookingItem);
        }

        // DELETE: api/BookingItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingItem(long id)
        {
            var bookingItem = await _context.TodoItems.FindAsync(id);
            if (bookingItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(bookingItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
