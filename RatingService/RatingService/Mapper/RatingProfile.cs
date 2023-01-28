using AutoMapper;
using RatingService.DTOs;
using RatingService.Entities;

namespace RatingService.Mapper
{
    public class RatingProfile: Profile

    {
        public RatingProfile()
        { 
            CreateMap<Rating, RatingDto>();
            CreateMap<RatingDto, Rating>();
        }
    

    }
}
