using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Swashbuckle.AspNetCore.Annotations;

namespace RatingService.Entities
{
    [Table("Rating")]
    public class Rating
    {
        [Key]
        [Column("RatingId")]
        [SwaggerSchema(ReadOnly = true)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTimeOffset Date { get; set; }

        // Enumerator for rating grade
        // From 1 to 5

        public enum Grade
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
        }
        [Required(ErrorMessage = "Grade is required.")]
        public Grade RatingGrade { get; set; }

        [Required(ErrorMessage = "Comment is required.")]
        [StringLength(500, ErrorMessage = "Comment cannot be longer than 500 characters.")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        // Foreign Keys

        [ForeignKey("Buyer")]

        public Guid BuyerId { get; set; }

        [ForeignKey("Seller")]

        public Guid SellerId { get; set; }

        [ForeignKey("Purchase")]

        public Guid PurchaseId { get; set; }
    }
}
