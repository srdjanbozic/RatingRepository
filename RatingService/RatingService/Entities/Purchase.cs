using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RatingService.Entities
{
    [Table("purchase")]
    public class Purchase
    {
        [Key]
        [Column("PurchaseId")]
        [SwaggerSchema(ReadOnly = true)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Date is required!")]
        [DataType(DataType.Date)]
        public DateTimeOffset Date { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        public double Price { get; set; }

    }
}
