using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_astowe.Models
{
    public class MovieContext : DbContext
    {
        //Constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {
            //leave blank for now
        }

        public DbSet<NewMovie> movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<NewMovie>().HasData(

                //seeded data
                new NewMovie
                {
                    MovieId = 1,
                    Title = "Inception",
                    Year = 2010,
                    Director = "Christopher Nolan",
                    Rating = "PG13",
                    Category = "Action",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new NewMovie
                {
                    MovieId = 2,
                    Title = "The Martian",
                    Year = 2015,
                    Director = "Ridley Scott",
                    Rating = "PG13",
                    Category = "Sci-fi/Adventure",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new NewMovie
                {
                    MovieId = 3,
                    Title = "Rogue One",
                    Year = 2016,
                    Director = "Gareth Edwards",
                    Rating = "PG13",
                    Category = "Sci-fi/Action",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
            );
        }

    }
}
