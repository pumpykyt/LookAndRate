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


    }
}
