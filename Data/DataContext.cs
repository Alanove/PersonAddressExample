using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using ASAP.Data.Entities;

namespace ASAP.Data
{
	public partial class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Person> Person { get; set; }
		public virtual DbSet<Address> Address { get; set; }
		public virtual DbSet<Country> Countries { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person>(entity => {
				entity.HasKey(e => e.PersonId);
				entity.ToTable("Person");
			});
			modelBuilder.Entity<Address>(entity => {
				entity.HasKey(e => e.AddressId);
				entity.ToTable("Address");
			});
			modelBuilder.Entity<Country>(entity => {
				entity.HasKey(c => c.Code);
				entity.ToTable("Country");
			});

			modelBuilder.Entity<AddressView>(entity => {
				entity.HasKey(e => e.AddressId);
				entity.ToView("AddressView");
			});
		}
	}
}