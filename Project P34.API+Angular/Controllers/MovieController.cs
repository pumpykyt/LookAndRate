using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public MovieController(EFContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public ResultDto addMovie([FromBody]MovieItemDTO model)
        {
            try
            {
                var tmp = new Movie();
                tmp.Id = model.Id;
                tmp.Name = model.Name;
                tmp.Rating = model.Rating;
                tmp.Country = model.Country;
                tmp.Budget = model.Budget;
                tmp.CountViews = model.CountViews;
                tmp.Director = model.Director;
                tmp.Operator = model.Operator;
                tmp.Composer = model.Composer;
                tmp.Genre = model.Genre;
                tmp.Description = model.Description;
                tmp.PictureUrl = model.PictureUrl;
                tmp.TrailerUrl = model.TrailerUrl;
                tmp.Slogan = model.Slogan;
                tmp.OriginalName = model.OriginalName;
                tmp.Length = model.Length;
                tmp.filmActors = model.filmActors.ToList();
                _context.movies.Add(tmp);
                _context.SaveChanges();

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
        public MovieItemDTO getFilm([FromRoute]int id)
        {
            var el = _context.movies.FirstOrDefault(t => t.Id == id);
            var obj = new MovieItemDTO
            {
                Id = el.Id,
                Name = el.Name,
                Rating = el.Rating,
                Country = el.Country,
                Budget = el.Budget,
                CountViews = el.CountViews,
                Director = el.Director,
                Operator = el.Operator,
                Composer = el.Composer,
                Genre = el.Genre,
                Description = el.Description,
                PictureUrl = el.PictureUrl,
                TrailerUrl = el.TrailerUrl,
                Slogan = el.Slogan,
                OriginalName = el.OriginalName,
                Length = el.Length,
                filmActors = el.filmActors.ToList()
            };

            return obj;
        }


        [HttpGet("get")]
        public IEnumerable<MovieItemDTO> getFilms()
        {
            var list = new List<MovieItemDTO>();
            foreach (var el in _context.movies)
            {
                var tmp = new MovieItemDTO();
                tmp.Id = el.Id;
                tmp.Name = el.Name;
                tmp.Rating = el.Rating;
                tmp.Country = el.Country;
                tmp.Budget = el.Budget;
                tmp.CountViews = el.CountViews;
                tmp.Director = el.Director;
                tmp.Operator = el.Operator;
                tmp.Composer = el.Composer;
                tmp.Genre = el.Genre;
                tmp.Description = el.Description;
                tmp.PictureUrl = el.PictureUrl;
                tmp.TrailerUrl = el.TrailerUrl;
                tmp.Slogan = el.Slogan;
                tmp.OriginalName = el.OriginalName;
                tmp.Length = el.Length;
                tmp.filmActors = el.filmActors.ToList();
                list.Add(tmp);
            }

            return list;
        }
    }
}
