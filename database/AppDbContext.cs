
using GeoSquare.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoSquare.database{

    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Square> Squares { get; set; }

        public DbSet<Line> Lines { get; set; }

    }

}