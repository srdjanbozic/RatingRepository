using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RatingService.Entities
{
    [Table("seller")]
    public class Seller
    {
        [Key]

        public Guid Id { get; set; }

        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

    }
}
