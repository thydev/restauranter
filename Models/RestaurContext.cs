using Microsoft.EntityFrameworkCore;
 
namespace restauranter.Models
{
    public class RestaurContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RestaurContext(DbContextOptions<RestaurContext> options) : base(options) { }

        // This DbSet contains objects and database table
        // DbSet<ObjectName> DatabaseTabaleName {get; set;}
        public DbSet<Review> Reviews { get; set; }
    }
}