using System;
using System.Collections.Generic;
using System.Text;

namespace Project_P34.DTO.Models
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }
        public int MovieId { get; set; }
        public string UserId { get; set; }
    }
}
