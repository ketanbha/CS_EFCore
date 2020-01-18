using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS_EFCore.Models
{
    public class PersonDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public PersonDbContext()
        {

        }
        /// <summary>
        /// configure db connection with a application
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=PersonDb; Integrated Security=SSPI");
        }

        /// <summary>
        /// mechanism of model mapping while db and tables are created
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
        }
    }
}
