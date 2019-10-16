using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models
{
  public class CuisineContext : DbContext
  {
    public virtual DbSet<Cuisine> Cuisines {get;set;}
    public DbSet<RestaurantV> Restaurants { get; set; }

    public CuisineContext(DbContextOptions options) : base(options) { }
  }
}