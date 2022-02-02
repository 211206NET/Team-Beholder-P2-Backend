using Microsoft.EntityFrameworkCore;

public class DDDBContext : DbContext
{
    //Empty
    public DDDBContext() : base(){}

    //Need to pass options, call parent that takes options
    public DDDBContext(DbContextOptions options) : base(options) {}

    public DbSet<Scoreboard>? Scores { get; set; }
    public DbSet<User>? Users { get; set; }


    //Npgsql.EntityFrameworkCore.PostgreSQL?


    //After every change to models
    //dotnet ef migrations add initMig2 -c DDDBContext --startup-project ../WebAPI
    //dotnet ef database update --startup-project ../WebAPI


    //if you want to manually modify certain columns, properties...
    //map them here
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>()
        .Property(restaurant => restaurant.Id)
        .ValueGeneratedOnAdd();
        modelBuilder.Entity<Review>()
        .Property(review => review.Id)
        .ValueGeneratedOnAdd();
    }*/
}