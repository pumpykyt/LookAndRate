using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project_P34.DataAccess.Entity
{
    [Table("tblActors")]
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public int Age { get; set; }
        public string PictureUrl { get; set; }
        public virtual ICollection<Movie> actorFilms { get; set; }
    }
}
