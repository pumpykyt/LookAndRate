using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LookAndRate.DataAccess.Entity
{
    [Table("tblActors")]
    public class Actor
    {
        [Key]
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
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Movie> actorFilms { get; set; }
    }
}
