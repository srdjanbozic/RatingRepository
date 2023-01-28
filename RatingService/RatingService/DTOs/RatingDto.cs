using static RatingService.Entities.Rating;

namespace RatingService.DTOs
{
    public class RatingDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public Grade RatingGrade { get; set; }
        public string Comment { get; set; }
        public string Title { get; set; }
        public Guid BuyerId { get; set; }
        public Guid SellerId { get; set; }

        public Guid PurchaseId { get; set; }
    }
}
