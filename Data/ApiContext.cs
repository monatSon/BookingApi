using Microsoft.EntityFrameworkCore;
using BookingApi.Models;

namespace BookingApi.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) 
        { }

    }
}
