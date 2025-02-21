using Microsoft.EntityFrameworkCore;

public class MyContext : DbContext
{
    public DbSet<Thing> Things => Set<Thing>();

    public MyContext(DbContextOptions<MyContext> options)
        : base(options) { }
}

public class Thing
{
    public int Id { get; set; }
    public required string Url { get; set; }
}
