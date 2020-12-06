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
    public class ActorController : ControllerBase
    {
        private readonly EFContext _context;
        private readonly IMapper _mapper;

        public ActorController(EFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<ResultDto> addActor([FromBody]ActorDTO model)
        {
            try
            {
                var obj = _mapper.Map<ActorDTO, Actor>(model);
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
        public async Task<ActorDTO> getActor([FromRoute]int id)
        {
            var obj = await _context.actors.FirstOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<Actor, ActorDTO>(obj);
        }

        [HttpGet]
        public async Task<IEnumerable<ActorDTO>> getAllActors()
        {
            var entities = await _context.actors.ToListAsync();
            return _mapper.Map<List<Actor>, List<ActorDTO>>(entities);
        }

        [HttpGet("getfilms/{id}")]
        public async Task<IEnumerable<MovieDTO>> getActorFilms([FromRoute]int id)
        {
            var actor = await _context.actors.FirstOrDefaultAsync(t => t.Id == id);
            var entities = actor.actorFilms.ToList();
            return _mapper.Map<List<Movie>, List<MovieDTO>>(entities);
        }

        [HttpPost("addphoto/{id}")]
        public async Task<ResultDto> addActorPhoto([FromRoute]int id, [FromBody]PhotoDTO model)
        {
            try
            {
                var photoActor = await _context.actors.FirstOrDefaultAsync(t => t.Id == id);
                var obj = _mapper.Map<PhotoDTO, Photo>(model);

                await _context.photos.AddAsync(obj);
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

        [HttpGet("getphotos/{id}")]
        public async Task<IEnumerable<PhotoDTO>> getActorPhotos([FromRoute]int id)
        {
            var entities = await _context.photos.Where(t => t.Id == id).ToListAsync();
            return _mapper.Map<List<Photo>, List<PhotoDTO>>(entities);
        }
        
    }
}
