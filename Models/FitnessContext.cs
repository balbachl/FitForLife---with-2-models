using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitForLife.Models
{
	public class FitnessContext : DbContext
	{
		public FitnessContext(DbContextOptions<FitnessContext> options)
			: base(options)
		{ }
		public DbSet<Members> Membership { get; set; }
		public	DbSet<Stats> Statistics { get; set; }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Members>().HasData(
				new Members {
					ID = 1, 
					name = "Lisa Balbach",
					email="lbalbach@nmc.edu"
				},
				new Members { 
					ID = 2, 
					name = "Shaggy Rogers"
				},
				new Members { 
					ID = 3, 
					name = "Daphne Blake" 
				}
			);
			modelBuilder.Entity<Stats>().HasData(
				 new Stats
				 {
					 ID = 1,
					 age=57,
					 weight = 118,
					 height = 64,
					 MembersID = 1
				 },
				 new Stats
				 {
					 ID = 2,
					 age=29,
					 weight = 150,
					 height = 70,
					 MembersID = 2
				 },
				 new Stats
				 {
					 ID = 3,
					 age=22,
					 weight = 125,
					 height = 66,
					 MembersID = 3
				 }
			 );
		}
	}
}
