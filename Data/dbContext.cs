
using RazorDropDown.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace RazorDropDown.Data
{
    public class OurDbContext : DbContext
        {
            // Notes
            // - DbSet defines the  database table.
            // - the class name is defined as part of the data model
            // - the instance/object name is normally plural
            // - by default, the instance name will become the table name
            public DbSet<Grade> Grades { get; set; } = null!;
            public DbSet<Shop> Shops { get; set; } = null!;

            private string DbPath { get; set; } = string.Empty;

            // Constructor to set-up the database path & name
            public OurDbContext()
            {
                var folder = Environment.SpecialFolder.MyDocuments;
                var path = Environment.GetFolderPath(folder);
                DbPath = Path.Join(path, "shopgrades.db");
            }

            // OnConfiguring to specify that the SQLite database engine will be used
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);
                optionsBuilder.UseSqlite($"Data Source={DbPath}");

                //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VistaLocalDB;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("Server=TU42687\\SQLEXPRESS;Database=VistaLocalDb;Trusted_Connection=True;");

            }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);

            builder.Entity<Shop>()
                .HasOne(s => s.Grade)
                .WithMany(g => g.Shop)
                 .HasForeignKey(s => s.GradeId)
                    .OnDelete(DeleteBehavior.Restrict);

            // Insert Seed/Test Data
            builder.Entity<Grade>().HasData(
                    new Grade { GradeId = 1, Description="Small"  },
                    new Grade { GradeId = 2, Description = "Medium" },
                    new Grade { GradeId = 3, Description = "Large" },
                    new Grade { GradeId = 4, Description = "Very Large" }
                );
                builder.Entity<Shop>().HasData(
                    new Shop { StoreId= 1, StoreName="Middlesbrough", StoreNumber=10, Description="Inside Cleveland Centre",  GradeId = 1 },
                    new Shop { StoreId = 2, StoreName = "Stockton", StoreNumber = 11, Description = "Blah Blah Blah", GradeId = 2 },
                    new Shop { StoreId = 3, StoreName = "Thornaby", StoreNumber = 12, Description = "Blah Blah Blah", GradeId = 3 },
                    new Shop { StoreId = 4, StoreName = "Redcar", StoreNumber = 13, Description = "Blah Blah Blah", GradeId = 4 },
                new Shop { StoreId = 5, StoreName = "Billingham", StoreNumber = 14, Description = "Blah Blah Blah", GradeId = 4 },
                new Shop { StoreId = 6, StoreName = "Saltburn", StoreNumber = 15, Description = "Blah Blah Blah", GradeId = 3 },
                new Shop { StoreId = 7, StoreName = "Darlington", StoreNumber = 16, Description = "Blah Blah Blah", GradeId = 2 },
                new Shop { StoreId = 8, StoreName = "Eston", StoreNumber = 17, Description = "Blah Blah Blah", GradeId = 1 },
                new Shop { StoreId = 9, StoreName = "Sunderland", StoreNumber = 18, Description = "Blah Blah Blah", GradeId = 2 }


                    );

               

        
            }

        }
    }

