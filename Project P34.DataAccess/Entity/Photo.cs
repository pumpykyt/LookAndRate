using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project_P34.DataAccess.Entity
{
    [Table("tblPhotos")]
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string PictureUrl { get; set; }
        public int ActorId { get; set; }
        [ForeignKey("ActorId")]
        public virtual Actor photoActor { get; set; }
    }
}
