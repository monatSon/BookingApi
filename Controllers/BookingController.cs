using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookingApi.Models;
using BookingApi.Data;

namespace BookingApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApiContext _context;
        public BookingController(ApiContext context)
        {
            _context = context;
        }

        // Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Booking booking)
        {
            if (booking.Id == 0) 
            {
                _context.Bookings.Add(booking);
            } 
            else
            {
                var bookingInDb = _context.Bookings.Find(booking.Id);
                if (bookingInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                bookingInDb = booking;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(booking));
        }
        // Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Bookings.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            } 
            else
            {
                return new JsonResult(Ok(result));
            }
        }

        // Get all
        [HttpGet()]
        public JsonResult GetAll() 
        {
            var result = _context.Bookings.ToList();

            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id) 
        {
            var result = _context.Bookings.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            else
            {
                _context.Bookings.Remove(result);
                _context.SaveChanges();

                return new JsonResult(NoContent());
            }
        }
    }
}
