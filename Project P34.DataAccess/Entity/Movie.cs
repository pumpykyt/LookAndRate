using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project_P34.DataAccess.Entity
{
    [Table("tblMovies")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
        public string Operator { get; set; }
        public string Composer { get; set; }
        public string Genre { get; set; }
        public string Slogan { get; set; }
        public int Budget { get; set; }
        public int Length { get; set; }
        public int CountViews { get; set; }
        public string PictureUrl { get; set; }
        public string TrailerUrl { get; set; }
        public float Rating { get; set; }
        public virtual ICollection<Actor> filmActors { get; set; }
        public virtual ICollection<Review> reviews { get; set; }
        public virtual Announcement Announcement { get; set; }

    }
}
