using AutoMapper;
using RatingService.Data;
using RatingService.DTOs;
using RatingService.Entities;
using RatingService.Interface;
using System.Data.Entity;

namespace RatingService.Repository
{
    public class Repository : IRepository<RatingDto>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<Repository> _logger;

        public Repository(AppDbContext dbContext, IMapper mapper, ILogger<Repository> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<RatingDto> AddAsync(RatingDto ratingDto)
        {
            var rating = _mapper.Map<Rating>(ratingDto);
            _dbContext.Ratings.Add(rating);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"Added rating with ID {rating.Id}");
            return _mapper.Map<RatingDto>(rating);
        }

        public async Task DeleteAsync(Guid id)
        {
            var rating = await _dbContext.Ratings.FindAsync(id);
            _dbContext.Ratings.Remove(rating);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"Deleted rating with ID {id}");
        }

        public async Task<IEnumerable<RatingDto>> GetAllAsync()
        {
            var ratings = await _dbContext.Ratings.ToListAsync();
            _logger.LogInformation($"Retrieved {ratings.Count} ratings");
            return _mapper.Map<IEnumerable<RatingDto>>(ratings);
        }

        public  async Task<RatingDto> GetByIdAsync(Guid id)
        {
            var rating = await _dbContext.Ratings.FindAsync(id);
            _logger.LogInformation($"Retrieved rating with ID {id}");
            return _mapper.Map<RatingDto>(rating);
        }

        public async Task<RatingDto> UpdateAsync(RatingDto entity)
        {
            var rating = _mapper.Map<Rating>(entity);
            _dbContext.Ratings.Update(rating);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"Updated rating with ID {rating.Id}");
            return _mapper.Map<RatingDto>(rating);
        }
    }
}
