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
    public class ActorController : ControllerBase
    {
        private readonly EFContext _context;

        public ActorController(EFContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public ResultDto addActor([FromBody] ActorDTO model)
        {
            try
            {
                var obj = new Actor();
                obj.Name = model.Name;
                obj.Surname = model.Surname;
                obj.Fathername = model.Fathername;
                obj.Age = model.Age;
                obj.PictureUrl = model.PictureUrl;
                _context.actors.Add(obj);
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
        public ActorDTO getActor([FromRoute]int id)
        {
            var tmp = _context.actors.FirstOrDefault(t => t.Id == id);
            var obj = new ActorDTO
            {
                Id = tmp.Id,
                Name = tmp.Name,
                Surname = tmp.Surname,
                Fathername = tmp.Fathername,
                Age = tmp.Age,
                Country = tmp.Country,
                CountFilms = tmp.CountFilms,
                BirthYear = tmp.BirthYear,
                Description = tmp.Description,
                PictureUrl = tmp.PictureUrl,
                actorFilms = tmp.actorFilms.ToList()
            };

            return obj;
        }

        [HttpGet]
        public IEnumerable<ActorDTO> getAllActors()
        {
            var list = new List<ActorDTO>();
            foreach(var el in _context.actors)
            {
                var tmp = new ActorDTO();
                tmp.Id = el.Id;
                tmp.Name = el.Name;
                tmp.Surname = el.Surname;
                tmp.Country = el.Country;
                tmp.BirthYear = el.BirthYear;
                tmp.Description = el.Description;
                tmp.CountFilms = el.CountFilms;
                tmp.Fathername = el.Fathername;
                tmp.PictureUrl = el.PictureUrl;
                tmp.actorFilms = el.actorFilms.ToList();
                list.Add(tmp);
            }

            return list;
        }

        [HttpGet("getfilms/{id}")]
        public IEnumerable<MovieItemDTO> getActorFilms([FromRoute]int id)
        {
            var list = new List<MovieItemDTO>();
            var actor = _context.actors.FirstOrDefault(t => t.Id == id);
            foreach(var el in actor.actorFilms)
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

        [HttpPost("addphoto/{id}")]
        public ResultDto addActorPhoto([FromRoute]int id, [FromBody]PhotoDTO model)
        {
            try
            {
                var obj = new Photo();
                obj.PictureUrl = model.PictureUrl;
                obj.photoActor = _context.actors.FirstOrDefault(t => t.Id == id);

                _context.photos.Add(obj);
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

        [HttpGet("getphotos/{id}")]
        public IEnumerable<PhotoDTO>getActorPhotos([FromRoute]int id)
        {
            var list = new List<PhotoDTO>();
            foreach(var el in _context.photos.Where(t=> t.ActorId == id))
            {
                var obj = new PhotoDTO();
                obj.Id = el.Id;
                obj.PictureUrl = el.PictureUrl;
                obj.ActorId = el.ActorId;
                list.Add(obj);
            }
            return list;
        }

        [HttpPost("addfilm")]
        public ResultDto addActorFilm([FromRoute]int id,[FromBody]MovieItemDTO model)
        {
            try
            {
                var obj = new Movie();
                obj.Name = model.Name;
                obj.Rating = model.Rating;
                obj.Country = model.Country;
                obj.Budget = model.Budget;
                obj.CountViews = model.CountViews;
                obj.Director = model.Director;
                obj.Operator = model.Operator;
                obj.Composer = model.Composer;
                obj.Genre = model.Genre;
                obj.Description = model.Description;
                obj.PictureUrl = model.PictureUrl;
                obj.TrailerUrl = model.TrailerUrl;
                obj.Slogan = model.Slogan;
                obj.OriginalName = model.OriginalName;
                obj.Length = model.Length;
                obj.filmActors = model.filmActors.ToList();

                _context.actors.FirstOrDefault(t => t.Id == id).actorFilms.Add(obj);
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
    }
}
