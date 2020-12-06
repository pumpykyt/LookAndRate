using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_IDA.DTO.Models.Result;
using Project_P34.DataAccess;
using Project_P34.DataAccess.Entity;
using Project_P34.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_P34.API_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly EFContext _context;
        private readonly IMapper _mapper;
        public MovieController(EFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<ResultDto> addMovie([FromBody]MovieDTO model)
        {
            try
            {
                var obj = _mapper.Map<MovieDTO, Movie>(model);

                await _context.AddAsync(obj);
                await _context.SaveChangesAsync();

                return new ResultDto
                {
                    Message = "Posted",
                    Status = 200
                };
            }
            catch (Exception ex)
            {
                List<string> temp = new List<string>();
                temp.Add(ex.Message);
                return new ResultErrorDto
                {
                    Status = 500,
                    Message = "ERROR",
                    Errors = temp
                };
            }
        }

        [HttpGet("get/{id}")]
        public async Task<MovieDTO> getFilm([FromRoute]int id)
        {
            var temp = await _context.movies.FirstOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<Movie, MovieDTO>(temp);
        }


        [HttpGet]
        public async Task<IEnumerable<MovieDTO>> getFilms()
        {
            var entities = await _context.movies.ToListAsync();
            return _mapper.Map<List<Movie>, List<MovieDTO>>(entities);
        }

        [HttpPost("rate")]
        public async Task<ResultDto> rateMovie([FromBody]ReviewDTO model)
        {
            var movie = await _context.movies.FirstOrDefaultAsync(t => t.Id == model.MovieId);

            if(movie.Rating == 0)
            {
                movie.Rating = model.Mark;
            }
            if(movie.Rating > 0)
            {
                movie.Rating = (float)(movie.Rating + model.Mark / 2);
            } 
                
            var obj = _mapper.Map<ReviewDTO, Review>(model);
            await _context.reviews.AddAsync(obj);
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                Message = "Posted",
                Status = 200
            };
        }

    }
}
