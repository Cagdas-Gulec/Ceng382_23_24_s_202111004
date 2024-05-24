using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) :
    base(options)
    {
    }
    public DbSet<Room> Rooms { get; set; }

    public DbSet<Reservation> Reservations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>().HasData(
            new Room
            {
                Id = 1,
                RoomName = "Room 1",
                Capacity = 10
            },
            new Room
            {
                Id = 2,
                RoomName = "Room 2",
                Capacity = 20
            },
            new Room
            {
                Id = 3,
                RoomName = "Room 3",
                Capacity = 30
            }
        );
    }




}
