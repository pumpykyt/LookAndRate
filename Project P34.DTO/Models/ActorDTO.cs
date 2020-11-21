﻿using Project_P34.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_P34.DTO.Models
{
    public class ActorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public string Country { get; set; }
        public string CountFilms { get; set; }
        public string Description { get; set; }
        public int BirthYear { get; set; }
        public int Age { get; set; }
        public string PictureUrl { get; set; }
        public virtual List<Movie> actorFilms { get; set; }
    }
}
