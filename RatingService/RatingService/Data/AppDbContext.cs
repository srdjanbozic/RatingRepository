using Microsoft.EntityFrameworkCore;
using RatingService.Entities;

namespace RatingService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Purchase Table
            modelBuilder.Entity<Rating>().HasData(
                new Rating()
                {
                    Id = Guid.Parse("5b84f691-106a-48f8-b50e-b829e2e95a29"),
                    Date = new DateTime(2022, 2, 12),
                    RatingGrade = Entities.Rating.Grade.Three,
                    Comment = "Very good deal",
                    Title = "Title",
                    BuyerId = Guid.Parse("018c0e6a-dd74-4eb7-853d-88cc07d7be66"),
                    SellerId = Guid.Parse("00a22268-2511-4a08-8264-c5562491e82f"),
                    PurchaseId = Guid.Parse("00a22268-2511-4a08-8264-c5562491e82f")


                });
            modelBuilder.Entity<Rating>().HasData(
              new Rating()
              {
                  Id = Guid.Parse("9b3cb66e-10a0-4714-9f40-f770b17a240d"),
                  Date = new DateTime(2022, 12, 12),
                  RatingGrade = Entities.Rating.Grade.One,
                  Comment = "Very bad deal",
                  Title = "Bad",
                  BuyerId = Guid.Parse("3b02347b-553c-4c03-b009-72e4d235b45f"),
                  SellerId = Guid.Parse("384c92de-470c-42a7-b061-8cc40d016e7a"),
                  PurchaseId = Guid.Parse("6a207b67-882b-448d-b3bd-839bd47dd663")


              });
            modelBuilder.Entity<Buyer>().HasData(
            new Buyer()
            {
                Id = Guid.Parse("018c0e6a-dd74-4eb7-853d-88cc07d7be66"),
                Username = "Marks",
                Email = "Marksa@gmail.com"
            
            });
            modelBuilder.Entity<Buyer>().HasData(
            new Buyer()
            {
                Id = Guid.Parse("3b02347b-553c-4c03-b009-72e4d235b45f"),
                Username = "Petar",
                Email = "peatad@gmail.com"

            });
            modelBuilder.Entity<Seller>().HasData(
         new Seller()
         {
             Id = Guid.Parse("00a22268-2511-4a08-8264-c5562491e82f"),
             Username = "Nemanja",
             Email = "nmgjs@gmail.com"

         });
            modelBuilder.Entity<Seller>().HasData(
            new Seller()
            {
                Id = Guid.Parse("384c92de-470c-42a7-b061-8cc40d016e7a"),
                Username = "Slavko",
                Email = "slavkeds@gmail.com"

            });
            modelBuilder.Entity<Purchase>().HasData(
      new Purchase()
      {
          Id = Guid.Parse("00a22268-2511-4a08-8264-c5562491e82f"),
          Date = new DateTime(2022,4,2),
          Price = 1000

      });
            modelBuilder.Entity<Purchase>().HasData(
      new Purchase()
        {
            Id = Guid.Parse("6a207b67-882b-448d-b3bd-839bd47dd663"),
            Date = new DateTime(2022, 4, 12),
             Price = 233

        });
        }


        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
       




    }
}
