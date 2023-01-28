using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RatingService.DTOs;
using RatingService.Entities;
using RatingService.Interface;

namespace RatingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RatingController : ControllerBase
    {
        private readonly IRepository<RatingDto> _repo;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public RatingController(IRepository<RatingDto> repo, ILogger logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            _logger.LogInformation($"Getting rating with id {id}");
            var rating = await _repo.GetByIdAsync(id);
            if (rating == null)
            {
                _logger.LogWarning($"Rating with id {id} not found");
                return NotFound();
            }
            return Ok(rating);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Getting all ratings");
            var ratings = await _repo.GetAllAsync();
            return Ok(ratings);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(Guid id)
        {
            _logger.LogInformation($"Deleting rating with id {id}");
            await _repo.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostRating(RatingDto ratingDto)
        {
            _logger.LogInformation("Post rating");
            var rating = new Rating
            {
                Date = ratingDto.Date,
                RatingGrade = ratingDto.RatingGrade,
                Comment = ratingDto.Comment,
                Title = ratingDto.Title,
                BuyerId= ratingDto.BuyerId,
                SellerId = ratingDto.SellerId,
                PurchaseId = ratingDto.PurchaseId

            };
            var newRating = await _repo.AddAsync(ratingDto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = newRating.Id }, newRating);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRating(Guid id, RatingDto ratingDto)
        {
            _logger.LogInformation("Update rating");
            var rating = await _repo.GetByIdAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            rating.Date = ratingDto.Date;
            rating.RatingGrade = ratingDto.RatingGrade;
            rating.Comment = ratingDto.Comment;
            rating.Title = ratingDto.Title;
            await _repo.UpdateAsync(rating);
            return NoContent();
        }
    }
}
