using Microsoft.EntityFrameworkCore;
using TripBooking_Api.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TripBooking_Api.DbModels
{
	public class TripDbContext : DbContext    
	{

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseInMemoryDatabase(databaseName: "TripsDssb");
		}


		public TripDbContext(DbContextOptions<TripDbContext> options)
		  : base(options)
		{
		}
		public DbSet<Trip> Trips { get; set; }
		public DbSet<Person> Persons { get; set; }

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<Trip>()
		//  .HasMany(c => c.Persons)
		//  .WithMany(c=>c.Trips);
		//}


	}


}
