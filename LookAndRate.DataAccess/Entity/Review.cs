using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LookAndRate.DataAccess.Entity
{
    [Table("tblReviews")]
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public virtual Movie reviewMovie { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserMoreInfo userReview { get; set; }

    }
}
