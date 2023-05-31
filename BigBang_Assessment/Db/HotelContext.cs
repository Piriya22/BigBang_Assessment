using BigBang_Assessment.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBang_Assessment.Db
{
    public class HotelContext:DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<User>Users { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }
    }
}
