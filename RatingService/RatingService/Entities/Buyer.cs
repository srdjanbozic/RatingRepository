using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RatingService.Entities
{
    [Table("buyer")]
    public class Buyer
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        [Column("BuyerId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Username  is required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Emnail  is required!")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
