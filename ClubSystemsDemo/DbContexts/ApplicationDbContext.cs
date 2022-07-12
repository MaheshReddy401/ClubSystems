using ClubSystemsTest.Models;
using ClubSystemsTest.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace ClubSystemsTest.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // public static bool isMigration = true;
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<MembershipDetails> MembershipDetails { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserDetails>().ToTable("UserDetails");
        //    modelBuilder.Entity<MembershipDetails>().ToTable("MembershipDetails");

        //}





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MembershipDetails>(entity =>
            {
                entity.HasIndex(e => new { e.Type, e.PersonID }).IsUnique();
            });

            // modelBuilder.Entity<MembershipDetails>()
            //.HasIndex(o => new { o.Type, o.PersonID });

            modelBuilder.Entity<UserDetails>().HasData(new UserDetails
            {
                PersonID = 1,
                Forename = "Carson",
                Surname = "Alexander",
                EmailAddress = "Carson.Alexander@gmail.com"
            });
            modelBuilder.Entity<UserDetails>().HasData(new UserDetails
            {
                PersonID = 2,
                Forename = "Carson",
                Surname = "Alexander2",
                EmailAddress = "Carson.Alexander@hotmail.com"
            });
            modelBuilder.Entity<UserDetails>().HasData(new UserDetails
            {
                PersonID = 3,
                Forename = "Ajay",
                Surname = "Peddapala",
                EmailAddress = "Ajay.Peddapala@hotmail.com"
            });
            //modelBuilder.Entity<UserDetails>().ToTable("UserDetails");
            modelBuilder.Entity<MembershipDetails>().HasData(
                    new MembershipDetails
                    {
                        MemebershipID = 1,
                        Type = MembershipType.Primary.ToString(),
                        AccountBalance = 10,
                        PersonID = 1
                    });
            modelBuilder.Entity<MembershipDetails>().HasData(
                    new MembershipDetails
                    {
                        MemebershipID = 2,
                        Type = MembershipType.Secondary.ToString(),
                        AccountBalance = 10,
                        PersonID = 1
                    });
            modelBuilder.Entity<MembershipDetails>().HasData(
                   new MembershipDetails
                   {
                       MemebershipID = 3,
                       Type = MembershipType.Primary.ToString(),
                       AccountBalance = -15,
                       PersonID = 2
                   });
            modelBuilder.Entity<MembershipDetails>().HasData(
                   new MembershipDetails
                   {
                       MemebershipID = 4,
                       Type = MembershipType.Basic.ToString(),
                       AccountBalance = -5,
                       PersonID = 3
                   });

        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
